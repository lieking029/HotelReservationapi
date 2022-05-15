using HotelReservationApi.Dtos;
using HotelReservationApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationApi.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        protected DataContext _dataContext;

        public ReservationsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet]
        public async Task<ActionResult<List<Reservations>>> GetReservations()
        { 
            return Ok(await _dataContext.Reservations
                .Include(reservation => reservation.RoomTypes)
                .Include(reservation => reservation.ReservationStatus)
                .ToListAsync());
        }
  

        [HttpPost]
        public async Task<ActionResult<Reservations>> PostReservation(ReservationDto newReservation)
        {
            Reservations reservation = new()
            {
                GuestName = newReservation.GuestName,
                StartDate = newReservation.StartDate,
                EndDate = newReservation.EndDate,
                ContactNumber = newReservation.ContactNumber,
                Notes = newReservation.Notes,
                ReservationStatusId = newReservation.ReservationStatusId,
                RoomTypeId = newReservation.RoomTypeId,
            };

            await _dataContext.Reservations.AddAsync(reservation);
            await _dataContext.SaveChangesAsync();

            return Ok(reservation);
        }



        [HttpPut("{reservationId}")]
        public async Task<ActionResult<Reservations>> PutReservation(int reservationId, ReservationDto reservation)
        {

            var findReservation = await _dataContext.Reservations.FindAsync(reservationId);
            if (findReservation == null) {
                return NotFound("Reservation Not Found");
            }

            findReservation.StartDate = reservation.StartDate;
            findReservation.EndDate = reservation.EndDate;
            findReservation.ContactNumber = reservation.ContactNumber;
            findReservation.GuestName = reservation.GuestName;
            findReservation.Notes = reservation.Notes;
            findReservation.ReservationStatusId = reservation.ReservationStatusId;
            findReservation.RoomTypeId = reservation.RoomTypeId;

            _dataContext.Reservations.Update(findReservation);
            await _dataContext.SaveChangesAsync();

            return Ok(findReservation);
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            var findReservation = await _dataContext.Reservations.FindAsync(id);

            if (findReservation == null)
            {
                return NotFound("Reservation Doesnt exist");
            }

            _dataContext.Reservations.Remove(findReservation);
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }
    }
}

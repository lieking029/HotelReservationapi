using HotelReservationApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationApi.Controllers
{
    [Route("api/room-types")]
    [ApiController] 
    public class RoomTypeController : ControllerBase
    {
        protected DataContext _dataContext;

        public RoomTypeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet]
        public async Task<ActionResult<List<RoomTypes>>> GetRoomTypes()
        {
            return Ok(await _dataContext.RoomTypes.ToListAsync());
        }
    }
}

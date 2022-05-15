using System.ComponentModel.DataAnnotations;

namespace HotelReservationApi.Dtos
{
    public class ReservationDto
    {
        [Required]
        public string GuestName { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string ContactNumber { get; set; } = string.Empty;

        [Required]
        public string Notes { get; set; } = string.Empty;

        [Required]
        public int ReservationStatusId { get; set; }

        [Required]
        public int RoomTypeId { get; set; }
    }
}

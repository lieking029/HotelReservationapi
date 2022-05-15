using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HotelReservationApi.Models
{
    public class Reservations
    {
        [Key]
        public int ReservationId { get; set; }
        
        public string GuestName { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ContactNumber { get; set; } = String.Empty;

        public string Notes { get; set; } = string.Empty;

        [JsonIgnore]
        public int ReservationStatusId { get; set; }

        public ReservationStatus ReservationStatus { get; set; }

        [JsonIgnore]
        public int RoomTypeId { get; set; }
        public RoomTypes RoomTypes { get; set; }
    }
}

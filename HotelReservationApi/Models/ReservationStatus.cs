using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HotelReservationApi.Models
{
    public class ReservationStatus
    {
        public static readonly int RESERVATION_STATUS_INACTIVE = 0;
        public static readonly int RESERVATION_STATUS_ACTIVE = 1;

        [Key]
        public int ReservationStatusId { get; set; }

        public string Name { get; set; } = string.Empty;

        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<Reservations> reservations { get; set; }
    }
}

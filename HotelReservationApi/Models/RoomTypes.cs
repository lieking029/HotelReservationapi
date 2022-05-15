using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HotelReservationApi.Models
{
    public class RoomTypes
    {
        [Key]
         public int RoomTypeId { get; set; }

        public string Name { get; set; } = string.Empty;

        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<Reservations> reservations { get; set; }
    }
}

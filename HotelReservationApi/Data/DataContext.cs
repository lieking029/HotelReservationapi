
using HotelReservationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<ReservationStatus> ReservationStatus { get; set; }
        public DbSet<RoomTypes> RoomTypes { get; set; }
    }
}

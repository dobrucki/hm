using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public DbSet<Room> Rooms { get; set; }
    }
}
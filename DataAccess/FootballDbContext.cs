using Microsoft.EntityFrameworkCore;
using ResultadosBackend.Models;

namespace ResultadosBackend.DataAccess
{
    public class FootballDbContext : DbContext
    {
        public FootballDbContext(DbContextOptions<FootballDbContext> options) : base(options)
        {

        }
        public DbSet<User>? Users { get; set; }
    }
}

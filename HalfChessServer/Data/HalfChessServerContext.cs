using Microsoft.EntityFrameworkCore;
using HalfChessServer.Models;

namespace HalfChessServer.Data
{
    public class HalfChessServerContext : DbContext
    {
        public HalfChessServerContext(DbContextOptions<HalfChessServerContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; } = default!;
        public DbSet<Player> Players { get; set; } = default!;
        public DbSet<History> Histories { get; set; } = default!;
      
    }
}

using Microsoft.EntityFrameworkCore;
using Nintendo.Models;

namespace Nintendo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet <CharacterModel> Characters { get; set; }


    }
}

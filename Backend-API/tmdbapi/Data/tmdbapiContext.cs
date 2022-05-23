#nullable disable
using Microsoft.EntityFrameworkCore;
using tmdbapi.Models;

namespace tmdbapi.Data
{
    public class tmdbapiContext : DbContext
    {
        public tmdbapiContext (DbContextOptions<tmdbapiContext> options)
            : base(options)
        {
        }

        public DbSet<Comment> Comment { get; set; }
    }
}

#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<tmdbapi.Models.User> User { get; set; }

        public DbSet<tmdbapi.Models.Comment> Comment { get; set; }
    }
}

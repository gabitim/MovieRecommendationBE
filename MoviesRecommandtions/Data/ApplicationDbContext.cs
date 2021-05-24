using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoviesRecommandtions.Models;

namespace MoviesRecommandtions.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserPreferences>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<MoviesRecommandtions.Models.Movie> Movie { get; set; }
        public DbSet<MoviesRecommandtions.Models.UserPreferences> UserPreferences { get; set; }
    }
}

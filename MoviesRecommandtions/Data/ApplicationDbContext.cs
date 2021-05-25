/**************************************************************************
 *                                                                        *
 *  File:        ApplicationDbContext.cs                                        *
 *  Copyright:   (c) 2021, Lupusoru Alexandru                             *
 *  E-mail:      alexandru.lupusoru@student.tuiasi.ro                     *
 *  Description: ApplicationDbContext is used for all the ASP.NET         *
 *               Identity database CRUD operations                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

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

        // Mapping the SqlServer Entity Database Table to POCO Classes 
        public DbSet<MoviesRecommandtions.Models.Movie> Movie { get; set; }
        public DbSet<MoviesRecommandtions.Models.UserPreferences> UserPreferences { get; set; }
    }
}

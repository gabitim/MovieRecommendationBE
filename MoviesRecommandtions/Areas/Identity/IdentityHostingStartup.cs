/**************************************************************************
 *                                                                        *
 *  File:        IdentityHostingStartup.cs                                *
 *  Copyright:   (c) 2021, Timofti Gabriel                                *
 *  E-mail:      gabriel.timofti@student.tuiasi.ro                        *
 *  Description: IdentityHostingStartup adds enhancements to our app at   *
 *               startup from an external assembly. This class is         *
 *               responsible for adding a context and a UserManager       *
 *               Identity                                                 *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MoviesRecommandtions.Areas.Identity.IdentityHostingStartup))]
namespace MoviesRecommandtions.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
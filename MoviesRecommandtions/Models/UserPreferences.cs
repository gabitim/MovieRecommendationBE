/**************************************************************************
 *                                                                        *
 *  File:        IdentityHostingStartup.cs                                *
 *  Copyright:   (c) 2021, Timofti Gabriel                                *
 *  E-mail:      gabriel.timofti@student.tuiasi.ro                        *
 *  Description: UserPreferences class extends IdentityUser and adds      * 
 *               additional properties, in our case user genre            *
 *               Preferences                                              *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using Microsoft.AspNetCore.Identity;

namespace MoviesRecommandtions.Models
{
    //adding additional properties, in our case user genre Preferences
    public class UserPreferences : IdentityUser
    {
        public string Preferences { get; set; }
    }
}

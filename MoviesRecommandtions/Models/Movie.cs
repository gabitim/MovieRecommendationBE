/**************************************************************************
 *                                                                        *
 *  File:        Movie.cs                                                 *
 *  Copyright:   (c) 2021, Hartan Mihai-Silviu                            *
 *  E-mail:      silviuhartan10@gmail.com                                 *
 *  Description: This class is A Plain Old CLR Objects (POCO)             * 
 *               it doesn't depend on any framework-specific base class.  *
 *               It is like any other normal .NET class.                  * 
 *               It encapsulates all the info for a movie like:           *
 *               Name, Rating                                             *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using System.ComponentModel.DataAnnotations;

namespace MoviesRecommandtions.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public byte[] Banner { get; set; }
        [Required]

        public string MovieLink { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string About { get; set; }

        public int Rating { get; set; }

        public string Category { get; set; }
    }
}
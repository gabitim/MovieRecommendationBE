using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp2017.Models
{
    public class Rating
    {
        public int RatingID { get; set; }
        [Required(ErrorMessage = "A rating is required.")]
        [Range (1, 5, ErrorMessage = "Rating must be from 1 to 5")]
        public int RatingValue { get; set; }

        //foreign key
        [Required(ErrorMessage = "The album is required.")]
        public int AlbumID { get; set; }
        //navigation property
        public Album Album { get; set; }

        //foreign key
        public int UserID { get; set; }
    }
}

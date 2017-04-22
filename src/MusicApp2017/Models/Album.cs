using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicApp2017.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }

        // Foreign key
        public int ArtistID { get; set; }
        // Navigation property
        public Artist Artist { get; set; }
        // Foreign key
        [Display(Name ="Genre")]
        public int GenreID { get; set; }
        // Navigation property
        public Genre Genre { get; set; }

        public double Rating { get; set; }

        public double GetRating(MusicDbContext _context)
        {
            double rating = 0;
            var ratings =  _context.Ratings
                .Where(a => a.AlbumID == AlbumID).ToList();
            if(ratings.Count > 0)
            {
                double sum = 0;
                foreach (Rating value in ratings)
                {
                    sum += value.RatingValue;
                }
                rating = Math.Round(sum / ratings.Count, 1, MidpointRounding.AwayFromZero); 
            }
            return rating;
        }
    }
}

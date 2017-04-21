using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicApp2017.Models
{
    public class Album
    {
        private readonly MusicDbContext _context;

        public Album(MusicDbContext context)
        {
            _context = context;
        }
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

        public async Task<double> GetRating()
        {
            var ratings = await _context.Ratings
                .Where(a => a.AlbumID == AlbumID).ToListAsync();
            if (ratings == null)
            {
                return 0;
            }
            else
            {
                double sum = 0;
                foreach (Rating value in ratings)
                {
                    sum += value.RatingValue;
                }
                double rating = Math.Round(sum / ratings.Count, 1, MidpointRounding.AwayFromZero);
                return rating;
            }
        }
    }
}

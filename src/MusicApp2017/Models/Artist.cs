using System.ComponentModel.DataAnnotations;

namespace MusicApp2017.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }

        [Required(ErrorMessage ="Artist name is required")]
        public string Name { get; set; }
        [Display (Name = "Artist Bio")]
        public string Bio { get; set; }
    }
}
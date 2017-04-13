using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MusicApp2017.Models.AccountViewModels
{
    public class EditViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}

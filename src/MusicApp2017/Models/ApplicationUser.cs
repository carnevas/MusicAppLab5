using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MusicApp2017.Models
{
    public class ApplicationUser : IdentityUser
    {
        //Foreign Key
        [Display(Name = "Favorite Genre")]
        [Required]
        public int GenreID { get; set; }
        //Navigation Property
        public Genre Genre { get; set; }
    }
}

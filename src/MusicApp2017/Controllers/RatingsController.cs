using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicApp2017.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApp2017.Controllers
{
    public class RatingsController : Controller
    {
        private readonly MusicDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RatingsController(MusicDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize]
        public IActionResult Rate(int? id)
        {
            var album = _context.Albums.Where(a => a.AlbumID == id);
            return View(album);
        }
        [HttpPost]
        public async Task<IActionResult> Rate(int id, int value)
        {   
            Rating rating = new Rating
            {
                AlbumID = id,
                RatingValue = value,
                UserID = _userManager.GetUserId(User)
            };
            rating.AlbumID = id;
            var album = await _context.Albums.SingleOrDefaultAsync(a => a.AlbumID == rating.AlbumID);
            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();
            album.Rating = album.GetRating(_context);
            _context.Update(album);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AlbumsController.Index), "Albums");
        }
    }
}

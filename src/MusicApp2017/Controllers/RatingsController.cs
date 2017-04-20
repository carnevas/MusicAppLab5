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
            ViewData["Values"] = new SelectList(Enumerable.Range(1, 5));
            return View(album);
        }
        [HttpPost]
        public async Task<IActionResult> Rate(int value, int id)
        {
            if (ModelState.IsValid)
            {
                var album = await _context.Albums.SingleOrDefaultAsync(a => a.AlbumID == id);
                var rating = new Rating();
                rating.AlbumID = id;
                rating.RatingValue = value;
                rating.UserID = _userManager.GetUserId(User);
                album.Rating = GetRating(rating.AlbumID).Result;
                _context.Albums.Update(album);
                _context.Add(rating);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(value);
        }
        private async Task<double> GetRating(int? id)
        {
            var ratings = await _context.Ratings
                .Where(a => a.AlbumID == id).ToListAsync();
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

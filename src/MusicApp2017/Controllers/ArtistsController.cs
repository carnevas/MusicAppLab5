using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicApp2017.Models;
using Microsoft.AspNetCore.Authorization;

namespace MusicApp2017.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly MusicDbContext _context;

        public ArtistsController(MusicDbContext context)
        {
            _context = context;
        }

        // GET: Artist/5
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var musicDbContext = _context.Artists;
            return View(await musicDbContext.ToListAsync());
        }

        // GET: Artist/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var artistContext = _context.Albums
                .Include(a => a.Artist)
                .Include(a => a.Genre);
            var artistAlbums = await artistContext
                .Where(m => m.ArtistID == id).ToListAsync();
            if (artistAlbums == null)
            {
                return NotFound();
            }

            return View(artistAlbums);
        }
        // GET: Genres/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "Name", "Bio");
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtistID, Name, Bio")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                foreach(Artist contextArtist in _context.Artists.ToArray())
                {
                    if(artist.Name.ToLower().Equals(contextArtist.Name.ToLower()))
                    {
                        return RedirectToAction("Index");
                    }
                }
                _context.Add(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "Name", artist.ArtistID);
            return View(artist);
        }
        // GET: Artists/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists.SingleOrDefaultAsync(m => m.ArtistID == id);
            if (artist == null)
            {
                return NotFound();
            }
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "Name", artist.ArtistID);
            return View(artist);
        }

        // POST: Artists/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtistID, Name, Bio")] Artist artist)
        {
            if (id != artist.ArtistID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(artist.ArtistID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "Name", artist.ArtistID);
            return View(artist);
        }

        private bool ArtistExists(int id)
        {
            return _context.Artists.Any(e => e.ArtistID == id);
        }
    }
}

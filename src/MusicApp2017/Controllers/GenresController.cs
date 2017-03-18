using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicApp2017.Models;

namespace MusicApp2017.Controllers
{
    public class GenresController : Controller
    { 
     private readonly MusicDbContext _context;

    public GenresController(MusicDbContext context)
    {
        _context = context;
    }

    // GET: Genres/5
    public async Task<IActionResult> Index()
    {
            var musicDbContext = _context.Genres;
        return View(await musicDbContext.ToListAsync());
    }

    // GET: Genres/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
            var genreContext = _context.Albums
                .Include(a => a.Genre)
                .Include(a => a.Artist);
        var genreAlbums = await genreContext
            .Where(m => m.GenreID == id).ToListAsync();
        if (genreAlbums == null)
        {
            return NotFound();
        }

        return View(genreAlbums);
    }
        // GET: Genres/Create
        public IActionResult Create()
        {
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "Name");
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenreID, Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                foreach (Genre contextGenre in _context.Genres.ToArray())
                {
                    if(genre.Name.ToLower().Equals(contextGenre.Name.ToLower()))
                    {
                        return RedirectToAction("Index");
                    }
                }
                _context.Add(genre);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "Name", genre.GenreID);
            return View(genre);
        }
        // GET: Genres/Edit/5
        public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var genre = await _context.Genres.SingleOrDefaultAsync(m => m.GenreID == id);
        if (genre == null)
        {
            return NotFound();
        }
        ViewData["GenreID"] = new SelectList(_context.Artists, "GenreID", "Name", genre.GenreID);
        return View(genre);
    }

    // POST: Genres/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("GenreID, Name")] Genre genre)
    {
        if (id != genre.GenreID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(genre);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(genre.GenreID))
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
        ViewData["GenreID"] = new SelectList(_context.Artists, "GenreID", "Name", genre.GenreID);
        return View(genre);
    }

    private bool GenreExists(int id)
    {
        return _context.Genres.Any(e => e.GenreID == id);
    }
}
}

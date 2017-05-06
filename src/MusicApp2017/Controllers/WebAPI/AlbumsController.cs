using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicApp2017.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApp2017.Controllers.WebAPI
{
    [Route("api/[controller]")]
    public class AlbumsController : Controller
    {
        public readonly MusicDbContext _context;

        public AlbumsController(MusicDbContext context)
        {
            _context = context;
        }
        // GET: api/albums
        [HttpGet]
        public async Task<IEnumerable<Album>> Get()
        {
            var albums = _context.Albums
                .Include(a => a.Artist)
                .Include(a => a.Genre);
            return await albums.ToListAsync();
        }

        // GET api/albums/5
        [HttpGet("{id}")]
        public Album Get(int id)
        {
            var albums = _context.Albums
                 .Include(a => a.Artist)
                 .Include(a => a.Genre);
            Album album = albums.SingleOrDefault(a => a.AlbumID == id);
            return album;
        }

        // POST api/albums
        [HttpPost]
        public void Post([FromBody]Album album)
        {
            _context.Add(album);
            _context.SaveChanges();
        }

        // PUT api/albums/5
        [HttpPut("{id}")]
        public async void Put([FromBody]Album album)
        {
            _context.Albums.Update(album);
            await _context.SaveChangesAsync();
        }

        // DELETE api/albums/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var album = _context.Albums.SingleOrDefault(a => a.AlbumID == id);
            if(album != null)
            {
                _context.Albums.Remove(album);
                await _context.SaveChangesAsync();
            }

        }
    }
}

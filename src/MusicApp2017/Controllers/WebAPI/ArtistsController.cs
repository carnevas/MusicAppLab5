using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApp2017.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApp2017.Controllers.WebAPI
{
    [Route("api/[controller]")]
    public class ArtistsController : Controller
    {
        public readonly MusicDbContext _context;
        
        public ArtistsController(MusicDbContext context)
        {
            _context = context; 
        }
        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Artist>> Get()
        {
            return await _context.Artists.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Artist Get(int id)
        {
            return _context.Artists.SingleOrDefault(a => a.ArtistID == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

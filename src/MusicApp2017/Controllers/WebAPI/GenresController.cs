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
    public class GenresController : Controller
    {
        public readonly MusicDbContext _context;
        public GenresController(MusicDbContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Genre>> Get()
        {
            return await _context.Genres.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Task<Genre> Get(int id)
        {
            return _context.Genres.SingleOrDefaultAsync(a => a.GenreID == id);
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

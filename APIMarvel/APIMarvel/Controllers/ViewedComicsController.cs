using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIMarvel.Model;

namespace APIMarvel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewedComicsController : ControllerBase
    {
        private readonly ComicsContext _context;

        public ViewedComicsController(ComicsContext context)
        {
            _context = context;
        }

        // GET: api/ViewedComics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewedComic>>> GetViewedComics()
        {
          if (_context.ViewedComics == null)
          {
              return NotFound();
          }
            return await _context.ViewedComics.ToListAsync();
        }

        // GET: api/ViewedComics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewedComic>> GetViewedComic(long id)
        {
          if (_context.ViewedComics == null)
          {
              return NotFound();
          }
            var viewedComic = await _context.ViewedComics.FindAsync(id);

            if (viewedComic == null)
            {
                return NotFound();
            }

            return viewedComic;
        }

        // PUT: api/ViewedComics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViewedComic(long id, ViewedComic viewedComic)
        {
            if (id != viewedComic.Id)
            {
                return BadRequest();
            }

            _context.Entry(viewedComic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViewedComicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ViewedComics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ViewedComic>> PostViewedComic(ViewedComic viewedComic)
        {
          if (_context.ViewedComics == null)
          {
              return Problem("Entity set 'ComicsContext.ViewedComics'  is null.");
          }
            _context.ViewedComics.Add(viewedComic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViewedComic", new { id = viewedComic.Id }, viewedComic);
        }

        // DELETE: api/ViewedComics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViewedComic(long id)
        {
            if (_context.ViewedComics == null)
            {
                return NotFound();
            }
            var viewedComic = await _context.ViewedComics.FindAsync(id);
            if (viewedComic == null)
            {
                return NotFound();
            }

            _context.ViewedComics.Remove(viewedComic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViewedComicExists(long id)
        {
            return (_context.ViewedComics?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}

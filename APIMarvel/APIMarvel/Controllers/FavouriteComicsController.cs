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
    public class FavouriteComicsController : ControllerBase
    {
        private readonly ComicsContext _context;

        public FavouriteComicsController(ComicsContext context)
        {
            _context = context;
        }

        // GET: api/FavouriteComics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavouriteComic>>> GetFavouriteComics()
        {
          if (_context.FavouriteComics == null)
          {
              return NotFound();
          }

            return await _context.FavouriteComics.ToListAsync();
        }

        //GET: api/FavouriteComics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<FavouriteComic>>> GetFavouriteComic(long id)
        {
            if (_context.FavouriteComics == null)
            {
                return NotFound();
            }
            var favouriteComic = _context.FavouriteComics.Where(x => x.UserId == id).ToList();

            if (favouriteComic == null)
            {
                return NotFound();
            }

            return favouriteComic;
        }

        

        // POST: api/FavouriteComics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavouriteComic>> PostFavouriteComic(FavouriteComic favouriteComic)
        {
          if (_context.FavouriteComics == null)
          {
              return Problem("Entity set 'ComicsContext.FavouriteComics'  is null.");
          }
            _context.FavouriteComics.Add(favouriteComic);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FavouriteComicExists(favouriteComic.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFavouriteComic", new { id = favouriteComic.UserId }, favouriteComic);
        }

        private bool FavouriteComicExists(long id)
        {
            return (_context.FavouriteComics?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}

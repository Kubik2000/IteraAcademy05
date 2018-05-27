using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloggingPlatform.Db.Model;

namespace BloggingPlatform.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/PostsCategories")]
    public class PostsCategoriesController : Controller
    {
        private readonly BloggingPlatformContext _context;

        public PostsCategoriesController(BloggingPlatformContext context)
        {
            _context = context;
        }

        // GET: api/PostsCategories
        [HttpGet]
        public IEnumerable<PostsCategories> GetPostsCategories()
        {
            return _context.PostsCategories;
        }

        // GET: api/PostsCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostsCategories([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postsCategories = await _context.PostsCategories.SingleOrDefaultAsync(m => m.PostId == id);

            if (postsCategories == null)
            {
                return NotFound();
            }

            return Ok(postsCategories);
        }

        // PUT: api/PostsCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostsCategories([FromRoute] Guid id, [FromBody] PostsCategories postsCategories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postsCategories.PostId)
            {
                return BadRequest();
            }

            _context.Entry(postsCategories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostsCategoriesExists(id))
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

        // POST: api/PostsCategories
        [HttpPost]
        public async Task<IActionResult> PostPostsCategories([FromBody] PostsCategories postsCategories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PostsCategories.Add(postsCategories);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PostsCategoriesExists(postsCategories.PostId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPostsCategories", new { id = postsCategories.PostId }, postsCategories);
        }

        // DELETE: api/PostsCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostsCategories([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postsCategories = await _context.PostsCategories.SingleOrDefaultAsync(m => m.PostId == id);
            if (postsCategories == null)
            {
                return NotFound();
            }

            _context.PostsCategories.Remove(postsCategories);
            await _context.SaveChangesAsync();

            return Ok(postsCategories);
        }

        private bool PostsCategoriesExists(Guid id)
        {
            return _context.PostsCategories.Any(e => e.PostId == id);
        }
    }
}
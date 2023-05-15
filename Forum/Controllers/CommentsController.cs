using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Forum.Data;
using Forum.Models;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ContentDbContext _context;

        public CommentsController(ContentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comments>>> GetAllComments()
        {
            if (_context.Comments == null)
            {
                return NotFound();
            }
            return await _context.Comments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comments>> GetCommentById(int id)
        {
            if (_context.Comments == null)
            {
                return NotFound();
            }
            var comments = await _context.Comments.FindAsync(id);

            if (comments == null)
            {
                return NotFound();
            }

            return comments;
        }

        [HttpGet("discussions/{discussionId}/comments")]
        public IActionResult GetCommentsFormDiscussion(int discussionId)
        {
            var discussion = _context.Discussions.Include(d => d.Comments).FirstOrDefault(d => d.Id == discussionId);
            if (discussion == null)
            {
                return NotFound();
            }

            return Ok(discussion.Comments);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutComments(int id, Comments comments)
        {
            if (id != comments.Id)
            {
                return BadRequest();
            }

            _context.Entry(comments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentsExists(id))
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

        [HttpPost("discussions/{discussionId}/comments")]
        public IActionResult CreateComment(int discussionId, [FromBody] CommentDto commentDto)
        {
            var discussion = _context.Discussions.FirstOrDefault(d => d.Id == discussionId);
            if (discussion == null)
            {
                return NotFound();
            }

            var comment = new Comments
            {
                Text = commentDto.Text,
                CreationDate = DateTime.Now,
                Discussions = discussion
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();

            // Map Comment entity to CommentDto
            var commentResponse = new CommentDto
            {
                Text = comment.Text,
                CreationDate = comment.CreationDate
            };

            return Ok(commentResponse);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComments(int id)
        {
            if (_context.Comments == null)
            {
                return NotFound();
            }
            var comments = await _context.Comments.FindAsync(id);
            if (comments == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentsExists(int id)
        {
            return (_context.Comments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

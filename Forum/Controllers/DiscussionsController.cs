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
    public class DiscussionsController : ControllerBase
    {
        private readonly ContentDbContext _context;

        public DiscussionsController(ContentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDiscussionsWithComments()
        {
            var discussions = _context.Discussions.Include(d => d.Comments).ToList();

            var discussionDtos = discussions.Select(d => new DiscussionDto
            {
                Id = d.Id,
                Title = d.Title,
                Description = d.Description,
                Comments = d.Comments.Select(c => new CommentDto
                {
                    Text = c.Text,
                    CreationDate = c.CreationDate
                }).ToList()
            }).ToList();

            return Ok(discussionDtos);
        }

        [HttpGet("discussions/{discussionId}")]
        public IActionResult GetDiscussionById(int discussionId)
        {
            var discussion = _context.Discussions.Include(d => d.Comments).FirstOrDefault(d => d.Id == discussionId);
            if (discussion == null)
            {
                return NotFound();
            }

            var discussionDto = new DiscussionDto
            {
                Id = discussionId,
                Title = discussion.Title,
                Description = discussion.Description,
                Comments = discussion.Comments.Select(c => new CommentDto
                {
                    Text = c.Text,
                    CreationDate = c.CreationDate
                }).ToList()
            };

            return Ok(discussionDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscussions(int id, Discussions discussions)
        {
            if (id != discussions.Id)
            {
                return BadRequest();
            }

            _context.Entry(discussions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscussionsExists(id))
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

        [HttpPost("discussions")]
        public IActionResult CreateDiscussion([FromBody] DiscussionDto discussionDto)
        {
            var discussion = new Discussions
            {
                Title = discussionDto.Title,
                Description = discussionDto.Description,
                CreationDate = DateTime.Now
            };

            _context.Discussions.Add(discussion);
            _context.SaveChanges();

            return Ok(discussion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscussions(int id)
        {
            if (_context.Discussions == null)
            {
                return NotFound();
            }
            var discussions = await _context.Discussions.FindAsync(id);
            if (discussions == null)
            {
                return NotFound();
            }

            _context.Discussions.Remove(discussions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiscussionsExists(int id)
        {
            return (_context.Discussions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

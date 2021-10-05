using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BlogApi.Models;
using BlogApi.Services;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class PostsController : ControllerBase
    {
        readonly BlogContext _context;

        public PostsController(BlogContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<BlogPost>> Get()
        {
            return _context.BlogPosts;
        }

        // GET api/posts/5
        [HttpGet("{id}")]
        public ActionResult<BlogPost> Get(int id)
        {
            return _context.BlogPosts.FirstOrDefault(post => post.BlogPostId == id);
        }

        // POST api/posts
        [HttpPost]
        public void Post([FromBody] BlogPost value)
        {
            _context.BlogPosts.Add(value);
            _context.SaveChanges();
        }

        // PUT api/posts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BlogPost value)
        {
            var post = _context.BlogPosts.FirstOrDefault(p => p.BlogPostId == id);
            if (post == null)
                return;
            
            post.Title = value.Title;
            post.Summary = value.Summary;
            post.Body = value.Body;
            post.Author = value.Author;
            post.Tags = value.Tags;

            _context.BlogPosts.Update(post);
            _context.SaveChanges();
        }

        // DELETE api/posts/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var post = _context.BlogPosts.FirstOrDefault(p => p.BlogPostId == id);
            if (post == null)
                return;

            _context.BlogPosts.Remove(post);
            _context.SaveChanges();
        }
    }
}

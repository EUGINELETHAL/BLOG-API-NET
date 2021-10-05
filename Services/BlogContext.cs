using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BlogApi.Models;

namespace BlogApi.Services
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public BlogContext() { }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Author> Authors { get; set; }
    }
}
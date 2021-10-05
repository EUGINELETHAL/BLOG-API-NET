using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BlogApi.Models;

namespace BlogApi.Services
{
    public interface IBlogContext
    {
        DbSet<BlogPost> BlogPosts { get; set; }

        DbSet<Author> Authors { get; set; }
    }
}
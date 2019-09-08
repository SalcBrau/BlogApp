using BlogApp.Data;
using BlogApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Repo
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext _context;
        
        public BlogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<Post> Posts(int pageNum, int pageSize)
        {
            return _context.Posts.Where(p => p.Published)
                                  .OrderByDescending(p => p.PostedOn)
                                  .Skip(pageNum * pageSize)
                                  .Take(pageSize)
                                  .Include(p => p.Category)
                                  .Include(p => p.PostTags)
                                  .ThenInclude(pt => pt.Tag)
                                  .ToList();
        }

        public int TotalPosts()
        {
            return _context.Posts.Where(p => p.Published).Count();
        }
    }
}

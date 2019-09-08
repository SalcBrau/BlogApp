﻿using BlogApp.Data;
using BlogApp.Data.Entities;
using BlogApp.Repo.Implementations;
using BlogApp.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Repo
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository 
    {
        public PostRepository(ApplicationDbContext context) : base(context) { }

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

        public ICollection<Post> PostsForCategory(string categorySlug, int pageNo, int pageSize)
        {
            return _context.Posts.Where(p => p.Published && p.Category.UrlSlug.Equals(categorySlug))
                                      .OrderByDescending(p => p.PostedOn)
                                      .Skip(pageNo * pageSize)
                                      .Take(pageSize)
                                      .Include(p => p.Category)
                                      .Include(p => p.PostTags)
                                      .ToList();
        }

        public int TotalPostsForCategory(string categorySlug)
        {
            return _context.Posts.Where(p => p.Published && p.Category.UrlSlug == categorySlug)
                                 .Count();
        }

        public ICollection<Post> PostsForTag(string tagSlug, int pageNo, int pageSize)
        {
            int tagId = _context.Tags.Where(t => t.UrlSlug == tagSlug).Select(t => t.Id).FirstOrDefault();
            return _context.Posts.Where(p => p.Published && p.PostTags.Any(t => t.TagId == tagId))
                                 .OrderByDescending(p => p.PostedOn)
                                 .Skip(pageNo * pageSize)
                                 .Take(pageSize)
                                 .Include(p => p.Category)
                                 .Include(p => p.PostTags)
                                 .ToList();
        }

        public int TotalPostsForTag(string tagSlug)
        {
            int tagId = _context.Tags.Where(t => t.UrlSlug == tagSlug).Select(t => t.Id).FirstOrDefault();
            return _context.Posts.Where(p => p.Published && p.PostTags.Any(t => t.TagId == tagId))
                                 .Count();
        }
    }
}
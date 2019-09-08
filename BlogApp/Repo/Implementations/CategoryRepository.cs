using BlogApp.Data;
using BlogApp.Data.Entities;
using BlogApp.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Repo.Implementations
{
    public class CategoryRepository: RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }
        public Category Category(string categorySlug)
        {
            return _context.Categories.FirstOrDefault(t => t.UrlSlug.Equals(categorySlug));
        }
    }
}

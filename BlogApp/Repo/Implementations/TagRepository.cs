using BlogApp.Data;
using BlogApp.Data.Entities;
using BlogApp.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Repo.Implementations
{
    public class TagRepository: RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext context) : base(context) { }

        public Tag Tag(string tagSlug)
        {
            return _context.Tags.FirstOrDefault(t => t.UrlSlug.Equals(tagSlug));
        }
    }
}

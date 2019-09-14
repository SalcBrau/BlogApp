using Data;
using Data.Entities;
using Data.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repo.Implementations
{
    public class TagRepository: RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext context) : base(context) { }

        public Tag Tag(string tagSlug)
        {
            return _context.Tags.FirstOrDefault(t => t.UrlSlug.Equals(tagSlug));
        }

        public ICollection<Tag> Tags()
        {
            return _context.Tags.OrderBy(p => p.Name).ToList();
        }
    }
}

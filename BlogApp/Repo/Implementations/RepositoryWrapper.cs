using BlogApp.Data;
using BlogApp.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Repo.Implementations
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private ApplicationDbContext _context;
        private IPostRepository _post;
        private ICategoryRepository _category;

        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }

        public IPostRepository Post
        {
            get
            {
                if (_post == null)
                {
                    _post = new PostRepository(_context);
                }

                return _post;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_context);
                }

                return _category;
            }
        }
    }
}

using BlogApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Repo.Interfaces
{
    public interface ICategoryRepository: IRepositoryBase<Category>
    {
        Category Category(string categorySlug);
    }
}

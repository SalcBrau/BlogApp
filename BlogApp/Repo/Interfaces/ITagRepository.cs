using BlogApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Repo.Interfaces
{
    public interface ITagRepository: IRepositoryBase<Tag>
    {
        Tag Tag(string tagSlug);
    }
}

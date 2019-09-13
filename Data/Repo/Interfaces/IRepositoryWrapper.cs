using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repo.Interfaces
{
    public interface IRepositoryWrapper
    {
        IPostRepository Post { get; }
        ICategoryRepository Category { get; }
        ITagRepository Tag { get; }
    }
}

using BlogApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Repo
{
    public interface IBlogRepository
    {
        ICollection<Post> Posts(int pageNum, int pageSize);
        int TotalPosts();
    }
}

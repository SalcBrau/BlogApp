using BlogApp.Data.Entities;
using BlogApp.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class ListViewModel
    {
        public ListViewModel()
        {

        }

        public ListViewModel(IBlogRepository _blogRepository, int p)
        {
            Posts = _blogRepository.Posts(p - 1, 10);
            TotalPosts = _blogRepository.TotalPosts();
        }

        public ICollection<Post> Posts { get; private set; }

        public int TotalPosts { get; private set; }

    }
}

using BlogApp.Data.Entities;
using BlogApp.Repo;
using BlogApp.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class ListViewModel
    {
        public ListViewModel(IRepositoryWrapper repositoryWrapper, int p)
        {
            Posts = repositoryWrapper.Post.Posts(p - 1, 10);
            TotalPosts = repositoryWrapper.Post.TotalPosts();
        }

        public ListViewModel(IRepositoryWrapper repositoryWrapper, string categorySlug, int p)
        {
            Posts = repositoryWrapper.Post.PostsForCategory(categorySlug, p - 1, 10);
            TotalPosts = repositoryWrapper.Post.TotalPostsForCategory(categorySlug);
            Category = repositoryWrapper.Category.Category(categorySlug);
        }

        public ICollection<Post> Posts { get; private set; }
        public int TotalPosts { get; private set; }
        public Category Category { get; private set;}

    }
}

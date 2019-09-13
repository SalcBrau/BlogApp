using Data.Entities;
using Data.Repo;
using Data.Repo.Interfaces;
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

        public ListViewModel(IRepositoryWrapper repositoryWrapper, string text, string type, int p)
        {
            switch (type)
            {
                case "Category":
                    Posts = repositoryWrapper.Post.PostsForCategory(text, p - 1, 10);
                    TotalPosts = repositoryWrapper.Post.TotalPostsForCategory(text);
                    Category = repositoryWrapper.Category.Category(text);
                    break;
                case "Search":
                    Posts = repositoryWrapper.Post.PostsForSearch(text, p - 1, 10);
                    TotalPosts = repositoryWrapper.Post.TotalPostsForSearch(text);
                    Search = text;
                    break;
                default:
                    Posts = repositoryWrapper.Post.PostsForTag(text, p - 1, 10);
                    TotalPosts = repositoryWrapper.Post.TotalPostsForTag(text);
                    Tag = repositoryWrapper.Tag.Tag(text);
                    break;
            }
        }

        public ICollection<Post> Posts { get; private set; }
        public int TotalPosts { get; private set; }
        public Category Category { get; private set;}
        public Tag Tag { get; private set; }
        public string Search { get; private set; }

    }
}

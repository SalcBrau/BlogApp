using Data.Entities;
using Data.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class WidgetViewModel
    {
        public WidgetViewModel(IRepositoryWrapper repositoryWrapper)
        {
            Categories = repositoryWrapper.Category.Categories();
            Tags = repositoryWrapper.Tag.Tags();
            LatestPosts = repositoryWrapper.Post.Posts(0, 10);
        }

        public ICollection<Category> Categories { get; private set; }
        public ICollection<Tag> Tags { get; private set; }
        public ICollection<Post> LatestPosts { get; private set; }
    }
}

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
        }

        public ICollection<Category> Categories { get; private set; }
    }
}

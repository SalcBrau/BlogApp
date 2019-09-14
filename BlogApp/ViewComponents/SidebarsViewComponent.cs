using BlogApp.Models;
using Data.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.ViewComponents
{
    public class SidebarsViewComponent : ViewComponent
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public SidebarsViewComponent(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IViewComponentResult Invoke()
        {
            var widgetViewModel = new WidgetViewModel(_repositoryWrapper);
            return View("_Sidebars", widgetViewModel);
        }
    }
}

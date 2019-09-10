using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;
using BlogApp.Repo;
using BlogApp.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using BlogApp.Extensions;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public BlogController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Posts([FromQuery(Name = "p")] int p = 1)
        {
            var viewModel = new ListViewModel(_repositoryWrapper, p);
            ViewBag.Title = "Latest Posts";

            return View("List", viewModel);
        }

        public ViewResult Category(string category, int p = 1)
        {
            var viewModel = new ListViewModel(_repositoryWrapper, category, "Category", p);

            if (viewModel.Category == null) throw new HttpException(404, "Category not found.");

            ViewBag.Title = String.Format(@"Latest posts on category ""{0}""", viewModel.Category.Name);

            return View("List", viewModel);
        }

        public ViewResult Tag(string tag, int p = 1)
        {
            var viewModel = new ListViewModel(_repositoryWrapper, tag, "Tag", p);

            if (viewModel.Tag == null) throw new HttpException(404, "Tag not found.");

            ViewBag.Title = String.Format(@"Latest posts tagged on ""{0}""", viewModel.Tag.Name);

            return View("List", viewModel);
        }
    }
}
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.ViewComponents
{
    public class TagsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Post model)
        {
            return View("_Tags", model);
        }
        
    }
}

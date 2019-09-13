using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;

namespace BlogApp
{
    public static class ActionLinkExtensions
    {
        public static IHtmlContent PostLink(this IHtmlHelper helper, Post post)
        {
            return helper.ActionLink(post.Title, "Post", "Blog",
                new
                {
                    year = post.PostedOn.Year,
                    month = post.PostedOn.Month,
                    title = post.UrlSlug
                },
                new
                {
                    title = post.Title
                }
            );
        }

        public static IHtmlContent CategoryLink(this IHtmlHelper helper, Category category)
        {
            return helper.ActionLink(category.Name, "Category", "Blog",
                new
                {
                    category = category.UrlSlug
                },
                new
                {
                    title = String.Format("See all posts in  {0}", category.Name)
                }
            );
        }

        public static IHtmlContent TagLink(this IHtmlHelper helper, Tag tag)
        {
            return helper.ActionLink(tag.Name, "Tag", "Blog",
                new {
                    tag = tag.UrlSlug
                },
                new
                {
                    title = String.Format("See all posts in {0}", tag.Name)
                }
            );
        }
    }
}

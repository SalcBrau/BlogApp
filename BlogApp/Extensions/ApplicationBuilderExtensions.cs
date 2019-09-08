using BlogApp.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseHttpException(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HttpExceptionMiddleware>();
        }
    }

    internal class HttpExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this._next.Invoke(context);
            }
            catch (HttpException httpException)
            {
                context.Response.StatusCode = httpException.StatusCode;
                var responseFeautre = context.Features.Get<IHttpResponseFeature>();
            }
        }
    }
}

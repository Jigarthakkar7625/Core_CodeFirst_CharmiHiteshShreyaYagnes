using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core_CodeFirst
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Error : IMiddleware
    {
        private readonly RequestDelegate _next;

        //public Error(RequestDelegate next)
        //{
        //    _next = next;
        //}

        //public Task Invoke(HttpContext httpContext)
        //{

        //    try
        //    {
        //        return _next(httpContext);
        //    }
        //    catch (Exception)
        //    {
        //        httpContext.Response.StatusCode = 500;

        //        throw;
        //    }

        //}


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {


                // Next process

                await next(context);
            }
            catch (Exception ex)
            {
                //Globally, Database insert, Text filee add log
                var traceId = Guid.NewGuid();
                //_logger.LogError($"Error occure while processing the request, TraceId : ${traceId}," +
                //    $" Message : ${ex.Message}, StackTrace: ${ex.StackTrace}");
            }
        }


        //public Task InvokeAsync(HttpContext context, RequestDelegate next)
        //{
        //    try
        //    {
        //        return _next(context);
        //    }
        //    catch (Exception)
        //    {
        //        context.Response.StatusCode = 500;

        //        throw;
        //    }

        //    //throw new NotImplementedException();
        //}
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorExtensions
    {
        public static IApplicationBuilder UseError(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Error>();
        }
    }
}

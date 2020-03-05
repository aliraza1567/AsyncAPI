using AutoMapper;
using Books.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Api.Filters
{
    public class BookResultFilterAttribute: ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var resultFromAction = context.Result as ObjectResult;

            if (resultFromAction?.Value == null || resultFromAction.StatusCode < 200 || resultFromAction.StatusCode >= 300)
            {
                await next();
                return;
            }

            var mapper = (IMapper)context.HttpContext.RequestServices.GetService(typeof(IMapper));
            resultFromAction.Value = mapper.Map<BookModel>(resultFromAction.Value);

            await next();
        }
    }

    public class BooksResultFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var resultFromAction = context.Result as ObjectResult;

            if (resultFromAction?.Value == null || resultFromAction.StatusCode < 200 || resultFromAction.StatusCode >= 300)
            {
                await next();
                return;
            }

            var mapper = (IMapper)context.HttpContext.RequestServices.GetService(typeof(IMapper));
            resultFromAction.Value = mapper.Map<IEnumerable<BookModel>>(resultFromAction.Value);

            await next();
        }
    }
}

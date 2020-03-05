using Books.Api.Filters;
using Books.Application.Books.Queries.AllBooks;
using Books.Application.Books.Queries.BookDetail;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Books.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public IGetAllBooksQuery AllBooksQuery;
        public IGetBookDetailQuery BookDetailQuery;
        public BooksController(IGetAllBooksQuery allBooksQuery, IGetBookDetailQuery bookDetailQuery)
        {
            AllBooksQuery = allBooksQuery;
            BookDetailQuery = bookDetailQuery;
        }

        [HttpGet]
        [BooksResultFilter]
        public async Task<IActionResult> GetBooks()
        {
            var books = await AllBooksQuery.ExecuteAsync();
            return Ok(books);
        }

        [HttpGet]
        [Route("{id}")]
        [BookResultFilter]
        public async Task<IActionResult> GetBook(Guid id)
        {
            var books = await BookDetailQuery.ExecuteAsync(id);
            return Ok(books);
        }
    }
}
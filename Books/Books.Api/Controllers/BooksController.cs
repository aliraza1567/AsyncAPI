using AutoMapper;
using Books.Api.Filters;
using Books.Api.Models;
using Books.Application.Books.Commands;
using Books.Application.Books.Commands.CreateBook;
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
        private readonly ICreateBookCommand _createBookCommand;
        private readonly IMapper _mapper;

        public BooksController(IGetAllBooksQuery allBooksQuery, IGetBookDetailQuery bookDetailQuery, ICreateBookCommand bookCommand, IMapper mapper)
        {
            AllBooksQuery = allBooksQuery;
            BookDetailQuery = bookDetailQuery;
            _createBookCommand = bookCommand;
            _mapper = mapper;
        }

        [HttpGet]
        [BooksResultFilter]
        public async Task<IActionResult> GetBooks()
        {
            var books = await AllBooksQuery.ExecuteAsync();
            return Ok(books);
        }

        [HttpGet]
        [Route("{id}", Name = "GetBook")]
        [BookResultFilter]
        public async Task<IActionResult> GetBook(Guid id)
        {
            var books = await BookDetailQuery.ExecuteAsync(id);
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> InsertBook([FromBody] BookInsertModel model)
        {
            var createBookDto = _mapper.Map<CreateBookDto>(model);
            var bookId = await _createBookCommand.Execute(createBookDto);
            return CreatedAtRoute("GetBook", new {id = bookId}, model);
        }
    }
}
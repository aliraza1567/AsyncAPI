using AutoMapper;
using Books.Application.Books.Queries.BookDetail;
using Books.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Application.Books.Queries.AllBooks
{
    public interface IGetAllBooksQuery
    {
        Task<List<BookDto>> ExecuteAsync();
    }
    public class GetAllBooksQuery: IGetAllBooksQuery, IDisposable
    {
        private IBooksContext _booksContext;
        private readonly IMapper _mapper;

        public GetAllBooksQuery(IBooksContext booksContext, IMapper mapper)
        {
            _booksContext = booksContext;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> ExecuteAsync()
        {
            try
            {
                var books = await _booksContext.Books.Include(book => book.Author).ToListAsync();
                var booksModel = _mapper.Map<List<BookDto>>(books);

                return booksModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;
            if (_booksContext == null)
                return;

            _booksContext.Dispose();
            _booksContext = null;
        }
    }
}

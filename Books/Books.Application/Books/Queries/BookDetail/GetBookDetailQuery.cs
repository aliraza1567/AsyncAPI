using AutoMapper;
using Books.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Books.Application.Books.Queries.BookDetail
{
    public class GetBookDetailQuery: IGetBookDetailQuery, IDisposable
    {
        private IBooksContext _booksContext;
        private readonly IMapper _mapper;

        public GetBookDetailQuery(IBooksContext booksContext, IMapper mapper)
        {
            _booksContext = booksContext;
            _mapper = mapper;
        }
        public async Task<BookDto> ExecuteAsync(Guid id)
        {
            var book = await _booksContext.Books.Include(a => a.Author).FirstOrDefaultAsync(b => b.Id == id);
            var bookModel = _mapper.Map<BookDto>(book);

            return bookModel;
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
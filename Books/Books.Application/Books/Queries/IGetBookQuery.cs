using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Books.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Books.Queries
{
    public interface IGetBookDetailQuery
    {
        Task<BookModel> ExecuteAsync(Guid id);
    }

    public class GetBookDetailQuery: IGetBookDetailQuery, IDisposable
    {
        private IBooksContext _booksContext;
        private readonly IMapper _mapper;

        public GetBookDetailQuery(IBooksContext booksContext, IMapper mapper)
        {
            _booksContext = booksContext;
            _mapper = mapper;
        }
        public async Task<BookModel> ExecuteAsync(Guid id)
        {
            var book = await _booksContext.Books.Include(a => a.Author).FirstOrDefaultAsync(b => b.Id == id);
            var bookModel = _mapper.Map<BookModel>(book);

            return bookModel;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_booksContext != null)
                {
                    _booksContext.Dispose();
                    _booksContext = null;
                }
            }
        }
    }
}

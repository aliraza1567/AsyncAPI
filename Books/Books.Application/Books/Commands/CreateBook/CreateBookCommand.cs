using AutoMapper;
using Books.Application.Interfaces;
using Books.Domain.Books;
using System;
using System.Threading.Tasks;

namespace Books.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : ICreateBookCommand, IDisposable
    {
        private IBooksContext _booksContext;
        private readonly IMapper _mapper;

        public CreateBookCommand(IBooksContext booksContext, IMapper mapper)
        {
            _booksContext = booksContext;
            _mapper = mapper;
        }
        public async Task<Guid> Execute(CreateBookDto createBookDto)
        {
            var book = _mapper.Map<Book>(createBookDto);
            _booksContext.Add(book);

            await _booksContext.SaveChangesAsync();
            return book.Id;
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

using System;
using System.Threading.Tasks;

namespace Books.Application.Books.Queries.BookDetail
{
    public interface IGetBookDetailQuery
    {
        Task<BookDto> ExecuteAsync(Guid id);
    }
}

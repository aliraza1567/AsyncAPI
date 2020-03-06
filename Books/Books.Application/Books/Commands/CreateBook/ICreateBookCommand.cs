using System;
using System.Threading.Tasks;

namespace Books.Application.Books.Commands.CreateBook
{
    public interface ICreateBookCommand
    {
        Task<Guid> Execute(CreateBookDto model);
    }
}
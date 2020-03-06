using AutoMapper;
using Books.Api.Models;
using Books.Application.Authors.Queries;
using Books.Application.Books.Commands;
using Books.Application.Books.Queries.BookDetail;
using Books.Domain.Authors;
using Books.Domain.Books;

namespace Books.Api.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<CreateBookDto, Book>();
            CreateMap<BookInsertModel, CreateBookDto>();
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, BookModel>().ForMember(destination => destination.Author,
                opt => opt.MapFrom(source => $"{source.Author.FirstName} {source.Author.LastName}"));
        }
    }
}

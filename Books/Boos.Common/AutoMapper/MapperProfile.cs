using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Books.Application.Authors.Queries;
using Books.Application.Books.Queries;
using Books.Domain.Authors;
using Books.Domain.Books;

namespace Boos.Common.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AuthorModel, Author>();
            CreateMap<BookModel, Book>();
        }
    }
}

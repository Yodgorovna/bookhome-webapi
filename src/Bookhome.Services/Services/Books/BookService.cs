﻿using Bookhome.Application.Utils;
using Bookhome.Services.Interfaces.Books;
using BookHome.Domain.Entities.Books;
using BookHome.Persistance.Dtos.Books;

namespace Bookhome.Services.Services.Books
{
    public class BookService : IBookService
    {
        public Task<long> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(BookCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long bookId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Book>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetByIdAsync(long bookId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(long bookId, BookUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

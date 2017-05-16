using BookLibrary.Contracts;
using BookLibrary.Ef.Models.Contracts;
using BookLibrary.Pure.Models;
using System.Collections.Generic;

namespace BookLibrary.Data.Services.Contracts
{
    public interface IBookService
    {
        IEnumerable<BookModel> GetAllBooks();

        IEnumerable<IBookModel> GetAllBooksSortedById();

        IEnumerable<IBookModel> GetAllBooksSortedByCreationDate();

        IBookModel GetBookById(int? id);

        int InsertBook(IBookModel bookModel);

        IBookModel UpdateBook(IBookModel bookModel);

        void DeleteBookById(int? id);
    }
}

using BookLibrary.Constants;
using BookLibrary.Contracts;
using BookLibrary.Data.Provider.Contracts;
using BookLibrary.Data.Services.Contracts;
using BookLibrary.Ef.Models;
using BookLibrary.Ef.Models.Contracts;
using BookLibrary.Pure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BookLibrary.Data.Services
{
    public class BookService : IBookService
    {
        private readonly IEfCrudOperatons<Book> bookBaseOperatonsProvider;
        private readonly IEfDbContextSaveChanges dbContextSaveChanges;

        public BookService(IEfCrudOperatons<Book> bookBaseOperatonsProvider, IEfDbContextSaveChanges dbContextSaveChanges)
        {
            if (bookBaseOperatonsProvider == null && dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Book> and EfDbContextSaveChanges", "BookService");
                throw new ArgumentNullException(errorMessage);
            }

            if (bookBaseOperatonsProvider == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Book>", "BookService");
                throw new ArgumentNullException(errorMessage);
            }

            if (dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfDbContextSaveChanges", "BookService");
                throw new ArgumentNullException(errorMessage);
            }

            this.bookBaseOperatonsProvider = bookBaseOperatonsProvider;
            this.dbContextSaveChanges = dbContextSaveChanges;
        }

        public IEnumerable<BookModel> GetAllBooks()
        {
            IList<BookModel> booksToReturn = null;
            IEnumerable<IBook> books = this.bookBaseOperatonsProvider.All.ToList();

            if (books == null)
            {
                string errorMessage = nameof(books);
                throw new ArgumentNullException(errorMessage);
            }

            if (books.Count() > 0)
            {
                booksToReturn = new List<BookModel>();

                foreach (var book in books)
                {
                    BookModel b = new BookModel(book);
                    booksToReturn.Add(b);
                }
            }

            return booksToReturn;
        }

        public IEnumerable<IBookModel> GetAllBooksSortedById()
        {
            IEnumerable<BookModel> booksToReturn = this.GetAllBooks().OrderBy(b => b.Id);

            return booksToReturn;
        }

        // TODO put filter parameter Enum asc desc
        public IEnumerable<IBookModel> GetAllBooksSortedByCreationDate()
        {
            IEnumerable<BookModel> booksToReturn = this.GetAllBooks().OrderBy(b => b.CreationDate);

            return booksToReturn;
        }

        public IBookModel GetBookById(int? id)
        {
            if (id == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.SelectByIdIsPossibleOnlyWithNotNullableParameter, "null");
                throw new ArgumentNullException(errorMessage);
            }
            if (id <= 0)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.SelectByIdIsPossibleOnlyWithPositiveParameter, id);
                throw new ArgumentException(errorMessage);
            }

            BookModel bookToReturn = null;
            IBook book = this.bookBaseOperatonsProvider.SelectById(id);

            if (book == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Book", id);
                throw new ArgumentNullException(errorMessage);
            }

            // TODO create MyDbModelsMapper.Book2BookModel and replace
            bookToReturn = new BookModel(book);

            return bookToReturn;
        }

        public int InsertBook(IBookModel bookModel)
        {
            if (bookModel == null)
            {
                string errorMessage = nameof(bookModel);
                throw new ArgumentNullException(errorMessage);
            }

            // TODO create MyDbModelsMapper.BookModel2Book
            Book bookToInsert = new Book();
            bookToInsert.Title = bookModel.Title;
            bookToInsert.Description = bookModel.Description;
            bookToInsert.Pages = bookModel.Pages;
            bookToInsert.CreationDate = bookModel.CreationDate;

            bookToInsert.AuthorId = bookModel.AuthorId;
            bookToInsert.GenreId = bookModel.GenreId;
            bookToInsert.PictureId = bookModel.PictureId;

            // TODO change to return BookModel
            int newBookId = this.bookBaseOperatonsProvider.Insert(bookToInsert, DatabaseGeneratedOption.Identity);
            this.dbContextSaveChanges.SaveChanges();

            return newBookId;
        }

        public IBookModel UpdateBook(IBookModel bookModel)
        {
            if (bookModel == null)
            {
                string errorMessage = nameof(bookModel);
                throw new ArgumentNullException(errorMessage);
            }

            // TODO create MyDbModelsMapper.BookModel2Book
            Book bookToUpdate = new Book();
            bookToUpdate.Title = bookModel.Title;
            bookToUpdate.Description = bookModel.Description;
            bookToUpdate.Author = (Author)bookModel.Author;
            bookToUpdate.Genre = (Genre)bookModel.Genre;

            this.bookBaseOperatonsProvider.Update(bookToUpdate);
            this.dbContextSaveChanges.SaveChanges();

            return bookModel;
        }

        public void DeleteBookById(int? id)
        {
            if (id == null)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter, "null");
                throw new ArgumentNullException(errorMessage);
            }
            if (id <= 0)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter, id);
                throw new ArgumentException(errorMessage);
            }

            this.bookBaseOperatonsProvider.Delete(id);
            this.dbContextSaveChanges.SaveChanges();
        }
    }
}
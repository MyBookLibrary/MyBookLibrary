using BookLibrary.Contracts;
using BookLibrary.Pure.Models;
using System.Collections.Generic;

namespace BookLibrary.Data.Services.Contracts
{
    public interface IAuthorService
    {
        IEnumerable<AuthorModel> GetAllAuthors();

        IEnumerable<IAuthorModel> GetAllAuthorsSortedById();

        IEnumerable<IAuthorModel> GetAllAuthorsSortedByFirstName();

        IAuthorModel GetAuthorById(int? id);

        int InsertAuthor(IAuthorModel authorModel);

        IAuthorModel UpdateAuthor(IAuthorModel authorModel);

        void DeleteAuthorById(int? id);
    }
}

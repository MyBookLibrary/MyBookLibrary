using BookLibrary.Contracts;
using BookLibrary.Pure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

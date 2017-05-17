using BookLibrary.Constants;
using BookLibrary.Contracts;
using BookLibrary.Data.Provider.Contracts;
using BookLibrary.Data.Services.Contracts;
using BookLibrary.Ef.Models;
using BookLibrary.Ef.Models.Contracts;
using BookLibrary.Pure.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Data.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IEfCrudOperatons<Author> authorBaseOperatonsProvider;
        private readonly IEfDbContextSaveChanges dbContextSaveChanges;

        public AuthorService(IEfCrudOperatons<Author> authorBaseOperatonsProvider, IEfDbContextSaveChanges dbContextSaveChanges)
        {
            if (authorBaseOperatonsProvider == null && dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Author> and EfDbContextSaveChanges", "AuthorService");
                throw new ArgumentNullException(errorMessage);
            }

            if (authorBaseOperatonsProvider == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Author>", "AuthorService");
                throw new ArgumentNullException(errorMessage);
            }

            if (dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfDbContextSaveChanges", "AuthorService");
                throw new ArgumentNullException(errorMessage);
            }

            this.authorBaseOperatonsProvider = authorBaseOperatonsProvider;
            this.dbContextSaveChanges = dbContextSaveChanges;
        }

        public void DeleteAuthorById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorModel> GetAllAuthors()
        {
            IList<AuthorModel> authorsToReturn = null;
            IEnumerable<IAuthor> authors = this.authorBaseOperatonsProvider.All.ToList();

            if (authors == null)
            {
                string errorMessage = nameof(authors);
                throw new ArgumentNullException(errorMessage);
            }

            if (authors.Count() > 0)
            {
                authorsToReturn = new List<AuthorModel>();

                foreach (var author in authors)
                {
                    AuthorModel a = new AuthorModel(author);
                    authorsToReturn.Add(a);
                }
            }

            return authorsToReturn;
        }

        public IEnumerable<IAuthorModel> GetAllAuthorsSortedByFirstName()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAuthorModel> GetAllAuthorsSortedById()
        {
            throw new NotImplementedException();
        }

        public IAuthorModel GetAuthorById(int? id)
        {
            throw new NotImplementedException();
        }

        public int InsertAuthor(IAuthorModel authorModel)
        {
            throw new NotImplementedException();
        }

        public IAuthorModel UpdateAuthor(IAuthorModel authorModel)
        {
            throw new NotImplementedException();
        }
    }
}

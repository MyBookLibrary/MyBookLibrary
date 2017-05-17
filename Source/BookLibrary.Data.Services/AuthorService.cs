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
            // TODO implement or delete
            throw new NotImplementedException();
        }

        public IEnumerable<IAuthorModel> GetAllAuthorsSortedById()
        {
            // TODO implement or delete
            throw new NotImplementedException();
        }

        public IAuthorModel GetAuthorById(int? id)
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

            IAuthorModel authorToReturn = null;
            IAuthor author = this.authorBaseOperatonsProvider.SelectById(id);

            if (author == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Author", id);
                throw new ArgumentNullException(errorMessage);
            }

            // TODO create MyDbModelsMapper.Author2AuthorModel and replace
            authorToReturn = new AuthorModel(author);

            return authorToReturn;
        }

        public int InsertAuthor(IAuthorModel authorModel)
        {
            if (authorModel == null)
            {
                string errorMessage = nameof(authorModel);
                throw new ArgumentNullException(errorMessage);
            }

            // TODO refactore when model mapper created - AuthorModel2Author
            Author authorToInsert = new Author();
            authorToInsert.FirstName = authorModel.FirstName;
            authorToInsert.LastName = authorModel.LastName;

            int insertedAuthorId = this.authorBaseOperatonsProvider.Insert(authorToInsert);
            this.dbContextSaveChanges.SaveChanges();

            return insertedAuthorId;
        }

        public IAuthorModel UpdateAuthor(IAuthorModel authorModel)
        {
            if (authorModel == null)
            {
                string errorMessage = nameof(authorModel);
                throw new ArgumentNullException(errorMessage);
            }

            // TODO refactore when model mapper created - AuthorModel2Author
            Author authorToUpdate = new Author();
            authorToUpdate.Id = authorModel.Id;
            authorToUpdate.FirstName = authorModel.FirstName;
            authorToUpdate.LastName = authorModel.LastName;

            this.authorBaseOperatonsProvider.Update(authorToUpdate);
            this.dbContextSaveChanges.SaveChanges();

            return authorModel;
        }

        public void DeleteAuthorById(int? id)
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

            this.authorBaseOperatonsProvider.Delete(id);
            this.dbContextSaveChanges.SaveChanges();
        }
    }
}

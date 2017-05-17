using BookLibrary.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary.Contracts;
using BookLibrary.Pure.Models;
using BookLibrary.Data.Provider.Contracts;
using BookLibrary.Ef.Models;
using BookLibrary.Constants;
using BookLibrary.Ef.Models.Contracts;

namespace BookLibrary.Data.Services
{
    public class GenreService : IGenreService
    {
        private readonly IEfCrudOperatons<Genre> genreBaseOperatonsProvider;
        private readonly IEfDbContextSaveChanges dbContextSaveChanges;

        public GenreService(IEfCrudOperatons<Genre> genreBaseOperatonsProvider, IEfDbContextSaveChanges dbContextSaveChanges)
        {
            if (genreBaseOperatonsProvider == null && dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Genre> and EfDbContextSaveChanges", "GenreService");
                throw new ArgumentNullException(errorMessage);
            }

            if (genreBaseOperatonsProvider == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Genre>", "GenreService");
                throw new ArgumentNullException(errorMessage);
            }

            if (dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfDbContextSaveChanges", "GenreService");
                throw new ArgumentNullException(errorMessage);
            }

            this.genreBaseOperatonsProvider = genreBaseOperatonsProvider;
            this.dbContextSaveChanges = dbContextSaveChanges;
        }

        public IEnumerable<GenreModel> GetAllGenres()
        {
            IList<GenreModel> genresToReturn = null;
            IEnumerable<IGenre> genres = this.genreBaseOperatonsProvider.All.ToList();

            if (genres == null)
            {
                string errorMessage = nameof(genres);
                throw new ArgumentNullException(errorMessage);
            }

            if (genres.Count() > 0)
            {
                genresToReturn = new List<GenreModel>();

                foreach (var genre in genres)
                {
                    GenreModel a = new GenreModel(genre);
                    genresToReturn.Add(a);
                }
            }

            return genresToReturn;
        }

        public IEnumerable<IGenreModel> GetAllGenresSortedById()
        {
            // TODO implement or delete
            throw new NotImplementedException();
        }

        public IEnumerable<IGenreModel> GetAllGenresSortedByName()
        {
            // TODO implement or delete
            throw new NotImplementedException();
        }

        public IGenreModel GetGenreById(int? id)
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

            IGenreModel genreToReturn = null;
            IGenre genre = this.genreBaseOperatonsProvider.SelectById(id);

            if (genre == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Genre", id);
                throw new ArgumentNullException(errorMessage);
            }

            // TODO create MyDbModelsMapper.Genre2GenreModel and replace
            genreToReturn = new GenreModel(genre);

            return genreToReturn;
        }

        public int InsertGenre(IGenreModel genreModel)
        {
            if (genreModel == null)
            {
                string errorMessage = nameof(genreModel);
                throw new ArgumentNullException(errorMessage);
            }

            // TODO refactore when model mapper created - GenreModel2Genre
            Genre genreToInsert = new Genre();
            genreToInsert.Name = genreModel.Name;

            int insertedGenreId = this.genreBaseOperatonsProvider.Insert(genreToInsert);
            this.dbContextSaveChanges.SaveChanges();

            return insertedGenreId;
        }

        public IGenreModel UpdateGenre(IGenreModel genreModel)
        {
            if (genreModel == null)
            {
                string errorMessage = nameof(genreModel);
                throw new ArgumentNullException(errorMessage);
            }

            // TODO refactore when model mapper created - GenreModel2Genre
            Genre genreToUpdate = new Genre();
            genreToUpdate.Id = genreModel.Id;
            genreToUpdate.Name = genreModel.Name;

            this.genreBaseOperatonsProvider.Update(genreToUpdate);
            this.dbContextSaveChanges.SaveChanges();

            return genreModel;
        }

        public void DeleteGenreById(int? id)
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

            this.genreBaseOperatonsProvider.Delete(id);
            this.dbContextSaveChanges.SaveChanges();
        }
    }
}

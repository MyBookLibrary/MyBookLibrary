using BookLibrary.Contracts;
using BookLibrary.Pure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Services.Contracts
{
    public interface IGenreService
    {
        IEnumerable<GenreModel> GetAllGenres();

        IEnumerable<IGenreModel> GetAllGenresSortedById();

        IEnumerable<IGenreModel> GetAllGenresSortedByName();

        IGenreModel GetGenreById(int? id);

        int InsertGenre(IGenreModel genreModel);

        IGenreModel UpdateGenre(IGenreModel genreModel);

        void DeleteGenreById(int? id);
    }
}

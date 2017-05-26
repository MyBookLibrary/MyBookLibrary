using BookLibrary.Contracts;
using BookLibrary.Ef.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Pure.Models
{
    public class GenreModel : IGenreModel, IHasIntId
    {
        public GenreModel()
        {
        }

        // This constructor is used for DbModel 2 PureModel mapping
        // IGenre is the Ef model interface
        public GenreModel(IGenre genre)
        {
            this.Id = genre.Id;
            this.Name = genre.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}

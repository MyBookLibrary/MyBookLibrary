using BookLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Ef.Models.Contracts
{
    public interface IBook : IHasIntId
    {
        int Id { get; set; }

        string Title { get; set; }

        string Description { get; set; }

        int Pages { get; set; }

        DateTime CreationDate { get; set; }

        int PictureId { get; set; }

        int AuthorId { get; set; }

        int GenreId { get; set; }

        Author Author { get; set; }

        Genre Genre { get; set; }
    }
}

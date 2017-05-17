using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Contracts
{
    public interface IBookModel : IHasIntId, IHasPicture
    {
        string Title { get; set; }

        string Description { get; set; }

        int Pages { get; set; }

        DateTime CreationDate { get; set; }

        int AuthorId { get; set; }

        int GenreId { get; set; }

        int PictureId { get; set; }

        IAuthorModel Author { get; set; }

        IGenreModel Genre { get; set; }
    }
}

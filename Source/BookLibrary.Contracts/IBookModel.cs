using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Contracts
{
    public interface IBookModel : IHasIntId
    {
        string Title { get; set; }

        string Description { get; set; }

        DateTime CreationDate { get; set; }

        IAuthorModel Author { get; set; }

        IGenreModel Genre { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Contracts
{
    public interface IBook
    {
        string Title { get; set; }

        string Description { get; set; }

        IAuthor Author { get; set; }

        IGenre Genre { get; set; }
    }
}

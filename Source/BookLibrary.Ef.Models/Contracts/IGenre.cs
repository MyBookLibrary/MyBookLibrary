using BookLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Ef.Models.Contracts
{
    public interface IGenre : IHasIntId
    {
        int Id { get; set; }

        string Name { get; set; }

        ICollection<Book> Books { get; set; }
    }
}

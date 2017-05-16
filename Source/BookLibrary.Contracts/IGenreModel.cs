using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Contracts
{
    public interface IGenreModel : IHasIntId
    {
        string Name { get; set; }
    }
}

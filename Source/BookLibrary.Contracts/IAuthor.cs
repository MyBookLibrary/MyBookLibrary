using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Contracts
{
    public interface IAuthor
    {
        string FirstName { get; set; }

        string LastName { get; set; }
    }
}

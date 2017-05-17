using BookLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Ef.Models.Contracts
{
    public interface IPicture : IHasIntId
    {
        int Id { get; set; }

        Nullable<int> Width { get; set; }

        Nullable<int> Height { get; set; }

        Nullable<int> SizeMb { get; set; }

        string Url { get; set; }
    }
}

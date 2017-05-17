using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Contracts
{
    public interface IPictureModel : IHasIntId
    {
        string Name { get; set; }

        Nullable<int> Width { get; set; }

        Nullable<int> Height { get; set; }

        Nullable<int> SizeMb { get; set; }

        string Url { get; set; }
    }
}

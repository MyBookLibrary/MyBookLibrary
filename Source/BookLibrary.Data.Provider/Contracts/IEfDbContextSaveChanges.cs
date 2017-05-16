using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Provider.Contracts
{
    public interface IEfDbContextSaveChanges
    {
        int SaveChanges();
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Provider.Contracts
{
    public interface IEfStoredProcedures<T> where T : class
    {
        void ExecuteStoredProcedure(string spName,
            SqlParameter sqlParam1,
            SqlParameter sqlParam2,
            SqlParameter sqlParam3,
            SqlParameter sqlParam4,
            SqlParameter sqlParam5,
            SqlParameter sqlParam6,
            SqlParameter sqlParam7);
    }
}

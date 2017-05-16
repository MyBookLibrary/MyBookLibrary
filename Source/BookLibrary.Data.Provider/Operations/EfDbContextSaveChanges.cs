using BookLibrary.Constants;
using BookLibrary.Data.Provider.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Provider.Operations
{
    public class EfDbContextSaveChanges : IEfDbContextSaveChanges
    {
        private readonly IBookLibraryDbContext context;

        public EfDbContextSaveChanges(IBookLibraryDbContext context)
        {
            if (context == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "IBookLibraryDbContext", "EfDbContextSaveChanges");
                throw new ArgumentNullException(errorMessage);
            }

            this.context = context;
        }

        public int SaveChanges()
        {
            int saveChangesResult = this.context.SaveChanges();

            return saveChangesResult;
        }
    }
}

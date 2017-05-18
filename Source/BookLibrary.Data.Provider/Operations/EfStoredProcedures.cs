//using BookLibrary.Constants;
//using BookLibrary.Data.Provider.Contracts;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BookLibrary.Data.Provider.Operations
//{
//    public class EfStoredProcedures<T> : IEfStoredProcedures<T> where T : class
//    {
//        private readonly IBookLibraryDbContext context;
//        //private readonly DbSet<T> dbSet;
//        private readonly Database db;

//        public EfStoredProcedures(IBookLibraryDbContext context)
//        {
//            if (context == null)
//            {
//                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "MyWoodenHouseDbContext", "Data CategoryService");
//                throw new ArgumentNullException(errorMessage);
//            }

//            this.context = context;
//            this.db = this.context.Db;
//            //this.dbSet = this.context.Set<T>();

//            //if (this.dbSet == null)
//            //{
//            //    string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.DbContextDoesNotContainDbSet, typeof(T).Name);
//            //    throw new ArgumentNullException(errorMessage);
//            //}
//        }

//        public IBookLibraryDbContext Context
//        {
//            get
//            {
//                return this.context;
//            }
//        }

//        //public DbSet<T> DbSet
//        //{
//        //    get
//        //    {
//        //        return this.dbSet;
//        //    }
//        //}

//        public Database Db
//        {
//            get
//            {
//                return this.db;
//            }
//        }

//        public virtual IQueryable<T> ExecuteStoredProcedure(string spName, SqlParameter sqlParam1)
//        {
//            //context.Database.SqlQuery<myEntityType>(
//            //    "mySpName @param1, @param2, @param3",
//            //    new SqlParameter("param1", param1),
//            //    new SqlParameter("param2", param2),
//            //    new SqlParameter("param3", param3)
//            //);
//            // Sourcees:
//            // http://stackoverflow.com/questions/4873607/how-to-use-dbcontext-database-sqlquerytelementsql-params-with-stored-proced
//            // https://msdn.microsoft.com/en-US/data/jj592907

//            string param1Key = "@param1";
//            string sqlCommand = "EXECUTE [dbo].[" + spName + "] " + param1Key + " ";
//            //SqlParameter sqlParam1 = new SqlParameter(param1Key, SqlDbType.Int);
//            //sqlParam1.Value = param1Value;

//            ICollection<T> commandResult = this.Db.SqlQuery<T>(sqlCommand, sqlParam1).ToList<T>();

//            return commandResult.AsQueryable<T>();
//        }

//        public void ExecuteStoredProcedure(string spName, SqlParameter sqlParam1, SqlParameter sqlParam2, SqlParameter sqlParam3, SqlParameter sqlParam4, SqlParameter sqlParam5, SqlParameter sqlParam6, SqlParameter sqlParam7)
//        {
//            StringBuilder sqlCommand = new StringBuilder();

//            sqlCommand.Append("EXECUTE [dbo].[" + spName + "]");
//            sqlCommand.Append(" " + sqlParam1.ParameterName);
//            sqlCommand.Append(", " + sqlParam2.ParameterName);
//            sqlCommand.Append(", " + sqlParam3.ParameterName);
//            sqlCommand.Append(", " + sqlParam4.ParameterName);
//            sqlCommand.Append(", " + sqlParam5.ParameterName);
//            sqlCommand.Append(", " + sqlParam6.ParameterName);
//            sqlCommand.Append(", " + sqlParam7.ParameterName);

//            this.Db.SqlQuery<T>(sqlCommand.ToString(), sqlParam1, sqlParam2, sqlParam3, sqlParam4, sqlParam5, sqlParam6, sqlParam7);
//        }
//    }
//}

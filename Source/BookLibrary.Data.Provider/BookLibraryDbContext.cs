using BookLibrary.Data.Provider.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary.Ef.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Data.Provider
{
    public class BookLibraryDbContext : DbContext, IBookLibraryDbContext
    {
        public BookLibraryDbContext() 
            : base("name=BookLibraryDbContextConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public IDbSet<Author> Author { get; set; }

        public IDbSet<Book> Book { get; set; }

        public IDbSet<Genre> Genre { get; set; }

        public EntityState GetEntityState(object entity)
        {
            EntityState stateToReturn = Entry(entity).State;

            return stateToReturn;
        }

        public void SetEntityState(object entity, EntityState state)
        {
            Entry(entity).State = state;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Entity Framework CTP 4. “Cannot insert the value NULL into column” -Even though there is no NULL value
            //http://stackoverflow.com/questions/4444407/entity-framework-ctp-4-cannot-insert-the-value-null-into-column-even-though/5338384#5338384
            //Have you tried explicitly specifying the StoreGeneratedPattern?
            // modelBuilder.Entity<BOB>().HasKey(p => p.Id).Property(p => p.Id).HasDatabaseGenerationOption(DatabaseGenerationOption.None); 
            // modelBuilder.Entity<BOB>().ToTable("BOB");
            modelBuilder.Entity<Genre>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Genre>().ToTable("Genres");

            base.OnModelCreating(modelBuilder);
        }
    }
}

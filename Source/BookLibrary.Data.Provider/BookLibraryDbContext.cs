using BookLibrary.Data.Provider.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary.Ef.Models;
using System.ComponentModel.DataAnnotations.Schema;
using BookLibrary.Ef.Models.Contracts;

namespace BookLibrary.Data.Provider
{
    public class BookLibraryDbContext : DbContext, IBookLibraryDbContext
    {
        public BookLibraryDbContext() 
            : base("name=BookLibraryDbContextConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public Database Db
        {
            get
            {
                return base.Database;
            }
        }

        public IDbSet<Author> Author { get; set; }

        public IDbSet<Genre> Genre { get; set; }
        
        public IDbSet<Book> Book { get; set; }
        
        public IDbSet<Picture> Picture { get; set; }

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
            // The entity type <type> is not part of the model for the current context
            // Current error was "The entity type IBook is not part of the model for the current context."
            // http://stackoverflow.com/questions/20688922/the-entity-type-type-is-not-part-of-the-model-for-the-current-context
            modelBuilder.Entity<Book>()
                .HasKey(k => k.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);         
            modelBuilder.Entity<Book>().ToTable("Books");

            modelBuilder.Entity<Picture>()
                .HasKey(k => k.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Picture>().ToTable("Pictures");

            // Entity Framework CTP 4. “Cannot insert the value NULL into column” -Even though there is no NULL value
            // http://stackoverflow.com/questions/4444407/entity-framework-ctp-4-cannot-insert-the-value-null-into-column-even-though/5338384#5338384
            // Have you tried explicitly specifying the StoreGeneratedPattern?
            // modelBuilder.Entity<BOB>().HasKey(p => p.Id).Property(p => p.Id).HasDatabaseGenerationOption(DatabaseGenerationOption.None); 
            // modelBuilder.Entity<BOB>().ToTable("BOB");
            modelBuilder.Entity<Author>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Author>().ToTable("Authors");

            modelBuilder.Entity<Genre>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Genre>().ToTable("Genres");

            base.OnModelCreating(modelBuilder);
        }
    }
}

using BookLibrary.Contracts;
using BookLibrary.Ef.Models;
using BookLibrary.Ef.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Provider.Contracts
{
    public interface IBookLibraryDbContext : IDisposable, IEfDbContextSaveChanges
    {
        IDbSet<Genre> Genre { get; set; }

        IDbSet<Author> Author { get; set; }

        IDbSet<Book> Book { get; set; }

        IDbSet<Picture> Picture { get; set; }

        EntityState GetEntityState(object entity);

        void SetEntityState(object entity, EntityState state);

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}

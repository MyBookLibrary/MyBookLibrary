﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookLibrary.Ef.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BookLibraryEntities : DbContext
    {
        public BookLibraryEntities()
            : base("name=BookLibraryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
    
        public virtual int usp_InsertBook(string title, string description, Nullable<int> pages, Nullable<System.DateTime> creationDate, Nullable<int> authorId, Nullable<int> genreId, Nullable<int> pictureId)
        {
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var pagesParameter = pages.HasValue ?
                new ObjectParameter("Pages", pages) :
                new ObjectParameter("Pages", typeof(int));
    
            var creationDateParameter = creationDate.HasValue ?
                new ObjectParameter("CreationDate", creationDate) :
                new ObjectParameter("CreationDate", typeof(System.DateTime));
    
            var authorIdParameter = authorId.HasValue ?
                new ObjectParameter("AuthorId", authorId) :
                new ObjectParameter("AuthorId", typeof(int));
    
            var genreIdParameter = genreId.HasValue ?
                new ObjectParameter("GenreId", genreId) :
                new ObjectParameter("GenreId", typeof(int));
    
            var pictureIdParameter = pictureId.HasValue ?
                new ObjectParameter("PictureId", pictureId) :
                new ObjectParameter("PictureId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_InsertBook", titleParameter, descriptionParameter, pagesParameter, creationDateParameter, authorIdParameter, genreIdParameter, pictureIdParameter);
        }
    }
}

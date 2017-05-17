using BookLibrary.Contracts;
using BookLibrary.Ef.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Pure.Models
{
    public class BookModel : IBookModel, IHasIntId
    {
        public BookModel()
        {
        }

        // This constructor is used for DbModel 2 PureModel papping
        // IBook is the Ef model interface
        public BookModel(IBook book)
        {
            this.Id = book.Id;
            this.Title = book.Title;
            this.Description = book.Description;
            this.Pages = book.Pages;
            this.CreationDate = book.CreationDate;
            // TODO Factory Extract ???
            this.Author = new AuthorModel(book.Author);
            // TODO Factory Extract ???
            this.Genre = new GenreModel(book.Genre);            
        }

        // This constructor is used for DbModel 2 PureModel papping
        // IBook is the Ef model interface
        public BookModel(IBook book, IPicture picture)
        {
            this.Id = book.Id;
            this.Title = book.Title;
            this.Description = book.Description;
            this.Pages = book.Pages;
            this.CreationDate = book.CreationDate;
            // TODO Factory Extract ???
            this.Author = new AuthorModel(book.Author);
            // TODO Factory Extract ???
            this.Genre = new GenreModel(book.Genre);

            this.Picture = new PictureModel(picture);
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Pages { get; set; }

        public DateTime CreationDate { get; set; }

        public IAuthorModel Author { get; set; }
        
        public IGenreModel Genre { get; set; }

        public IPictureModel Picture { get; set; }

        public int AuthorId { get; set; }

        public int GenreId { get; set; }

        public int PictureId { get; set; }
    }
}

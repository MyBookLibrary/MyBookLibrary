using BookLibrary.Constants.Models;
using BookLibrary.Contracts;
using BookLibrary.ViewModels.Author;
using BookLibrary.ViewModels.Genre;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.ViewModels.Book
{
    public class BookMainViewModel
    {
        public BookMainViewModel()
        {
        }

        public BookMainViewModel(IBookModel bookModel)
        {
            this.Id = bookModel.Id;
            this.Title = bookModel.Title;
            this.Description = bookModel.Description;
            this.Pages = bookModel.Pages;
            this.CreationDate = bookModel.CreationDate;

            // TODO Factory Extract ???
            if (bookModel.Author != null)
            {
                if (bookModel.Author.Id > 0)
                {
                    this.Author = new AuthorMainViewModel(bookModel.Author.Id, bookModel.Author.FirstName, bookModel.Author.LastName);
                }
            }

            // TODO Factory Extract ???
            if (bookModel.Genre != null)
            {
                if (bookModel.Genre.Id > 0)
                {
                    this.Genre = new GenreMainViewModel(bookModel.Genre.Id, bookModel.Genre.Name);

                }
            }
        }

        public BookMainViewModel(IBookModel bookModel, IPictureModel pictureModel)
        {
            this.Id = bookModel.Id;
            this.Title = bookModel.Title;
            this.Description = bookModel.Description;
            this.Pages = bookModel.Pages;
            this.CreationDate = bookModel.CreationDate;

            // TODO Factory Extract ???
            if (bookModel.Author != null)
            {
                if (bookModel.Author.Id > 0)
                {
                    this.Author = new AuthorMainViewModel(bookModel.Author.Id, bookModel.Author.FirstName, bookModel.Author.LastName);
                }
            }

            // TODO Factory Extract ???
            if (bookModel.Genre != null)
            {
                if (bookModel.Genre.Id > 0)
                {
                    this.Genre = new GenreMainViewModel(bookModel.Genre.Id, bookModel.Genre.Name);

                }
            }
            
            this.Picture = pictureModel;
        }

        [Required]
        [Display(Name = "Id")]
        [Range(Consts.Book.Id.MinValue, Consts.Book.Id.MaxValue, ErrorMessage = Consts.Book.Id.ErrorMessage)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        [MaxLength(Consts.Book.Title.MaxLength, ErrorMessage = Consts.Book.Title.ErrorMessageMaxLength)]
        [MinLength(Consts.Book.Title.MinLength, ErrorMessage = Consts.Book.Title.ErrorMessageMinLength)]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [MaxLength(Consts.Book.Description.MaxLength, ErrorMessage = Consts.Book.Description.ErrorMessageMaxLength)]
        [MinLength(Consts.Book.Description.MinLength, ErrorMessage = Consts.Book.Description.ErrorMessageMinLength)]
        public string Description { get; set; }

        [Display(Name = "Pages")]
        [Range(Consts.Book.Pages.MinValue, Consts.Book.Pages.MaxValue, ErrorMessage = Consts.Book.Pages.ErrorMessage)]
        public int Pages { get; set; }

        [Required]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Author")]
        public AuthorMainViewModel Author { get; set; }

        [Display(Name = "Genre")]
        public GenreMainViewModel Genre { get; set; }

        [Display(Name = "Picture")]
        public IPictureModel Picture { get; set; }

        [Display(Name = "Book")]
        public string ModelName { get; set; }
    }
}
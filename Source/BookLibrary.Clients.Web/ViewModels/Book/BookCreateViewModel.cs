using BookLibrary.Constants.Models;
using BookLibrary.Contracts;
using BookLibrary.ViewModels.Author;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookLibrary.ViewModels.Book
{
    public class BookCreateViewModel
    {
        public BookCreateViewModel()
        {
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

        [Display(Name = "Selected Author Id")]
        public int SelectedAuthorId { get; set; }

        [Display(Name = "Select Author")]
        public IEnumerable<SelectListItem> AuthorSelectList { get; set; }

        [Display(Name = "Selected Genre Id")]
        public int SelectedGenreId { get; set; }

        [Display(Name = "Select Genre")]
        public IEnumerable<SelectListItem> GenreSelectList { get; set; }

        [Display(Name = "Picture Url")]
        [MaxLength(Consts.Picture.Url.MaxLength, ErrorMessage = Consts.Picture.Url.ErrorMessageMaxLength)]
        [MinLength(Consts.Picture.Url.MinLength, ErrorMessage = Consts.Picture.Url.ErrorMessageMinLength)]
        public string PictureUrl { get; set; }

        [Display(Name = "Create/Edit Book")]
        public string ModelName { get; set; }
    }
}
using BookLibrary.Constants.Models;
using BookLibrary.ViewModels.Author;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookLibrary.ViewModels
{
    public class BookCreateViewModel
    {
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

        [Required]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Select Author")]
        public int SelectedAuthorId { get; set; }
        public IEnumerable<SelectListItem> AuthorSelectList { get; set; }

        [Display(Name = "Select Genre")]
        public int SelectedGenreId { get; set; }
        public IEnumerable<SelectListItem> GenreSelectList { get; set; }

        [Display(Name ="Create Book")]
        public string ModelName { get; set; }
    }
}
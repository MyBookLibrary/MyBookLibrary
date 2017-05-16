using BookLibrary.Constants.Models;
using BookLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookLibrary.ViewModels
{
    public class BookMainViewModel
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

        //[Required]
        //[Display(Name = "AuthorId")]
        //public int AuthorId { get; set; }

        //[Required]
        //[Display(Name = "GenreId")]
        //public int GenreId { get; set; }

        [Display(Name = "Author")]
        public AuthorMainViewModel Author { get; set; }

        [Display(Name = "Genre")]
        public GenreMainViewModel Genre { get; set; }

    }
}
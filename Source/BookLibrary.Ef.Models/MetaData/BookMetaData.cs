using BookLibrary.Constants.Models;
using BookLibrary.Ef.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Ef.Models.MetaData
{
    public class BookMetaData : IBook
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
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

        [Required]
        [Display(Name = "AuthorId")]
        public int? AuthorId { get; set; }

        [Required]
        [Display(Name = "GenreId")]
        public int? GenreId { get; set; }

        [Required]
        [Display(Name = "PictureId")]
        public int? PictureId { get; set; }

        public Author Author { get; set; }

        public Genre Genre { get; set; }

        public Picture Picture { get; set; }
    }
}

using BookLibrary.Constants.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookLibrary.ViewModels.Author
{
    public class AuthorMainViewModel
    {
        [Required]
        [Display(Name = "Id")]
        [Range(Consts.Author.Id.MinValue, Consts.Author.Id.MaxValue, ErrorMessage = Consts.Author.Id.ErrorMessage)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(Consts.Author.FirstName.MaxLength, ErrorMessage = Consts.Author.FirstName.ErrorMessageMaxLength)]
        [MinLength(Consts.Author.FirstName.MinLength, ErrorMessage = Consts.Author.FirstName.ErrorMessageMinLength)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(Consts.Author.LastName.MaxLength, ErrorMessage = Consts.Author.LastName.ErrorMessageMaxLength)]
        [MinLength(Consts.Author.LastName.MinLength, ErrorMessage = Consts.Author.LastName.ErrorMessageMinLength)]
        public string LastName { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}
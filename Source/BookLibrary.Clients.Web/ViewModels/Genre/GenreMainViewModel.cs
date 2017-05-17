using BookLibrary.Constants.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookLibrary.ViewModels.Genre
{
    public class GenreMainViewModel
    {
        public GenreMainViewModel()
        {
        }

        public GenreMainViewModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;   
        }

        [Required]
        [Display(Name = "Id")]
        [Range(Consts.Genre.Id.MinValue, Consts.Genre.Id.MaxValue, ErrorMessage = Consts.Genre.Id.ErrorMessage)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(Consts.Genre.Name.MaxLength, ErrorMessage = Consts.Genre.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.Genre.Name.MinLength, ErrorMessage = Consts.Genre.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        public string ModelName { get; set; }
    }
}
﻿using BookLibrary.Constants.Models;
using BookLibrary.Ef.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Ef.Models.MetaData
{
    public class BookMetaData : IBook
    {
        [Key]
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
        [Display(Name = "AuthorId")]
        public int AuthorId { get; set; }

        [Required]
        [Display(Name = "GenreId")]
        public int GenreId { get; set; }

        public Author Author { get; set; }

        public Genre Genre { get; set; }

    }
}
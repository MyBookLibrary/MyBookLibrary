using BookLibrary.Constants.Models;
using BookLibrary.Ef.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Ef.Models.MetaData
{
    public class GenreMetaData : IGenre
    {
        [Key]
        [Display(Name = "Id")]
        [Range(Consts.Genre.Id.MinValue, Consts.Genre.Id.MaxValue, ErrorMessage = Consts.Genre.Id.ErrorMessage)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(Consts.Genre.Name.MaxLength, ErrorMessage = Consts.Genre.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.Genre.Name.MinLength, ErrorMessage = Consts.Genre.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}

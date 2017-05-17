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

    public class PictureMetaData : IPicture
    {
        [Key]
        [Display(Name = "Id")]
        [Range(Consts.Picture.Id.MinValue, Consts.Picture.Id.MaxValue, ErrorMessage = Consts.Picture.Id.ErrorMessage)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(Consts.Picture.Name.MaxLength, ErrorMessage = Consts.Picture.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.Picture.Name.MinLength, ErrorMessage = Consts.Picture.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        [Display(Name = "Width")]
        [Range(Consts.Picture.Width.MinValue, Consts.Picture.Width.MaxValue, ErrorMessage = Consts.Picture.Width.ErrorMessage)]
        public int? Width { get; set; }

        [Display(Name = "Height")]
        [Range(Consts.Picture.Height.MinValue, Consts.Picture.Height.MaxValue, ErrorMessage = Consts.Picture.Height.ErrorMessage)]
        public int? Height { get; set; }

        [Display(Name = "SizeMb")]
        [Range(Consts.Picture.SizeMb.MinValue, Consts.Picture.SizeMb.MaxValue, ErrorMessage = Consts.Picture.SizeMb.ErrorMessage)]
        public int? SizeMb { get; set; }

        [Display(Name = "Url")]
        [MaxLength(Consts.Picture.Url.MaxLength, ErrorMessage = Consts.Picture.Url.ErrorMessageMaxLength)]
        [MinLength(Consts.Picture.Url.MinLength, ErrorMessage = Consts.Picture.Url.ErrorMessageMinLength)]
        public string Url { get; set; }
    }
}

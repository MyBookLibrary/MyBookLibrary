using BookLibrary.Constants.Models;
using BookLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookLibrary.ViewModels.Picture
{
    public class PictureMainViewModel
    {
        public PictureMainViewModel()
        {
        }

        public PictureMainViewModel(IPictureModel pictureModel)
        {
            this.Id = pictureModel.Id;
            this.Name = pictureModel.Name;
            this.Width = pictureModel.Width;
            this.Height = pictureModel.Height;
            this.SizeMb = pictureModel.SizeMb;
            this.Url = pictureModel.Url;
        }

        public PictureMainViewModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public PictureMainViewModel(int id, string name, int width, int height)
        {
            this.Id = id;
            this.Name = name;
            this.Width = width;
            this.Height = height;
        }

        public PictureMainViewModel(int id, string name, int width, int height, int sizeMb)
        {
            this.Id = id;
            this.Name = name;
            this.Width = width;
            this.Height = height;
            this.SizeMb = sizeMb;
        }

        public PictureMainViewModel(int id, string name, int width, int height, int sizeMb, string url)
        {
            this.Id = id;
            this.Name = name;
            this.Width = width;
            this.Height = height;
            this.SizeMb = sizeMb;
            this.Url = url;
        }

        [Required]
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
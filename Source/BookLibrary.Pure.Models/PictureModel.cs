using BookLibrary.Contracts;
using BookLibrary.Ef.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Pure.Models
{
    public class PictureModel : IPictureModel, IHasIntId
    {
        public PictureModel()
        {
        }

        // This constructor is used for DbModel 2 PureModel papping
        // IPicture is the Ef model interface
        public PictureModel(IPicture picture)
        {
            this.Id = picture.Id;
            this.Name = picture.Name;
            this.Width = picture.Width;
            this.Height = picture.Height;
            this.SizeMb = picture.SizeMb;
            this.Url = picture.Url;
        }

        public PictureModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public PictureModel(int id, string name, int width, int height)
        {
            this.Id = id;
            this.Name = name;
            this.Width = width;
            this.Height = height;
        }

        public PictureModel(int id, string name, int width, int height, int sizeMb)
        {
            this.Id = id;
            this.Name = name;
            this.Width = width;
            this.Height = height;
            this.SizeMb = sizeMb;
        }

        public PictureModel(int id, string name, int width, int height, int sizeMb, string url)
        {
            this.Id = id;
            this.Name = name;
            this.Width = width;
            this.Height = height;
            this.SizeMb = sizeMb;
            this.Url = url;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public int? SizeMb { get; set; }

        public string Url { get; set; }
    }
}

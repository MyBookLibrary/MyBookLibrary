using BookLibrary.Contracts;
using BookLibrary.Pure.Models;
using System.Collections.Generic;

namespace BookLibrary.Data.Services.Contracts
{
    public interface IPictureService
    {
        IEnumerable<PictureModel> GetAllPictures();

        IEnumerable<IPictureModel> GetAllPicturesSortedById();

        IEnumerable<IPictureModel> GetAllPicturesSortedByFirstName();

        IPictureModel GetPictureById(int? id);

        int InsertPicture(IPictureModel pictureModel);

        IPictureModel UpdatePicture(IPictureModel pictureModel);

        void DeletePictureById(int? id);
    }
}

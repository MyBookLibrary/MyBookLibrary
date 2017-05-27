using BookLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Services.Contracts
{
    public interface IPictureService
    {
        IEnumerable<IPictureModel> GetAllPictures();

        IEnumerable<IPictureModel> GetAllPicturesSortedById();

        IEnumerable<IPictureModel> GetAllPicturesSortedByFirstName();

        IPictureModel GetPictureById(int? id);

        int InsertPicture(IPictureModel pictureModel);

        IPictureModel UpdatePicture(IPictureModel pictureModel);

        void DeletePictureById(int? id);
    }
}

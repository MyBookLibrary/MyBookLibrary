using BookLibrary.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary.Contracts;
using BookLibrary.Constants;
using BookLibrary.Ef.Models;
using BookLibrary.Data.Provider.Contracts;
using BookLibrary.Pure.Models;
using BookLibrary.Ef.Models.Contracts;

namespace BookLibrary.Data.Services
{
    public class PictureService : IPictureService
    {
        private readonly IEfCrudOperatons<Picture> pictureBaseOperatonsProvider;
        private readonly IEfDbContextSaveChanges dbContextSaveChanges;

        public PictureService(IEfCrudOperatons<Picture> pictureBaseOperatonsProvider, IEfDbContextSaveChanges dbContextSaveChanges)
        {
            if (pictureBaseOperatonsProvider == null && dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Picture> and EfDbContextSaveChanges", "PictureService");
                throw new ArgumentNullException(errorMessage);
            }

            if (pictureBaseOperatonsProvider == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Picture>", "PictureService");
                throw new ArgumentNullException(errorMessage);
            }

            if (dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfDbContextSaveChanges", "PictureService");
                throw new ArgumentNullException(errorMessage);
            }

            this.pictureBaseOperatonsProvider = pictureBaseOperatonsProvider;
            this.dbContextSaveChanges = dbContextSaveChanges;
        }


        public IEnumerable<PictureModel> GetAllPictures()
        {
            IList<PictureModel> picturesToReturn = null;
            IEnumerable<IPicture> pictures = this.pictureBaseOperatonsProvider.All.ToList();

            if (pictures == null)
            {
                string errorMessage = nameof(pictures);
                throw new ArgumentNullException(errorMessage);
            }

            if (pictures.Count() > 0)
            {
                picturesToReturn = new List<PictureModel>();

                foreach (var picture in pictures)
                {
                    PictureModel a = new PictureModel(picture);
                    picturesToReturn.Add(a);
                }
            }

            return picturesToReturn;
        }

        public IPictureModel GetPictureById(int? id)
        {
            if (id == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.SelectByIdIsPossibleOnlyWithNotNullableParameter, "null");
                throw new ArgumentNullException(errorMessage);
            }
            if (id <= 0)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.SelectByIdIsPossibleOnlyWithPositiveParameter, id);
                throw new ArgumentException(errorMessage);
            }

            IPictureModel pictureToReturn = null;
            IPicture picture = this.pictureBaseOperatonsProvider.SelectById(id);

            if (picture == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Picture", id);
                throw new ArgumentNullException(errorMessage);
            }

            // TODO create MyDbModelsMapper.Picture2PictureModel and replace
            pictureToReturn = new PictureModel(picture);

            return pictureToReturn;
        }

        public IEnumerable<IPictureModel> GetAllPicturesSortedByFirstName()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPictureModel> GetAllPicturesSortedById()
        {
            throw new NotImplementedException();
        }

        public int InsertPicture(IPictureModel pictureModel)
        {
            throw new NotImplementedException();
        }

        public IPictureModel UpdatePicture(IPictureModel pictureModel)
        {
            throw new NotImplementedException();
        }
        public void DeletePictureById(int? id)
        {
            throw new NotImplementedException();
        }
    }
}

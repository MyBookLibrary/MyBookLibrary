using BookLibrary.App_Start;
using BookLibrary.Constants;
using BookLibrary.Contracts;
using BookLibrary.Data.Services.Contracts;
using BookLibrary.Pure.Models;
using BookLibrary.ViewModels.Picture;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class PictureController : Controller
    {
        private readonly IPictureService pictureService;

        public PictureController()
        {
            this.pictureService = NinjectWebCommon.Kernel.Get<IPictureService>();
        }
        
        // GET: Picture
        public ActionResult Index()
        {
            IEnumerable<PictureModel> pictures = this.pictureService.GetAllPictures();

            // TODO Refactor when Mapper created
            IList<PictureMainViewModel> picturesToReturn = new List<PictureMainViewModel>();
            foreach (PictureModel picture in pictures)
            {
                PictureMainViewModel a = new PictureMainViewModel(picture.Id, picture.Name, picture.Width, picture.Height, picture.SizeMb, picture.Url);
                picturesToReturn.Add(a);
            }

            return View(picturesToReturn.AsEnumerable());
        }

        // GET: Picture/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Picture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Url")] PictureMainViewModel pictureMainViewModel)
        {
            if (ModelState["Id"] != null)
            {
                if (ModelState["Id"].Errors.Count > 0)
                {
                    ModelState["Id"].Errors.Clear();
                }
            }

            if (ModelState.IsValid)
            {
                // TODO refactore when mapper created
                IPictureModel pictureModelToinsert = new PictureModel();
                pictureModelToinsert.Id = pictureMainViewModel.Id;
                pictureModelToinsert.Url = pictureMainViewModel.Url;

                int id = this.pictureService.InsertPicture(pictureModelToinsert);

                return RedirectToAction("Index");
            }

            return View(pictureMainViewModel);
        }

        // GET: Picture/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IPictureModel pictureModel = this.pictureService.GetPictureById(id);
            if (pictureModel == null)
            {
                return HttpNotFound();
            }

            // TODO refactore when mapper created ???
            PictureMainViewModel pictureMainViewModel = new PictureMainViewModel(
                (int)pictureModel.Id,
                pictureModel.Url);

            return View(pictureMainViewModel);
        }

        // POST: Picture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Url")] PictureMainViewModel pictureMainViewModel)
        {
            if (ModelState.IsValid)
            {
                // TODO refactore when mapper created
                IPictureModel pictureModelToUpdate = new PictureModel();
                pictureModelToUpdate.Id = pictureMainViewModel.Id;
                pictureModelToUpdate.Url = pictureMainViewModel.Url;

                this.pictureService.UpdatePicture(pictureModelToUpdate);

                return RedirectToAction("Index");
            }

            return View(pictureMainViewModel);
        }

        // GET: Picture/Delete/5
        public PartialViewResult ViewDeleteConfirm(int? id)
        {
            if (id == null)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter);
                throw new ArgumentNullException(errorMessage);
            }
            if (id <= 0)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter);
                throw new ArgumentException(errorMessage);
            }

            IPictureModel pictureModel = this.pictureService.GetPictureById(id);

            if (pictureModel == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Picture", id);
                throw new ArgumentNullException(errorMessage);
            }
            PictureMainViewModel pictureMainViewModel = new PictureMainViewModel();
            pictureMainViewModel.Id = (int)pictureModel.Id;
            pictureMainViewModel.Url = pictureModel.Url;

            return PartialView("_DeleteConfirm", pictureMainViewModel);
        }

        // POST: Picture/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter);
                throw new ArgumentNullException(errorMessage);
            }
            if (id <= 0)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter);
                throw new ArgumentException(errorMessage);
            }

            this.pictureService.DeletePictureById(id);

            return RedirectToAction("Index");
        }
    }
}

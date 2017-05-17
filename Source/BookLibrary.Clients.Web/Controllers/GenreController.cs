using BookLibrary.App_Start;
using BookLibrary.Constants;
using BookLibrary.Contracts;
using BookLibrary.Data.Services.Contracts;
using BookLibrary.Pure.Models;
using BookLibrary.ViewModels.Genre;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService genreService;

        public GenreController()
        {
            this.genreService = NinjectWebCommon.Kernel.Get<IGenreService>();
        }

        // GET: Genre
        public ActionResult Index()
        {
            IEnumerable<GenreModel> genres = this.genreService.GetAllGenres();

            // TODO Refactor when Mapper created
            IList<GenreMainViewModel> genresToReturn = new List<GenreMainViewModel>();
            foreach (GenreModel genre in genres)
            {
                GenreMainViewModel a = new GenreMainViewModel(genre.Id, genre.Name);
                genresToReturn.Add(a);
            }

            return View(genresToReturn.AsEnumerable());
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name")] GenreMainViewModel genreMainViewModel)
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
                IGenreModel genreModelToinsert = new GenreModel();
                genreModelToinsert.Id = genreMainViewModel.Id;
                genreModelToinsert.Name = genreMainViewModel.Name;

                int id = this.genreService.InsertGenre(genreModelToinsert);

                return RedirectToAction("Index");
            }

            return View(genreMainViewModel);
        }

        // GET: Genre/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IGenreModel genreModel = this.genreService.GetGenreById(id);
            if (genreModel == null)
            {
                return HttpNotFound();
            }

            // TODO refactore when mapper created ???
            GenreMainViewModel genreMainViewModel = new GenreMainViewModel(
                (int)genreModel.Id,
                genreModel.Name);

            return View(genreMainViewModel);
        }

        // POST: Genre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name")] GenreMainViewModel genreMainViewModel)
        {
            if (ModelState.IsValid)
            {
                // TODO refactore when mapper created
                IGenreModel genreModelToUpdate = new GenreModel();
                genreModelToUpdate.Id = genreMainViewModel.Id;
                genreModelToUpdate.Name = genreMainViewModel.Name;

                this.genreService.UpdateGenre(genreModelToUpdate);

                return RedirectToAction("Index");
            }

            return View(genreMainViewModel);
        }

        // GET: Genre/Delete/5
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

            IGenreModel genreModel = this.genreService.GetGenreById(id);

            if (genreModel == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Genre", id);
                throw new ArgumentNullException(errorMessage);
            }
            GenreMainViewModel genreMainViewModel = new GenreMainViewModel();
            genreMainViewModel.Id = (int)genreModel.Id;
            genreMainViewModel.Name = genreModel.Name;

            return PartialView("_DeleteConfirm", genreMainViewModel);
        }

        // POST: Genre/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
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

            this.genreService.DeleteGenreById(id);

            return RedirectToAction("Index");
        }

        public IEnumerable<SelectListItem> GetGenreSelectList()
        {
            IEnumerable<GenreModel> genres = this.genreService.GetAllGenres();
            IEnumerable<SelectListItem> genresToReturn = genres
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });

            return new SelectList(genresToReturn, "Value", "Text");
        }
    }
}

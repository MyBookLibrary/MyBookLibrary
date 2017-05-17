using BookLibrary.Data.Services.Contracts;
using BookLibrary.Pure.Models;
using BookLibrary.ViewModels.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using BookLibrary.App_Start;
using BookLibrary.Data.Services;
using BookLibrary.Data.Provider;
using BookLibrary.Data.Provider.Operations;
using BookLibrary.Ef.Models;
using BookLibrary.Contracts;
using System.Net;
using BookLibrary.Constants;

namespace BookLibrary.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService authorService;

        public AuthorController()
        {
            this.authorService = NinjectWebCommon.Kernel.Get<IAuthorService>();
        }

        // GET: Author
        public ActionResult Index()
        {
            IEnumerable<AuthorModel> authors = this.authorService.GetAllAuthors();

            // TODO Refactor when Mapper created
            IList<AuthorMainViewModel> authorsToReturn = new List<AuthorMainViewModel>();
            foreach(AuthorModel author in authors)
            {
                AuthorMainViewModel a = new AuthorMainViewModel(author.Id, author.FirstName, author.LastName);
                authorsToReturn.Add(a);
            }
            
            return View(authorsToReturn.AsEnumerable());
        }

        
        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, FirstName, LastName")] AuthorMainViewModel authorMainViewModel)
        {
            if (ModelState["Id"] != null)
            {
                if(ModelState["Id"].Errors.Count > 0)
                {
                    ModelState["Id"].Errors.Clear();
                }
            }

            if (ModelState.IsValid)
            {
                // TODO refactore when mapper created
                IAuthorModel authorModelToinsert = new AuthorModel();
                authorModelToinsert.Id = authorMainViewModel.Id;
                authorModelToinsert.FirstName = authorMainViewModel.FirstName;
                authorModelToinsert.LastName = authorMainViewModel.LastName;

                int id = this.authorService.InsertAuthor(authorModelToinsert);

                return RedirectToAction("Index");
            }

            return View(authorMainViewModel);
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IAuthorModel authorModel = this.authorService.GetAuthorById(id);
            if (authorModel == null)
            {
                return HttpNotFound();
            }

            // TODO refactore when mapper created ???
            AuthorMainViewModel authorMainViewModel = new AuthorMainViewModel(
                (int)authorModel.Id,
                authorModel.FirstName,
                authorModel.LastName);

            return View(authorMainViewModel);
        }

        // POST: Author/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, FirstName, LastName")] AuthorMainViewModel authorMainViewModel)
        {
            if (ModelState.IsValid)
            {
                // TODO refactore when mapper created
                IAuthorModel authorModelToUpdate = new AuthorModel();
                authorModelToUpdate.Id = authorMainViewModel.Id;
                authorModelToUpdate.FirstName = authorMainViewModel.FirstName;
                authorModelToUpdate.LastName = authorMainViewModel.LastName;

                this.authorService.UpdateAuthor(authorModelToUpdate);

                return RedirectToAction("Index");
            }

            return View(authorMainViewModel);
        }

        // GET: Author/Delete/5
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

            IAuthorModel authorModel = this.authorService.GetAuthorById(id);

            if (authorModel == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Author", id);
                throw new ArgumentNullException(errorMessage);
            }
            AuthorMainViewModel authorMainViewModel = new AuthorMainViewModel();
            authorMainViewModel.Id = (int)authorModel.Id;
            authorMainViewModel.FirstName = authorModel.FirstName;
            authorMainViewModel.LastName = authorModel.LastName;

            return PartialView("_DeleteConfirm", authorMainViewModel);
        }

        // POST: Author/Delete/5
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

            this.authorService.DeleteAuthorById(id);

            return RedirectToAction("Index");
        }

        public IEnumerable<SelectListItem> GetAuthorSelectList()
        {
            IEnumerable<AuthorModel> authors = this.authorService.GetAllAuthors();
            IEnumerable<SelectListItem> authorsToReturn = authors
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.FullName
                });
                        
            return new SelectList(authorsToReturn, "Value", "Text");
        }
    }
}

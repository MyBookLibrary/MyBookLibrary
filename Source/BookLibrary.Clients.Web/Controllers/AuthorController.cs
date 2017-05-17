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
            return View();
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Author/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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

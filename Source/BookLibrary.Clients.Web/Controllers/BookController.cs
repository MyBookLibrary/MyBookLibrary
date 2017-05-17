using BookLibrary.App_Start;
using BookLibrary.Data.Provider;
using BookLibrary.Data.Provider.Operations;
using BookLibrary.Data.Services;
using BookLibrary.Data.Services.Contracts;
using BookLibrary.Ef.Models;
using BookLibrary.ViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;

        public BookController()
        {
            this.authorService = NinjectWebCommon.Kernel.Get<IAuthorService>();
            this.bookService = NinjectWebCommon.Kernel.Get<IBookService>();
        }

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            BookCreateViewModel modelToReturn = new BookCreateViewModel();

            // TODO Refactor if better option found
            AuthorController authorController = new AuthorController();
            GenreController genreController = new GenreController();

            modelToReturn.CreationDate = DateTime.Now;
            modelToReturn.AuthorSelectList = authorController.GetAuthorSelectList();
            modelToReturn.GenreSelectList = genreController.GetGenreSelectList();

            return View(modelToReturn);
        }

        // POST: Book/Create
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

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
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

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
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
    }
}

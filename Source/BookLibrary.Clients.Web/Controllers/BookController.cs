using BookLibrary.App_Start;
using BookLibrary.Contracts;
using BookLibrary.Data.Provider;
using BookLibrary.Data.Provider.Operations;
using BookLibrary.Data.Services;
using BookLibrary.Data.Services.Contracts;
using BookLibrary.Ef.Models;
using BookLibrary.Pure.Models;
using BookLibrary.ViewModels.Book;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly IGenreService genreService;

        public BookController()
        {
            this.authorService = NinjectWebCommon.Kernel.Get<IAuthorService>();
            this.genreService = NinjectWebCommon.Kernel.Get<IGenreService>();
            this.bookService = NinjectWebCommon.Kernel.Get<IBookService>();
        }

        // GET: Book
        public ActionResult Index()
        {
            IEnumerable<BookModel> books = this.bookService.GetAllBooks();

            if (books == null)
            {
                return View();
            }

            // TODO Refactor when Mapper created
            IList<BookMainViewModel> booksToReturn = new List<BookMainViewModel>();
            foreach (BookModel book in books)
            {
                BookMainViewModel b;
                if (book.Picture == null)
                {
                    b = new BookMainViewModel(book);
                }
                else
                {
                    b = new BookMainViewModel(book, book.Picture);
                }

                booksToReturn.Add(b);
            }

            return View(booksToReturn.AsEnumerable());
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title, Description, CreationDate, Pages, SelectedAuthorId, SelectedGenreId, PictureUrl")] BookCreateViewModel bookCreateViewModel)
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
                IBookModel bookModelToInsert = new BookModel();
                bookModelToInsert.Id = bookCreateViewModel.Id;
                bookModelToInsert.Title = bookCreateViewModel.Title;
                bookModelToInsert.Description = bookCreateViewModel.Description;
                bookModelToInsert.CreationDate = bookCreateViewModel.CreationDate;
                bookModelToInsert.Pages = bookCreateViewModel.Pages;

                // Process picture insert here
                if (!string.IsNullOrEmpty(bookCreateViewModel.PictureUrl))
                {
                    // TODO Get picture data

                    // TODO Insert picture

                    // TODO Get picture id

                    // TODO Assign picture parameters to the book model to be inserted
                    PictureModel picture = new PictureModel();
                    picture.Id = 1;
                    picture.Url = bookCreateViewModel.PictureUrl;

                    bookModelToInsert.PictureId = picture.Id;
                }
                
                bookModelToInsert.AuthorId = bookCreateViewModel.SelectedAuthorId;
                bookModelToInsert.GenreId = bookCreateViewModel.SelectedGenreId;

                int id = this.bookService.InsertBook(bookModelToInsert);

                return RedirectToAction("Index");
            }

            return View(bookCreateViewModel);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IBookModel bookModel = this.bookService.GetBookById(id);
            if (bookModel == null)
            {
                return HttpNotFound();
            }

            // TODO refactore when mapper created ???
            BookCreateViewModel bookCreateViewModel = new BookCreateViewModel();
            bookCreateViewModel.Id = bookModel.Id;
            bookCreateViewModel.Title = bookModel.Title;
            bookCreateViewModel.Description = bookModel.Description;
            bookCreateViewModel.Pages = bookModel.Pages;
            bookCreateViewModel.CreationDate = bookModel.CreationDate;

            // TODO Refactor if better option found
            AuthorController authorController = new AuthorController();
            GenreController genreController = new GenreController();

            bookCreateViewModel.SelectedAuthorId = bookModel.Author.Id;
            bookCreateViewModel.AuthorSelectList = authorController.GetAuthorSelectList();
            bookCreateViewModel.SelectedGenreId = bookModel.Genre.Id;
            bookCreateViewModel.GenreSelectList = genreController.GetGenreSelectList();

            if (bookModel.Picture == null)
            {
                bookCreateViewModel.PictureUrl = string.Empty;
            }
            else
            {
                bookCreateViewModel.PictureUrl = bookModel.Picture.Url;
            }

            return View(bookCreateViewModel);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Title, Description, CreationDate, Pages, SelectedAuthorId, SelectedGenreId, PictureUrl")] BookCreateViewModel bookCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                // TODO refactore when mapper created
                IBookModel bookModelToUpdate = new BookModel();
                bookModelToUpdate.Id = bookCreateViewModel.Id;
                bookModelToUpdate.Title = bookCreateViewModel.Title;
                bookModelToUpdate.Description = bookCreateViewModel.Description;
                bookModelToUpdate.CreationDate = bookCreateViewModel.CreationDate;
                bookModelToUpdate.Pages = bookCreateViewModel.Pages;

                // TODO select the changed picture and set the id
                //bookModelToUpdate.Picture.Id = bookModelToUpdate.Picture.Id;
                bookModelToUpdate.AuthorId = bookCreateViewModel.SelectedAuthorId;
                bookModelToUpdate.GenreId = bookCreateViewModel.SelectedGenreId;

                this.bookService.UpdateBook(bookModelToUpdate);

                return RedirectToAction("Index");
            }

            return View(bookCreateViewModel);
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

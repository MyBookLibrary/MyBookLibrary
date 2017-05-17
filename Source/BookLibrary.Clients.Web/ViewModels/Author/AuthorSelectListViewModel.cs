using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookLibrary.ViewModels.Author
{
    public class AuthorSelectListViewModel
    {
        [Display(Name = "Author")]
        public int SelectedAuthorId { get; set; }
        public IEnumerable<SelectListItem> Authors {get; set;}
    }
}
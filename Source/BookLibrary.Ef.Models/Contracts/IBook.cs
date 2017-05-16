﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Ef.Models.Contracts
{
    public interface IBook
    {
        int Id { get; set; }

        string Title { get; set; }

        string Description { get; set; }

        int AuthorId { get; set; }

        int GenreId { get; set; }

        Author Author { get; set; }

        Genre Genre { get; set; }
    }
}

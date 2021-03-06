﻿using BookLibrary.Contracts;
using BookLibrary.Ef.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Pure.Models
{
    public class AuthorModel : IAuthorModel, IHasIntId
    {
        public AuthorModel()
        {
        }

        // This constructor is used for DbModel 2 PureModel mapping
        // IAuthor is the Ef model interface
        public AuthorModel(IAuthor author)
        {
            if(author == null)
            {
                throw new ArgumentNullException();
            }

            this.Id = author.Id;
            this.FirstName = author.FirstName;
            this.LastName = author.LastName;        
        }

        public int Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}

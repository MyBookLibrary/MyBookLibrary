using BookLibrary.Contracts;
using BookLibrary.Ef.Models.Contracts;
using BookLibrary.Ef.Models.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Ef.Models
{
    [MetadataType(typeof(BookMetaData))]
    public partial class Book : IBook, IHasIntId
    {
    }
}

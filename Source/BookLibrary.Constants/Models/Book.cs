using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Constants.Models
{
    public static partial class Consts
    {
        public struct Book
        {
            public struct Id
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "Book Id value should be positive integer numnber.";
            }

            public struct Title
            {
                public const int MaxLength = 50;
                public const int MinLength = 2;
                public const string ErrorMessageMaxLength = "Book title length should be less than " + "100" + " symbols.";
                public const string ErrorMessageMinLength = "Book title length should be more than " + "2" + " symbols.";
            }

            public struct Description
            {
                public const int MaxLength = 500;
                public const int MinLength = 2;
                public const string ErrorMessageMaxLength = "Book description length should be less than " + "500" + " symbols.";
                public const string ErrorMessageMinLength = "Book description length should be more than " + "2" + " symbols.";
            }

            public struct Pages
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "Book pages value should be positive integer numnber.";
            }
        };
    }
}

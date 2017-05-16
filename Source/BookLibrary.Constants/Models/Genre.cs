using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Constants.Models
{
    public static partial class Consts
    {
        public struct Genre
        {
            public struct Id
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "Genre Id value should be positive integer numnber.";
            }

            public struct Name
            {
                public const int MaxLength = 50;
                public const int MinLength = 2;
                public const string ErrorMessageMaxLength = "Genre name length should be less than " + "50" + " symbols.";
                public const string ErrorMessageMinLength = "Genre name length should be more than " + "2" + " symbols.";
            }
        };
    }
}

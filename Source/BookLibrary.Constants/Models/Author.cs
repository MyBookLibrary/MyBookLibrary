using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Constants.Models
{
    public static partial class Consts
    {
        public struct Author
        {
            public struct Id
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "Author Id value should be positive integer numnber.";
            }

            public struct FirstName
            {
                public const int MaxLength = 50;
                public const int MinLength = 2;
                public const string ErrorMessageMaxLength = "Author firstname length should be less than " + "50" + " symbols.";
                public const string ErrorMessageMinLength = "Author firstname length should be more than " + "2" + " symbols.";
            }

            public struct LastName
            {
                public const int MaxLength = 50;
                public const int MinLength = 2;
                public const string ErrorMessageMaxLength = "Author lastname length should be less than " + "50" + " symbols.";
                public const string ErrorMessageMinLength = "Author lastname length should be more than " + "2" + " symbols.";
            }
        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Constants.Models
{
    public static partial class Consts
    {
        public struct Picture
        {
            public struct Id
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "Picture Id value should be positive integer numnber.";
            }

            public struct Name
            {
                public const int MaxLength = 50;
                public const int MinLength = 2;
                public const string ErrorMessageMaxLength = "Picture name length should be less than " + "50" + " symbols.";
                public const string ErrorMessageMinLength = "Picture name length should be more than " + "2" + " symbols.";
            }

            public struct Width
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "Picture width value should be positive integer numnber.";
            }

            public struct Height
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "Picture height value should be positive integer numnber.";
            }

            public struct SizeMb
            {
                public const int MaxValue = int.MaxValue;
                public const int MinValue = 1;
                public const string ErrorMessage = "Picture file size should be positive integer numnber.";
            }

            public struct Url
            {
                public const int MaxLength = 500;
                public const int MinLength = 5;
                public const string ErrorMessageMaxLength = "Picture url length should be less than " + "500" + " symbols.";
                public const string ErrorMessageMinLength = "Picture url length should be more than " + "5" + " symbols.";
            }
        };
    }
}

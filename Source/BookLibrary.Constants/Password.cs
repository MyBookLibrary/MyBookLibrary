using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Constants
{
    public partial class Consts
    {
        public struct Password
        {
            public struct Lenght
            {
                public const int MaxValue = 100;
                public const int MinValue = 2;
                public const string ErrorMessage = "The {0} must be at least {2} characters long.";
            }

            public struct Confirm
            {
                public const string ErrorMessage = "The password and confirmation password do not match.";
            }
        };
    }
}

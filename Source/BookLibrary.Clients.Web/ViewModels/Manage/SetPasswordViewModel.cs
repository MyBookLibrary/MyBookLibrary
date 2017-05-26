using BookLibrary.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookLibrary.ViewModels.Manage
{
    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = Consts.Password.Lenght.ErrorMessage, MinimumLength = Consts.Password.Lenght.MinValue)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = Consts.Password.Confirm.ErrorMessage)]
        public string ConfirmPassword { get; set; }
    }
}
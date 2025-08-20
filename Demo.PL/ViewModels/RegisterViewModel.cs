using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="The First Name Is Required")]
        public string FName { get; set; }
        [Required(ErrorMessage ="The Last Name Is Required")]
        public string LName { get; set; }
        [Required(ErrorMessage = "The Email Is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password Is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "The Password Is Required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="The Password Doesn't Match")]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }
    }
}

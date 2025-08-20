using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password Is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "The Password Is Required")]
        public bool RememberMe { get; set; }
    }
}

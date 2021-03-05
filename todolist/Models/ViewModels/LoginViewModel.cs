using System.ComponentModel.DataAnnotations;

namespace todolist.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

        public LoginViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
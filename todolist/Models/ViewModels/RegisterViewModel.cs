using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using todolist.Exceptions;

namespace todolist.Models.ViewModels
{
    public class RegisterViewModel
    {
        public RegisterViewModel(string email, string password, string passwordConfirm)
        {
            if (password != passwordConfirm)
            {
                throw new AccountException("Passwords should match");
            }
            Email = email;
            Password = password;
            PasswordConfirm = passwordConfirm;
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
using System;

namespace Rooms.Classic.Web.App.ViewModels.Users
{
    public class RegisterUserViewModel : UserViewModel
    {
        public RegisterUserViewModel(string name, string email, DateTime birthDate, string password) : base(name, email, birthDate)
        {
            Password = password;
        }

        public RegisterUserViewModel() : base(string.Empty, string.Empty, DateTime.MinValue)
        {
            Password = string.Empty;
        }

        public string Password { get; set; }
    }
}

using System;

namespace Rooms.Classic.Web.App.ViewModels.Users
{
    public class LoginUserViewModel : UserViewModel
    {
        public LoginUserViewModel(string name, string email, DateTime birthDate, string password) : base(name, email, birthDate)
        {
            Password = password;
        }

        public LoginUserViewModel() : base(string.Empty, string.Empty, DateTime.MinValue)
        {
            Password = string.Empty;
        }

        public string Password { get; set; }
    }
}

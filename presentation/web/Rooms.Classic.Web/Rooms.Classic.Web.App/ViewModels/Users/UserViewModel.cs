using System;

namespace Rooms.Classic.Web.App.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public string Name { get; set; } 
        public string Email { get; set; }
        public DateTime BirthDate {  get; set; }
    }
}

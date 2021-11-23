using BooksDb.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksDb.Enities
{
    public class User : IEntityKey<int>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string RegistrationToken { get; set; }
        public string OatuhToken { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BooksService.Models
{
    public class UserRegistrationRequest
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}

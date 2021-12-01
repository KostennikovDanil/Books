using System;
using System.Collections.Generic;
using System.Text;

namespace BooksService.Models
{
    public class UserAuthenticateRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

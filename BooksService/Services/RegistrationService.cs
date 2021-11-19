using BooksDb;
using BooksDb.Repositories;
using BooksService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BooksService.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository userRepository;
        private readonly BooksDbContext bookDbContext;
        public RegistrationService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task RegistrAsync(UserRegistrationRequest request)
        {
           // userRepository.
        }
    }
}

using BooksDb;
using BooksDb.Repositories;
using BooksService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksService.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository userRepository;
        public RegistrationService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<UserRegistrationResponse> RegistrAsync(UserRegistrationRequest request)
        {
            var validationResult = Validate(request);
            if (validationResult == false)
                return new UserRegistrationResponse { Affected = 0, IsCodeSentSuccess = false, ResponseCode = UserRegistrationResponse.RegistrationResponseCode.ValidationFailed };

            var user = await userRepository.All().FirstOrDefaultAsync(_ => _.UserName == request.UserName);
             if(user != null)
                return new UserRegistrationResponse { Affected = 0, IsCodeSentSuccess = false, ResponseCode = UserRegistrationResponse.RegistrationResponseCode.UserNameAlreadyRegistered };

             var userByPhone = userRepository.All().FirstOrDefaultAsync(_ => _.PhoneNumber == request.PhoneNumber);
            if (userByPhone != null)
                return new UserRegistrationResponse { Affected = 0, IsCodeSentSuccess = false, ResponseCode = UserRegistrationResponse.RegistrationResponseCode.PhoneNumberAlreadyRegistered };

            await userRepository.AddAsync(new BooksDb.Enities.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                SecondName = request.SecondName,
                UserName = request.UserName,
                PasswordHash = request.Password // to do: hash it
            });
            return new UserRegistrationResponse { Affected = 1, IsCodeSentSuccess = true, ResponseCode = UserRegistrationResponse.RegistrationResponseCode.Success };

        }

        private bool Validate(UserRegistrationRequest request)
        {
            if (string.IsNullOrEmpty(request.UserName))
                return false;
            if (string.IsNullOrEmpty(request.FirstName))
                return false;
            if (string.IsNullOrEmpty(request.LastName))
                return false;
            if (string.IsNullOrEmpty(request.Password))
                return false;
            return true;
        }
    }
}

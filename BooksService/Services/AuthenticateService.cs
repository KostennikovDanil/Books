using BooksDb.Repositories;
using BooksDb;
using BooksService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace BooksService.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserRepository userRepository;
        private readonly BooksDbContext dbContext;
        public AuthenticateService(IUserRepository userRepository, BooksDbContext dbContext)
        {
            this.userRepository = userRepository;
            this.dbContext = dbContext;
        }
        public async Task<UserAuthenticateResponse> AuthAsync(UserAuthenticateRequest request)
        {
            //var validationResult = Validate(request);
            //if (validationResult == false)
            //    return new UserAuthenticateResponse { Affected = 0, IsCodeSentSuccess = false, ResponseCode = UserAuthenticateResponse.AuthenticateResponseCode.ValidationFailed };

            var user = await dbContext.Users.FirstOrDefaultAsync(_ => _.UserName == request.UserName);
            if (user == null)
                return new UserAuthenticateResponse { IsCodeSentSuccess = false, ResponseCode = UserAuthenticateResponse.AuthenticateResponseCode.UserNameNotFound };

            if(user.PasswordHash != request.Password)
                return new UserAuthenticateResponse { IsCodeSentSuccess = false, ResponseCode = UserAuthenticateResponse.AuthenticateResponseCode.WrongInput };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var expires = DateTime.Now.AddHours(1);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, request.UserName)
            };
            var jwtToken = new JwtSecurityToken(
                issuer: "loclahost",
                audience: "site",
                claims: claims,
                expires: expires,
                signingCredentials: credentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return new UserAuthenticateResponse
            {
                Token = token,
                Expires = expires,
                IsCodeSentSuccess = true,
                ResponseCode = UserAuthenticateResponse.AuthenticateResponseCode.Success
            };

        }
    }
}

using BooksService.Models;
using System.Threading.Tasks;

namespace BooksService.Services
{
    public interface IAuthenticateService
    {
        Task<UserAuthenticateResponse> AuthAsync(UserAuthenticateRequest request);
    }
}
using BooksService.Models;
using System.Threading.Tasks;

namespace BooksService.Services
{
    public interface IRegistrationService
    {
        Task<UserRegistrationResponse> RegistrAsync(UserRegistrationRequest request);
    }
}
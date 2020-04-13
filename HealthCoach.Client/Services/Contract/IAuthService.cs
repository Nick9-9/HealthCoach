using HealthCoach.Shared.Models;
using System.Threading.Tasks;

namespace HealthCoach.Client.Services.Contract
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
        Task<RegisterResult> Register(RegisterModel registerModel);
    }
}

using tmdbapi.Auth;
using tmdbapi.ViewModels;

namespace tmdbapi.Services.IServices
{
    public interface IAuthenticateService
    {
        Task<IResponse> LoginAsync(LoginModel model);
        Task<IResponse> RegisterAsync(RegisterModel model);
        Task<IResponse> RegisterAdminAsync(RegisterModel model);
    }
}

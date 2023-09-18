using CybersourceNet_App.ViewModels.Auth;
using CybersourceNet_Data.Models;

namespace CybersourceNet_App.Contracts
{
    public interface IAuth
    {
        UserModel Authenticate(UserLoginRequestViewModel userLoginViewModel);
        String GenerateToken(UserModel userModel);
    }
}

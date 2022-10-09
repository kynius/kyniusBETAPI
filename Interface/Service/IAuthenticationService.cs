using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data.DTO;

namespace kyniusBETAPI.Interface.Service;

public interface IAuthenticationService
{
    Task<Response> Register(UserRegisterDTO model);
    Task<Response> Login(UserLoginDTO model);
}
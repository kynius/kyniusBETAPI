using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data.DTO;

namespace kyniusBETAPI.Interface.Repo;

public interface IAuthenticationRepo
{
    Task<Response> Register(UserRegisterDTO model);
    Task<Response> Login(UserLoginDTO model);
}
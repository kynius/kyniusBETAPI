using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data.DTO;

namespace kyniusBETAPI.Interface.Repo;

public interface IAuthenticationRepo
{
    public Task<Response> Register(UserRegisterDTO model);
    public Task<Response> Login(UserLoginDTO model);
}
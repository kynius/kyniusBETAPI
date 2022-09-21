using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Model;

namespace kyniusBETAPI.Interface.Repo;

public interface IAuthenticationRepo
{
    public Task<Response> Register(UserDTO model);
}
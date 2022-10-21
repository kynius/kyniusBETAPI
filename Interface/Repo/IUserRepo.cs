using kyniusBETAPI.Model;

namespace kyniusBETAPI.Interface.Repo;

public interface IUserRepo
{
    Task<User> GetUserByUserName(string userName);
}
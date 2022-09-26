using kyniusBETAPI.Model;

namespace kyniusBETAPI.Interface.Repo;

public interface IRequestRepo
{
    Task<T> Request<T>(string requestUrl);
}
using kyniusBETAPI.Model;

namespace kyniusBETAPI.Interface.Repo;

public interface IRequestRepo
{
    public Task<T> Request<T>(string requestUrl);
}
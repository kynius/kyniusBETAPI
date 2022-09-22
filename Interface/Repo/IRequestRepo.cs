using kyniusBETAPI.Model;

namespace kyniusBETAPI.Interface.Repo;

public interface IRequestRepo
{
    public Task<string> Request(string requestUrl);
}
using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Interface.Repo;

public interface IStatusRepo
{
    public Task<Status> CheckStatusInBase(Status model);
    public Task<Status> AddStatusToBase(Status model);
}
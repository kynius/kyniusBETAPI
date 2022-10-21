using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Interface.Repo;

public interface IStatusRepo
{
    Task<Status> CheckStatusInBase(Status model);
    Task<Status> AddStatusToBase(Status model);
}
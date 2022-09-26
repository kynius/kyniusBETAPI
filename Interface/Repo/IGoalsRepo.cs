using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Interface.Repo;

public interface IGoalsRepo
{
    public Task<Goals> CheckGoalsInBase(Goals model);
    public Task<Goals> AddGoalsToBase(Goals model);
}
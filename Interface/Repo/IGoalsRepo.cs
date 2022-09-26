using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Interface.Repo;

public interface IGoalsRepo
{
    Task<Goals> CheckGoalsInBase(Goals model);
    Task<Goals> AddGoalsToBase(Goals model);
}
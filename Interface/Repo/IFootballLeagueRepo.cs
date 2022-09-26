using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Interface.Repo;

public interface IFootballLeagueRepo
{
    public Task<FootballLeague> CheckFootballLeagueInBase(FootballLeague model);
    public Task<FootballLeague> AddFootballLeague(FootballLeague model);
}
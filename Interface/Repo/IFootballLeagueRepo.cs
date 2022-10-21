using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Interface.Repo;

public interface IFootballLeagueRepo
{
    Task<FootballLeague> CheckFootballLeagueInBase(FootballLeague model);
    Task<FootballLeague> AddFootballLeague(FootballLeague model);
}
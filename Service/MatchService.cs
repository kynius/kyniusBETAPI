using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Interface.Service;
using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Service;

public class MatchService : IMatchService
{
    private readonly ITeamRepo _teamsRepo;
    private readonly IStatusRepo _statusRepo;
    private readonly IGoalsRepo _goalsRepo;
    private readonly IFootballLeagueRepo _footballLeagueRepo;
    private readonly IScoreService _scoreService;
    private readonly IMatchRepo _matchRepo;

    public MatchService(ITeamRepo teamsRepo, IStatusRepo statusRepo, IGoalsRepo goalsRepo, IFootballLeagueRepo footballLeagueRepo, IScoreService scoreService, IMatchRepo matchRepo)
    {
        _teamsRepo = teamsRepo;
        _statusRepo = statusRepo;
        _goalsRepo = goalsRepo;
        _footballLeagueRepo = footballLeagueRepo;
        _scoreService = scoreService;
        _matchRepo = matchRepo;
    }

    public async Task<List<Match>> AddMatchesToDataBase(List<MatchDTO> matches)
    {
        var mappedMatches = new List<Match>();
        foreach (var m in matches)
        {
            m.Teams = await _teamsRepo.CheckTeamsInBase(m.Teams);
            m.Fixture.Status = await _statusRepo.CheckStatusInBase(m.Fixture.Status);
            m.Goals = await _goalsRepo.CheckGoalsInBase(m.Goals);
            m.FootballLeague = await _footballLeagueRepo.CheckFootballLeagueInBase(m.FootballLeague);
            m.Score = await _scoreService.CheckScoreInBase(m.Score);
            var mappedMatch = new Match(m);
            var match = await _matchRepo.CheckMatchInBase(mappedMatch);
            mappedMatches.Add(match);
        }

        return mappedMatches;
    }
}
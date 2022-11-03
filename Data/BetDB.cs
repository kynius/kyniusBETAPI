using kyniusBETAPI.Model;
using kyniusBETAPI.Model.Match;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace kyniusBETAPI.Data;


public class BetDB : IdentityDbContext<User>
{
    public BetDB(DbContextOptions<BetDB> options) : base(options)
    {
            
    }
    public DbSet<League> League { get; set; } = null!;
    public DbSet<LeagueUser> LeagueUser { get; set; } = null!;
    public DbSet<FootballLeague> FootballLeague { get; set; } = null!;
    public DbSet<Goals> Goals { get; set; }= null!;
    public DbSet<Match> Match { get; set; }= null!;
    public DbSet<Score> Score { get; set; }= null!;
    public DbSet<Status> Status { get; set; }= null!;
    public DbSet<Team> Team { get; set; }= null!;
    public DbSet<Invite> Invite { get; set; }= null!;
    public DbSet<Bet> Bet { get; set; }= null!;
    public DbSet<BetType> BetType { get; set; }= null!;
    public DbSet<LeagueBet> LeagueBet { get; set; }= null!;
    protected override void OnModelCreating(ModelBuilder builder)
    {   
        builder.Entity<LeagueUser>()
            .HasOne(c => c.User)
            .WithMany(c => c.LeagueUser)
            .HasForeignKey(c => c.UserId);
        builder.Entity<LeagueUser>()
            .HasOne(c => c.League)
            .WithMany(c => c.LeagueUser)
            .HasForeignKey(c => c.LeagueId);
        builder.Entity<Bet>().Navigation(x => x.LeagueBet).AutoInclude();
        builder.Entity<LeagueBet>().Navigation(x => x.BetType).AutoInclude();
        builder.Entity<LeagueBet>().Navigation(x => x.Match).AutoInclude();
        builder.Entity<Match>().Navigation(x => x.Away).AutoInclude();
        builder.Entity<Match>().Navigation(x => x.Home).AutoInclude();
        builder.Entity<Match>().Navigation(x => x.Goals).AutoInclude();
        builder.Entity<Match>().Navigation(x => x.Score).AutoInclude();
        builder.Entity<Match>().Navigation(x => x.Status).AutoInclude();
        builder.Entity<Match>().Navigation(x => x.FootballLeague).AutoInclude();
        builder.Entity<Score>().Navigation(x => x.Extratime).AutoInclude();
        builder.Entity<Score>().Navigation(x => x.Fulltime).AutoInclude();
        builder.Entity<Score>().Navigation(x => x.Halftime).AutoInclude();
        builder.Entity<Score>().Navigation(x => x.Penalty).AutoInclude();
        builder.Entity<Score>().Navigation(x => x.GoalsInFirsthalf).AutoInclude();
        builder.Entity<Score>().Navigation(x => x.GoalsInSecondhalf).AutoInclude();
        base.OnModelCreating(builder);
    }
}
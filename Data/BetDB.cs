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
        base.OnModelCreating(builder);
    }
}
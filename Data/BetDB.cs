using kyniusBETAPI.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace kyniusBETAPI.Data;


public class BetDB : IdentityDbContext<User>
{
    public BetDB(DbContextOptions<BetDB> options) : base(options)
    {
            
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
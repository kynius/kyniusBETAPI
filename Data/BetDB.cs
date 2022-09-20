namespace kyniusBETAPI.Data;
using Microsoft.EntityFrameworkCore;

public class BetDB : DbContext
{
    public BetDB(DbContextOptions<BetDB> options) : base(options)
    {
            
    }


}
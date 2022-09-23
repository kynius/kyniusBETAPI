using kyniusBETAPI.Data;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Model.Match;
using Microsoft.EntityFrameworkCore;

namespace kyniusBETAPI.Repo;

public class StatusRepo : IStatusRepo
{
    private readonly BetDB _db;

    public StatusRepo(BetDB db)
    {
        _db = db;
    }
    public async Task<Status> CheckStatusInBase(Status model)
    {
        var status = await _db.Status.FirstOrDefaultAsync(x => x.Elapsed == model.Elapsed && x.Long == model.Long && x.Short == model.Short);
        if (status == null)
        {
            var statusFromDb = await AddStatusToBase(model);
            return statusFromDb;
        }
        return status;
    }
    public async Task<Status> AddStatusToBase(Status model)
    {
        await _db.Status.AddAsync(model);
        await _db.SaveChangesAsync();
        return model;
    }
}
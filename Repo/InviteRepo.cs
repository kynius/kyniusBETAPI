using kyniusBETAPI.AbstractModel;
using kyniusBETAPI.Data;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Interface.Repo;
using kyniusBETAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace kyniusBETAPI.Repo;

public class InviteRepo : IInviteRepo
{
    private readonly BetDB _db;
    public InviteRepo(BetDB db)
    {
        _db = db;
    }
    public async Task<Invite> SendLeagueInviteToUser(InviteDTO model)
    {
        model.Status = InviteStatus.Waiting;
        var invite = new Invite(model);
        await _db.Invite.AddAsync(invite);
        await _db.SaveChangesAsync();
        return invite;
    }

    public async Task<List<Invite>> GetAllInvitesByUserId(string userId, bool received, bool onlyWaiting = false)
    {
        var invites = new List<Invite>();
        if (received == true)
        {
            invites.AddRange(await _db.Invite.Where(x => x.InvitedUserId == userId).ToListAsync());
        }
        else
        {
            invites.AddRange(await _db.Invite.Where(x => x.InvitingUserId == userId).ToListAsync());
        }
        if (onlyWaiting == true)
        {
            invites = invites.Where(x => x.Status == InviteStatus.Waiting).ToList();
        }
        return invites;
    }

    public async Task<Invite?> GetInviteById(int id)
    {
        var invite = await _db.Invite.FirstOrDefaultAsync(x => x.Id == id);
        if (invite is not null)
        {
            return invite;
        }
        return null;
    }

    public async Task<Invite?> AcceptInvite(int id)
    {
        var invite = await GetInviteById(id);
        if (invite != null)
        {
            invite.Status = InviteStatus.Accepted;
            _db.Invite.Entry(invite).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        return invite;
    }

    public async Task<Invite?> RejectInvite(int id)
    {
        var invite = await GetInviteById(id);
        if (invite != null)
        {
            invite.Status = InviteStatus.Rejected;
            _db.Invite.Entry(invite).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        return invite;
    }
}
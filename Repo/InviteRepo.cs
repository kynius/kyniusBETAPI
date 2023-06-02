using kyniusBETAPI.NoSQLModel;
using kyniusBETAPI.Data;
using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.ViewModel;
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
    public async Task<InviteViewModel> SendLeagueInviteToUser(InviteDTO model)
    {
        var inviteFromDb = await _db.Invite.Include(x => x.League).FirstOrDefaultAsync(x =>
            x.InvitedUserId == model.InvitedUserId && x.InvitingUserId == model.InvitingUserId &&
            x.LeagueId == model.LeagueId);
        if (inviteFromDb != null)
        {
            return new InviteViewModel(inviteFromDb);
        }
        model.Status = InviteStatus.Waiting;
        var invite = new Invite(model);
        await _db.Invite.AddAsync(invite);
        await _db.SaveChangesAsync();
        return new InviteViewModel(invite);
    }

    public async Task<List<InviteViewModel>> GetAllInvitesByUserId(string userId, bool received, bool onlyWaiting = false)
    {
        var invites = new List<Invite>();
        if (received == true)
        {
            invites.AddRange(await _db.Invite.Include(x => x.League).Include(x => x.InvitedUser).Include(x => x.InvitingUser).Where(x => x.InvitedUserId == userId).ToListAsync());
        }
        else
        {
            invites.AddRange(await _db.Invite.Include(x => x.League).Include(x => x.InvitedUser).Include(x => x.InvitingUser).Where(x => x.InvitingUserId == userId).ToListAsync());
        }
        if (onlyWaiting == true)
        {
            invites = invites.Where(x => x.Status == InviteStatus.Waiting).ToList();
        }
        var mappedInvites = new List<InviteViewModel>();
        foreach (var i in invites)
        {
            mappedInvites.Add(new InviteViewModel(i));
        }
        return mappedInvites;
    }

    public async Task<Invite?> GetInviteById(int id)
    {
        var invite = await _db.Invite.Include(x => x.League).Include(x => x.InvitedUser).Include(x => x.InvitingUser).FirstOrDefaultAsync(x => x.Id == id);
        if (invite is not null)
        {
            return invite;
        }
        return null;
    }

    public async Task<InviteViewModel?> AcceptInvite(int id)
    {
        var invite = await GetInviteById(id);
        if (invite != null)
        {
            invite.Status = InviteStatus.Accepted;
            _db.Invite.Entry(invite).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        return new InviteViewModel(invite);
    }

    public async Task<InviteViewModel?> RejectInvite(int id)
    {
        var invite = await GetInviteById(id);
        if (invite != null)
        {
            invite.Status = InviteStatus.Rejected;
            _db.Invite.Entry(invite).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        return new InviteViewModel(invite);
    }
}
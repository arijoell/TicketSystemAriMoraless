using Microsoft.EntityFrameworkCore;
using TicketSystemAriMoraless.Data;
using TicketSystemAriMoraless.Enums;
using System.Security.Claims;
using TicketSystemAriMoraless.Models;

namespace TicketSystemAriMoraless.Services;

public class TicketService(IDbContextFactory<ApplicationDbContext> dbFactory)
{
    public async Task<List<Category>> GetCategoriesAsync()
    {
        using var context = dbFactory.CreateDbContext();
        return await context.Categories.ToListAsync();
    }

    public async Task CreateTicketAsync(Ticket ticket)
    {
        using var context = dbFactory.CreateDbContext();
        context.Tickets.Add(ticket);
        await context.SaveChangesAsync();
    }

    public async Task<List<Ticket>> GetTicketsForUserAsync(ClaimsPrincipal user)
    {
        using var context = dbFactory.CreateDbContext();

        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var query = context.Tickets
            .Include(t => t.Category)
            .Include(t => t.Author)
            .Include(t => t.Technician)
            .AsQueryable();

        if (user.IsInRole(Roles.Admin))
        {
            return await query.ToListAsync();
        }
        else if (user.IsInRole(Roles.Technician))
        {
            return await query
                .Where(t => t.TechnicianId == userId || t.Status == TicketStatus.Open)
                .ToListAsync();
        }
        else
        {
            return await query
                .Where(t => t.AuthorId == userId)
                .ToListAsync();
        }
    }

    public async Task<List<Ticket>> GetMyWorkAndRequestsAsync(string userId)
    {
        using var context = dbFactory.CreateDbContext();

        return await context.Tickets
            .Include(t => t.Category)
            .Include(t => t.Author)
            .Include(t => t.Technician)
            .Where(t => t.AuthorId == userId || t.TechnicianId == userId)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();
    }

    public async Task<List<Ticket>> GetAllTicketsAsync()
    {
        using var context = dbFactory.CreateDbContext();

        return await context.Tickets
            .Include(t => t.Category)
            .Include(t => t.Author)
            .Include(t => t.Technician)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();
    }

    public async Task UpdateTicketAsync(Ticket ticket)
    {
        using var context = dbFactory.CreateDbContext();

        ticket.UpdatedAt = DateTime.UtcNow;

        context.Entry(ticket).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task<List<ApplicationUser>> GetUsersByRoleAsync(string roleName)
    {
        using var context = dbFactory.CreateDbContext();

        var role = await context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        if (role == null) return new List<ApplicationUser>();

        var userIds = await context.UserRoles
            .Where(ur => ur.RoleId == role.Id)
            .Select(ur => ur.UserId)
            .ToListAsync();

        return await context.Users
            .Where(u => userIds.Contains(u.Id))
            .ToListAsync();
    }

    public async Task<Ticket?> GetTicketByIdAsync(int id)
    {
        using var context = dbFactory.CreateDbContext();

        return await context.Tickets
            .Include(t => t.Category)
            .Include(t => t.Author)
            .Include(t => t.Technician)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<List<ApplicationUser>> GetTechniciansAsync()
    {
        using var context = dbFactory.CreateDbContext();

        var techRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == Roles.Technician);
        if (techRole == null) return new List<ApplicationUser>();

        var techIds = await context.UserRoles
            .Where(ur => ur.RoleId == techRole.Id)
            .Select(ur => ur.UserId)
            .ToListAsync();

        return await context.Users
            .Where(u => techIds.Contains(u.Id))
            .ToListAsync();
    }

    public async Task UpdateTicketStatusAsync(int ticketId, TicketStatus newStatus, string? technicianId = null, string? performerId = null)
    {
        using var context = dbFactory.CreateDbContext();

        var ticket = await context.Tickets.FindAsync(ticketId);
        if (ticket == null) return;

        var oldStatus = ticket.Status;

        if (!string.IsNullOrEmpty(technicianId))
        {
            ticket.TechnicianId = technicianId;
        }

        ticket.Status = newStatus;
        ticket.UpdatedAt = DateTime.UtcNow;

        string systemMessage;

        if (!string.IsNullOrEmpty(technicianId) && oldStatus == newStatus)
        {
            systemMessage = "[SYSTEM] Technician assigned to this ticket.";
        }
        else
        {
            systemMessage = $"[SYSTEM] Status changed from {oldStatus} to {newStatus}.";
        }

        var systemComment = new TicketComment
        {
            TicketId = ticketId,
            UserId = performerId ?? ticket.AuthorId,
            Content = systemMessage,
            CreatedAt = DateTime.UtcNow
        };

        context.TicketComments.Add(systemComment);

        await context.SaveChangesAsync();
    }

    public async Task AddCommentAsync(TicketComment comment)
    {
        using var context = dbFactory.CreateDbContext();

        context.TicketComments.Add(comment);
        await context.SaveChangesAsync();
    }

    public async Task<List<TicketComment>> GetCommentsAsync(int ticketId)
    {
        using var context = dbFactory.CreateDbContext();

        return await context.TicketComments
            .Include(c => c.User)
            .Where(c => c.TicketId == ticketId)
            .OrderBy(c => c.CreatedAt)
            .ToListAsync();
    }

    public async Task<Dictionary<string, int>> GetTicketStatsAsync()
    {
        using var context = dbFactory.CreateDbContext();

        return new Dictionary<string, int>
        {
            ["Total"] = await context.Tickets.CountAsync(),
            ["Open"] = await context.Tickets.CountAsync(t => t.Status == TicketStatus.Open),
            ["InProgress"] = await context.Tickets.CountAsync(t => t.Status == TicketStatus.InProgress),
            ["Resolved"] = await context.Tickets.CountAsync(t => t.Status == TicketStatus.Resolved),
            ["Urgent"] = 0
        };
    }

    public async Task<List<ApplicationUser>> GetAllUsersAsync()
    {
        using var context = dbFactory.CreateDbContext();

        return await context.Users
            .OrderBy(u => u.Email)
            .ToListAsync();
    }
}
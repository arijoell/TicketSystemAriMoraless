using Microsoft.EntityFrameworkCore;
using TicketSystemAriMoraless.Data;
using TicketSystemAriMoraless.Enums;
using System.Security.Claims;

namespace TicketSystemAriMoraless.Services;

public class TicketService(IDbContextFactory<ApplicationDbContext> dbFactory)
{
    // 🔹 Obtener categorías
    public async Task<List<Category>> GetCategoriesAsync()
    {
        using var context = dbFactory.CreateDbContext();
        return await context.Categories.ToListAsync();
    }

    // 🔹 Crear ticket
    public async Task CreateTicketAsync(Ticket ticket)
    {
        using var context = dbFactory.CreateDbContext();
        context.Tickets.Add(ticket);
        await context.SaveChangesAsync();
    }

    // 🔹 Obtener tickets según el usuario
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

    // 🔹 ADMIN - ver todos los tickets
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

    // 🔹 Actualizar ticket completo
    public async Task UpdateTicketAsync(Ticket ticket)
    {
        using var context = dbFactory.CreateDbContext();

        ticket.UpdatedAt = DateTime.UtcNow;

        context.Entry(ticket).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    // 🔹 Obtener usuarios por rol
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

    // 🔹 Obtener ticket por ID
    public async Task<Ticket?> GetTicketByIdAsync(int id)
    {
        using var context = dbFactory.CreateDbContext();

        return await context.Tickets
            .Include(t => t.Category)
            .Include(t => t.Author)
            .Include(t => t.Technician)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    // 🔹 Obtener técnicos
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

    // 🔹 Asignar técnico / cambiar estado
    public async Task UpdateTicketStatusAsync(int ticketId, TicketStatus newStatus, string? technicianId = null)
    {
        using var context = dbFactory.CreateDbContext();

        var ticket = await context.Tickets.FindAsync(ticketId);
        if (ticket == null) return;

        ticket.Status = newStatus;

        if (!string.IsNullOrEmpty(technicianId))
            ticket.TechnicianId = technicianId;

        ticket.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync();
    }
}
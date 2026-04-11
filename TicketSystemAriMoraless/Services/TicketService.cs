using Microsoft.EntityFrameworkCore;
using TicketSystemAriMoraless.Data;

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
}
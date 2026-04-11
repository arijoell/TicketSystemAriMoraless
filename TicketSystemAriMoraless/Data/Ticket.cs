namespace TicketSystemAriMoraless.Data;

public class Ticket
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int Priority { get; set; }
    public string AuthorId { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
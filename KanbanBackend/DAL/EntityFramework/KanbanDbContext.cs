using Microsoft.EntityFrameworkCore;

public class KanbanDbContext : DbContext
{
    public KanbanDbContext(DbContextOptions<KanbanDbContext> options) : base(options)
    {
    }

    public DbSet<Board> Boards { get; set; }
    public DbSet<KanbanList> Lists { get; set; }
    public DbSet<Card> Cards { get; set; }
}
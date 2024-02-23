using Microsoft.EntityFrameworkCore;
using Todo.Storage;

namespace Todo.SqlServer;

public class TodoContext : DbContext
{
    public DbSet<TodoEntity> Todos { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;database=seesharp;User=sa;Password=1StrongPassword!;TrustServerCertificate=true");
    }
}

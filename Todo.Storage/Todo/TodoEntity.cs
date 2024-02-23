namespace Todo.Storage;

public class TodoEntity
{
    public bool Checked { get; set; }

    public string Name { get; set; }

    public Guid Id { get; set; }

    // Foreign key
    public Guid? UserId { get; set; }
    public UserEntity? User { get; set; }
}

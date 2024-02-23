
using Todo.Storage;

public class UserEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ICollection<TodoEntity> Todos { get; } = new List<TodoEntity>();
}

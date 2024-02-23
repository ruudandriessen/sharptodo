
using Todo.Storage;

public class UserEntity
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public ICollection<TodoEntity> Todos { get; } = new List<TodoEntity>();
}

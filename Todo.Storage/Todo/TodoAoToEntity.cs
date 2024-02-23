using Todo.Storage;

public class TodoAoToEntity
{
    public static TodoEntity Map(TodoAo todo)
    {
        return new TodoEntity()
        {
            Id = todo.Id,
            Name = todo.Name,
            Checked = todo.Checked
        };
    }
}

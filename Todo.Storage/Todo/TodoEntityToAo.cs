using Todo.Storage;

public class TodoEntityToAo
{
    public static TodoAo Map(TodoEntity todo)
    {
        return new TodoAo()
        {
            Id = todo.Id,
            Name = todo.Name,
            Checked = todo.Checked
        };
    }
}

using Todo.API;
using Todo.Storage;

public class TodoAoToDto
{
    public static TodoDto Map(TodoAo todo)
    {
        return new TodoDto()
        {
            Id = todo.Id,
            Name = todo.Name,
            Checked = todo.Checked
        };
    }
}

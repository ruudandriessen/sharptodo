using System.Text.Json;

namespace Todo.Storage;

public class TodoFileRepository : ITodoRepository
{
    private readonly string _path = "todos.json";

    public async Task<IEnumerable<Todo>> Get()
    {
        return (await Load()).Select(t => new Todo
        {
            Id = t.Id,
            Name = t.Name,
            Checked = t.Checked
        });
    }

    public async Task Add(Todo todo)
    {
        var todos = (await Load()).ToList();
        todos.Add(
            new TodoEntity
            {
                Id = todo.Id,
                Name = todo.Name,
                Checked = todo.Checked
            }
        );
        await Save(todos);
    }

    public async Task Delete(Todo Todo)
    {
        var Todos = (await Load()).ToList();
        Todos.RemoveAll(t => t.Id == Todo.Id);
        await Save(Todos);
    }

    public async Task Update(Todo Todo)
    {
        var Todos = (await Load()).ToList();
        var Index = Todos.FindIndex(t => t.Id == Todo.Id);
        Todos[Index] = new TodoEntity
        {
            Id = Todo.Id,
            Name = Todo.Name,
            Checked = Todo.Checked
        };
        await Save(Todos);
    }

    public async Task<Todo?> Get(Guid Id)
    {
        var Todos = (await Get()).ToList();
        return Todos.FirstOrDefault(t => t.Id == Id);
    }

    private async ValueTask<IEnumerable<TodoEntity>> Load()
    {
        if (!File.Exists(_path))
        {
            return new List<TodoEntity>();
        }

        using (FileStream fs = File.OpenRead(_path))
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<TodoEntity>>(fs);
        }
    }

    private Task Save(IEnumerable<TodoEntity> Todos)
    {
        return File.WriteAllTextAsync(
            _path,
            JsonSerializer.Serialize(Todos)
        );
    }
}

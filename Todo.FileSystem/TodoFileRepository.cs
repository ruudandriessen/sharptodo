using System.Text.Json;

namespace Todo.Storage;

public class TodoFileRepository : ITodoRepository
{
    private readonly string _path = "todos.json";

    public IEnumerable<Todo> Get()
    {
        return Load().Select(t => new Todo
        {
            Id = t.Id,
            Name = t.Name,
            Checked = t.Checked
        });
    }

    public void Add(Todo todo)
    {
        var todos = Load().ToList();
        todos.Add(
            new TodoEntity
            {
                Id = todo.Id,
                Name = todo.Name,
                Checked = todo.Checked
            }
        );
        Save(todos);
    }

    public void Delete(Todo Todo)
    {
        var Todos = Load().ToList();
        Todos.RemoveAll(t => t.Id == Todo.Id);
        Save(Todos);
    }

    public void Update(Todo Todo)
    {
        var Todos = Load().ToList();
        var Index = Todos.FindIndex(t => t.Id == Todo.Id);
        Todos[Index] = new TodoEntity
        {
            Id = Todo.Id,
            Name = Todo.Name,
            Checked = Todo.Checked
        };
        Save(Todos);
    }

    public Todo? Get(Guid Id)
    {
        var Todos = Get().ToList();
        return Todos.FirstOrDefault(t => t.Id == Id);
    }

    private IEnumerable<TodoEntity> Load()
    {
        if (!File.Exists(_path))
        {
            return new List<TodoEntity>();
        }

        return JsonSerializer.Deserialize<IEnumerable<TodoEntity>>(
            File.ReadAllText(_path)
        );
    }

    private void Save(IEnumerable<TodoEntity> Todos)
    {
        File.WriteAllText(
            _path,
            JsonSerializer.Serialize(Todos)
        );
    }
}

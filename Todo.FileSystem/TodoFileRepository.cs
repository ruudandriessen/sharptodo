using System.Text.Json;

namespace Todo.Storage;

public class TodoFileRepository : ITodoRepository
{
    private readonly string _path = "todos.json";

    public async Task<IEnumerable<TodoAo>> Get()
    {
        return (await Load()).Select(TodoEntityToAo.Map);
    }

    public async Task Add(TodoAo todo)
    {
        var todos = (await Load()).ToList();
        todos.Add(TodoAoToEntity.Map(todo));
        await Save(todos);
    }

    public async Task Delete(TodoAo Todo)
    {
        var Todos = (await Load()).ToList();
        Todos.RemoveAll(t => t.Id == Todo.Id);
        await Save(Todos);
    }

    public async Task Update(TodoAo Todo)
    {
        var Todos = (await Load()).ToList();
        var Index = Todos.FindIndex(t => t.Id == Todo.Id);
        Todos[Index] = TodoAoToEntity.Map(Todo);
        await Save(Todos);
    }

    public async Task<TodoAo?> Get(Guid Id)
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

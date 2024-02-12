namespace Todo.Storage;

public interface ITodoRepository
{
    Task<IEnumerable<Todo>> Get();
    Task Add(Todo todo);
    Task Update(Todo todo);
    Task Delete(Todo todo);
    Task<Todo?> Get(Guid id);
}

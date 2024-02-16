namespace Todo.Storage;

public interface ITodoRepository
{
    Task<IEnumerable<TodoAo>> Get();
    Task Add(TodoAo todo);
    Task Update(TodoAo todo);
    Task Delete(TodoAo todo);
    Task<TodoAo?> Get(Guid id);
}

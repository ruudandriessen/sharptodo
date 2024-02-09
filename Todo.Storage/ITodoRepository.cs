namespace Todo.Storage;

public interface ITodoRepository
{
    IEnumerable<Todo> Get();
    void Add(Todo todo);
    void Update(Todo todo);
    void Delete(Todo todo);
    Todo? Get(Guid id);
}

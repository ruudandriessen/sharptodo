namespace Todo.Storage;

public interface ITodoRepository
{
    IEnumerable<Todo> Get();
    void Add(Todo todo);
    void Update(Todo todo);
    void Delete(Guid id);
    Todo? Get(Guid id);
}

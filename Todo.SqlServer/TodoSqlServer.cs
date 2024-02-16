using Microsoft.EntityFrameworkCore;
using Todo.Storage;

namespace Todo.SqlServer;

public class TodoSqlServer : ITodoRepository
{
    private TodoContext _context = new TodoContext();

    public async Task<IEnumerable<TodoAo>> Get()
    {
        return (await this._context.Todos.ToListAsync())
            .Select(TodoEntityToAo.Map);
    }

    public async Task Add(TodoAo todo)
    {
        this._context.Todos
            .Add(TodoAoToEntity.Map(todo));

        await this._context.SaveChangesAsync();
    }

    public async Task Delete(TodoAo Todo)
    {
        await this._context.Todos
            .Where(cols => cols.Id == Todo.Id)
            .ExecuteDeleteAsync();
    }

    public async Task Update(TodoAo Todo)
    {
        await this._context.Todos
             .Where(cols => cols.Id == Todo.Id)
             .ExecuteUpdateAsync(row => row
                 .SetProperty(t => t.Name, Todo.Name)
                 .SetProperty(t => t.Checked, Todo.Checked)
             );
    }

    public async Task<TodoAo?> Get(Guid Id)
    {
        var Todo = await this._context.Todos
            .Where(cols => cols.Id == Id)
            .FirstOrDefaultAsync();

        if (Todo == null)
        {
            return null;
        }

        return TodoEntityToAo.Map(Todo);
    }
}

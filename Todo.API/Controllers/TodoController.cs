using Microsoft.AspNetCore.Mvc;
using Todo.Storage;

namespace Todo.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private ITodoRepository _repository;

    public TodoController(ITodoRepository repository)
    {
        this._repository = repository;
    }

    [HttpGet]
    [ProducesResponseType<IEnumerable<TodoDto>>(StatusCodes.Status200OK)]
    public async Task<IResult> GetTodos()
    {
        return Results.Ok(await this._repository.Get());
    }

    [HttpPut("{id}")]
    [ProducesResponseType<TodoDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> UpdateTodo(Guid id)
    {
        Storage.Todo? Todo = await this._repository.Get(id);
        if (Todo == null)
        {
            return Results.NotFound();
        }

        Todo.Checked = !Todo.Checked;
        await this._repository.Update(Todo);
        return Results.Ok(Todo);
    }

    [HttpPost]
    [ProducesResponseType<TodoDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> AddTodo(PostTodoDto todoDTO)
    {
        Storage.Todo todo = new Storage.Todo
        {
            Id = Guid.NewGuid(),
            Name = todoDTO.name,
            Checked = false
        };
        await this._repository.Add(todo);
        return Results.Ok(todo);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> DeleteTodo(Guid Id)
    {
        Storage.Todo? Todo = await this._repository.Get(Id);
        if (Todo == null)
        {
            return Results.NotFound();
        }

        await this._repository.Delete(Todo);
        return Results.Ok();
    }
}

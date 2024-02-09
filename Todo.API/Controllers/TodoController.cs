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
    public IResult GetTodos()
    {
        return Results.Ok(this._repository.Get());
    }

    [HttpPut("{id}")]
    [ProducesResponseType<TodoDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IResult UpdateTodo(Guid id)
    {
        Storage.Todo? Todo = this._repository.Get(id);
        if (Todo == null)
        {
            return Results.NotFound();
        }

        Todo.Checked = !Todo.Checked;
        this._repository.Update(Todo);
        return Results.Ok(Todo);
    }

    [HttpPost]
    [ProducesResponseType<TodoDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IResult AddTodo(PostTodoDto todoDTO)
    {
        Storage.Todo todo = new Storage.Todo
        {
            Id = Guid.NewGuid(),
            Name = todoDTO.name,
            Checked = false
        };
        this._repository.Add(todo);
        return Results.Ok(todo);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IResult DeleteTodo(Guid Id)
    {
        Storage.Todo? Todo = this._repository.Get(Id);
        if (Todo == null)
        {
            return Results.NotFound();
        }

        this._repository.Delete(Todo);
        return Results.Ok();
    }
}

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

    [HttpGet(Name = "todo")]
    [ProducesResponseType<IEnumerable<TodoDto>>(StatusCodes.Status200OK)]
    public IResult GetTodos()
    {
        return Results.Ok(this._repository.Get());
    }

    [HttpPut(Name = "todo/{id:guid}")]
    [ProducesResponseType<TodoDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IResult UpdateTodo(Guid id)
    {
        Storage.Todo? todo = this._repository.Get(id);
        if (todo == null)
        {
            return Results.NotFound();
        }

        todo.Checked = !todo.Checked;
        this._repository.Update(todo);
        return Results.Ok(todo);
    }

    [HttpPost(Name = "todo")]
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
}

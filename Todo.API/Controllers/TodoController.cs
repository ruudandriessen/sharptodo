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
    public async Task<ActionResult<IEnumerable<TodoDto>>> GetTodos()
    {
        var TodoList = await this._repository.Get();
        return Ok(TodoList.Select(TodoAoToDto.Map));
    }

    [HttpPut("{id}")]
    [ProducesResponseType<TodoDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TodoDto>> UpdateTodo(Guid id)
    {
        TodoAo? Todo = await this._repository.Get(id);
        if (Todo == null)
        {
            return NotFound();
        }

        Todo.Checked = !Todo.Checked;
        await this._repository.Update(Todo);
        return Ok(TodoAoToDto.Map(Todo));
    }

    [HttpPost]
    [ProducesResponseType<TodoDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TodoDto>> AddTodo(PostTodoDto todoDTO)
    {
        var todo = new TodoAo
        {
            Name = todoDTO.Name,
        };
        await this._repository.Add(todo);
        return Ok(TodoAoToDto.Map(todo));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteTodo(Guid Id)
    {
        TodoAo? Todo = await this._repository.Get(Id);
        if (Todo == null)
        {
            return NotFound();
        }

        await this._repository.Delete(Todo);
        return Ok();
    }
}

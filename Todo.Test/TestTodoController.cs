using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Todo.API.Controllers;
using Todo.Storage;

namespace Todo.Test;

public class TestTodoController
{
    private readonly Mock<ITodoRepository> _mockRepository;
    private readonly TodoController _controller;

    public TestTodoController()
    {
        _mockRepository = new Mock<ITodoRepository>();
        _controller = new TodoController(_mockRepository.Object);
    }

    [Fact]
    public void TestTodoListIs200()
    {
        _mockRepository
            .Setup(repo => repo.Get())
            .Returns(new List<TodoAo>());

        var result = _controller.GetTodos();

        Assert.IsType<Ok<IEnumerable<TodoAo>>>(result);

        var okResult = (Ok<IEnumerable<TodoAo>>)result;
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public void TestTodoItemUpdate404()
    {
        var guid = new Guid();
        var result = _controller.UpdateTodo(guid);

        Assert.IsType<NotFound>(result);
    }

    [Fact]
    public void TestTodoItemUpdate200()
    {
        var guid = new Guid();
        var resultingTodo = new TodoAo
        {
            Id = guid,
            Checked = false,
            Name = "getswifty",
        };

        _mockRepository
            .Setup(repo => repo.Get(guid))
            .Returns(resultingTodo);

        var result = _controller.UpdateTodo(guid);

        Assert.IsType<Ok<TodoAo>>(result);
        var okResult = (Ok<TodoAo>)result;

        Assert.NotNull(okResult.Value);
        Assert.Equal(okResult.Value, resultingTodo);
    }
}

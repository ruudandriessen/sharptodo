namespace Todo.API;

public class TodoDto
{
    public bool Checked { get; set; }

    public string Name { get; set; }

    public Guid Id { get; set; }
}

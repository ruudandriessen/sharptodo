namespace Todo.Storage;

public class TodoAo
{
    public bool Checked { get; set; } = false;

    public string Name { get; set; }

    public Guid Id { get; set; } = Guid.NewGuid();
}

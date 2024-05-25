namespace Notess.Models;

public sealed class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public bool IsEditing { get; private set; }

    public void ToggleEditing() => IsEditing = !IsEditing;

    public override string ToString() => $"{Id} {Title} {Content}";
}
namespace Notess.Models;

public sealed class TodoItem
{
    public TodoItem(string title, string content)
    {
        EditTitle = Title = title;
        EditContent = Content = content;
    }

    public TodoItem(int id, string title, string content, DateTime createdDate)
    {
        Id = id;
        EditTitle = Title = title;
        EditContent = Content = content;
        CreatedDate = createdDate;
    }

    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public bool IsEditing { get; private set; }
    public string EditTitle { get; set; }
    public string EditContent { get; set; }

    public void ToggleEditing()
    {
        IsEditing = !IsEditing;

        if (IsEditing)
        {
            EditTitle = Title;
            EditContent = Content;
        }
    }

    public override string ToString() => $"{Id} {Title} {Content}";
}
namespace Notess.Models;

/// <summary>
/// Represents a todo item in the application.
/// </summary>
public sealed class TodoItem
{
    /// <summary>
    /// Initializes a new instance of the TodoItem class with the specified title.
    /// </summary>
    /// <param name="title">The title of the todo item.</param>
    public TodoItem(string title)
    {
        EditTitle = Title = title;
    }

    /// <summary>
    /// Initializes a new instance of the TodoItem class with the specified properties.
    /// </summary>
    /// <param name="id">The unique identifier of the todo item.</param>
    /// <param name="title">The title of the todo item.</param>
    /// <param name="content">The content of the todo item.</param>
    /// <param name="createdDate">The date and time when the todo item was created.</param>
    public TodoItem(int id, string title, string content, DateTime createdDate)
    {
        Id = id;
        EditTitle = Title = title;
        EditContent = Content = content;
        CreatedDate = createdDate;
    }

    /// <summary>
    /// The unique identifier of the todo item.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The title of the todo item.
    /// </summary>
    public string Title { get; set; } = "";

    /// <summary>
    /// The content of the todo item.
    /// </summary>
    public string Content { get; set; } = "";

    /// <summary>
    /// The date and time when the todo item was created.
    /// </summary>
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Indicates whether the todo item is currently being edited.
    /// </summary>
    public bool IsEditing { get; private set; }

    /// <summary>
    /// The title of the todo item being edited.
    /// </summary>
    public string EditTitle { get; set; } = "";

    /// <summary>
    /// The content of the todo item being edited.
    /// </summary>
    public string EditContent { get; set; } = "";

    /// <summary>
    /// Toggles the editing state of the todo item.
    /// </summary>
    public void ToggleEditing()
    {
        IsEditing = !IsEditing;

        if (IsEditing)
        {
            EditTitle = Title;
            EditContent = Content;
        }
    }

    /// <summary>
    /// Returns a string representation of the todo item.
    /// </summary>
    /// <returns>A string containing the ID, title, and content of the todo item.</returns>
    public override string ToString() => $"{Id} {Title} {Content}";
}
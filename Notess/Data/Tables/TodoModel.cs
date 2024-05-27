using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notess.Data.Tables;

/// <summary>
/// Represents a todo item in the database.
/// </summary>
[Table("Todos")]
public sealed record TodoModel
{
    public TodoModel(int userId, int id, string title, string content, DateTime createdDate)
    {
        UserId = userId;
        Id = id;
        Title = title;
        Content = content;
        CreatedDate = createdDate;
    }

    /// <summary>
    /// The unique identifier of the todo item.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// The ID of the user associated with the todo item.
    /// </summary>
    public int UserId { get; set; }

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
    public DateTime CreatedDate { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notess.Data.Tables;

/// <summary>
/// Represents a user in the application.
/// </summary>
[Table("Users")]
public sealed class UserModel
{
    /// <summary>
    /// The unique identifier of the user.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// The date and time when the user was created.
    /// </summary>
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// The collection of todo items associated with the user.
    /// </summary>
    public ICollection<TodoModel> TodoItems { get; }
}
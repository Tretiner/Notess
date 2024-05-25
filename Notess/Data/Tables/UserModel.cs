using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notess.Data.Tables;

[Table("Users")]
public sealed class UserModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public ICollection<TodoModel> TodoItems { get; }
};
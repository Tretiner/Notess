using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notess.Data.Tables;

[Table("Todos")]
public sealed record TodoModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; } = "";

    public string Content { get; set; } = "";

    public DateTime CreatedDate { get; set; }
}
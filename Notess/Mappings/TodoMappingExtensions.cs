using Notess.Data.Tables;
using Notess.Models;

namespace Notess.Mappings;

public static class TodoMappingExtensions
{
    public static TodoItem ToTodoItem(this TodoModel todo)
        => new(todo.Id, todo.Title, todo.Content, todo.CreatedDate);

    public static TodoModel ToTodoModel(this TodoItem todo, int userId)
        => new(userId, todo.Id, todo.Title, todo.Content, todo.CreatedDate);
}
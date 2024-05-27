using Notess.Data.Tables;
using Notess.Models;

namespace Notess.Mappings;

/// <summary>
/// Provides extension methods for mapping between TodoItem and TodoModel.
/// </summary>
public static class TodoMappingExtensions
{
    /// <summary>
    /// Maps a TodoModel to a TodoItem.
    /// </summary>
    /// <param name="todo">The TodoModel to be mapped.</param>
    /// <returns>A new TodoItem instance with the mapped properties.</returns>
    public static TodoItem ToTodoItem(this TodoModel todo)
        => new(todo.Id, todo.Title, todo.Content, todo.CreatedDate);

    /// <summary>
    /// Maps a TodoItem to a TodoModel with the specified user ID.
    /// </summary>
    /// <param name="todo">The TodoItem to be mapped.</param>
    /// <param name="userId">The user ID to be associated with the TodoModel.</param>
    /// <returns>A new TodoModel instance with the mapped properties and user ID.</returns>
    public static TodoModel ToTodoModel(this TodoItem todo, int userId)
        => new(userId, todo.Id, todo.Title, todo.Content, todo.CreatedDate);
}
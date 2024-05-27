using Notess.Models;

namespace Notess.Components.Pages;

/// <summary>
/// Represents the Home page of the application.
/// Holds methods and attributes for html bindings.
/// </summary>
public partial class Home
{
    /// <summary> The user ID associated with the current user. Saved in cookies </summary>
    private int _userId;

    /// <summary>
    /// Initializes the Home page and retrieves the user's todos.
    /// </summary>
    protected override async Task OnInitializedAsync()
    {
        EnsureUserIdCreated(_httpContextAccessor.HttpContext!, out _userId);

        Todos = await _todoService.GetTodos(_userId);
    }

    /// <summary> Adds todo item to database </summary>
    /// <remarks> Writes generated id to <see cref="Notess.Models.TodoItem.Id">TodoItem.Id</see></remarks>
    /// <param name="todo">A todo item to add to database</param>
    private void AddTodo(TodoItem todo) => _todoService.AddTodo(_userId, todo);

    /// <summary> Updates todo item by its id </summary>
    /// <param name="todo">Todo item with fields to update and id of todo in database</param>
    private void UpdateTodo(TodoItem todo) => _todoService.UpdateTodo(_userId, todo);

    /// <summary> Removes todo by id </summary>
    /// <param name="todoId">The id of todo in database</param>
    private void RemoveTodo(int todoId) => _todoService.RemoveTodo(todoId);

    /// <summary>
    /// Ensures that a user id exists in cookies, otherwise creates it
    /// </summary>
    /// <param name="httpContext">The HttpContext of current connection</param>
    /// <param name="userId">The output parameter to store the user ID.</param>
    private static void EnsureUserIdCreated(HttpContext httpContext, out int userId)
    {
        if (httpContext.Request.Cookies.TryGetValue("user_id", out var rawUserId) && int.TryParse(rawUserId, out userId))
            return;

        userId = Random.Shared.Next();
        httpContext.Response.Cookies.Append("user_id", userId.ToString());
    }
}
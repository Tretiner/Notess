using Notess.Models;

namespace Notess.Components.Pages;

public partial class Home
{
    private int _userId;

    protected override async Task OnInitializedAsync()
    {
        EnsureUserIdCreated(_httpContextAccessor.HttpContext!, out _userId);

        todos = await _todoService.GetTodos(_userId);
    }

    private void AddTodo(TodoItem todo) => _todoService.AddTodo(_userId, todo);

    private void UpdateTodo(TodoItem todo) => _todoService.UpdateTodo(_userId, todo);

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
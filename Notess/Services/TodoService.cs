using Microsoft.EntityFrameworkCore;
using Notess.Data;
using Notess.Data.Tables;
using Notess.Models;

namespace Notess.Services;

/// <summary>
/// Provides services for managing todo items in the application.
/// </summary>
public sealed class TodoService
{
    private readonly AppDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the TodoService class with the specified database context.
    /// </summary>
    /// <param name="dbContext">The AppDbContext instance to be used by the service.</param>
    public TodoService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Retrieves a list of todo items for the specified user.
    /// </summary>
    /// <param name="userId">The ID of the user whose todo items should be retrieved.</param>
    /// <returns>A list of TodoItem objects representing the user's todo items.</returns>
    public async Task<List<TodoItem>> GetTodos(int userId)
    {
        var user = await _dbContext.Users
            .Include(userModel => userModel.TodoItems)
            .FirstOrDefaultAsync(x => x.Id == userId);

        return user?.TodoItems.Select(x => new TodoItem(id: x.Id, title: x.Title, content: x.Content, createdDate: x.CreatedDate)).ToList() ?? [];
    }

    /// <summary>
    /// Adds a new todo item for the specified user.
    /// </summary>
    /// <param name="userId">The ID of the user for whom the todo item should be added.</param>
    /// <param name="todoItem">The TodoItem object representing the new todo item.</param>
    public void AddTodo(int userId, TodoItem todoItem)
    {
        EnsureUserCreated(userId);

        var todoModel = new TodoModel
        {
            UserId = userId,
            Title = todoItem.Title,
            Content = todoItem.Content,
            CreatedDate = todoItem.CreatedDate
        };

        _dbContext.Todos.Add(todoModel);
        _dbContext.SaveChanges();

        todoItem.Id = todoModel.Id;
    }

    /// <summary>
    /// Updates an existing todo item for the specified user.
    /// </summary>
    /// <param name="userId">The ID of the user whose todo item should be updated.</param>
    /// <param name="todoItem">The TodoItem object representing the updated todo item.</param>
    public void UpdateTodo(int userId, TodoItem todoItem)
    {
        EnsureUserCreated(userId);

        var todoToUpdate = _dbContext.Todos.FirstOrDefault(x => x.UserId == userId && x.Id == todoItem.Id);

        if (todoToUpdate is null)
            return;

        todoToUpdate.Title = todoItem.EditTitle;
        todoToUpdate.Content = todoItem.EditContent;

        _dbContext.Todos.Update(todoToUpdate);
        _dbContext.SaveChanges();

        todoItem.Title = todoItem.EditTitle;
        todoItem.Content = todoItem.EditContent;
    }

    /// <summary>
    /// Removes a todo item with the specified ID from the database.
    /// </summary>
    /// <param name="id">The ID of the todo item to be removed.</param>
    public void RemoveTodo(int id)
    {
        var todo = _dbContext.Todos.FirstOrDefault(x => x.Id == id);

        if (todo is null)
            return;

        _dbContext.Todos.Remove(todo);
        _dbContext.SaveChanges();
    }

    /// <summary>
    /// Ensures that a user with the specified ID exists in the database.
    /// </summary>
    /// <param name="userId">The ID of the user to be created.</param>
    private void EnsureUserCreated(int userId)
    {
        if (_dbContext.Users.FirstOrDefault(x => x.Id == userId) == null)
            _dbContext.Users.Add(new UserModel { Id = userId });
    }
}
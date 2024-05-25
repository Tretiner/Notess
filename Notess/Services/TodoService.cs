using Microsoft.EntityFrameworkCore;
using Notess.Data;
using Notess.Data.Tables;
using Notess.Models;

namespace Notess.Services;

public sealed class TodoService(AppDbContext _dbContext)
{
    public async Task<List<TodoItem>> GetTodos(int userId)
    {
        var user = await _dbContext.Users
            .Include(userModel => userModel.TodoItems)
            .FirstOrDefaultAsync(x => x.Id == userId);

        return user?.TodoItems.Select(x => new TodoItem(id: x.Id, title: x.Title, content: x.Content, createdDate: x.CreatedDate)).ToList() ?? [];
    }

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

    private void EnsureUserCreated(int userId)
    {
        if (_dbContext.Users.FirstOrDefault(x => x.Id == userId) == null)
            _dbContext.Users.Add(new UserModel { Id = userId });
    }

    public void RemoveTodo(int id)
    {
        var todo = _dbContext.Todos.FirstOrDefault(x => x.Id == id);

        if (todo is null)
            return;

        _dbContext.Todos.Remove(todo);
        _dbContext.SaveChanges();
    }
}
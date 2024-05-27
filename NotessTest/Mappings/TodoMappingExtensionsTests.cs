using Notess.Data.Tables;
using Notess.Mappings;
using Notess.Models;

namespace NotessTest.Mappings;

/// <summary>
/// Contains unit tests for the TodoMappingExtensions class.
/// </summary>
public class TodoMappingExtensionsTests
{
    /// <summary>
    /// Tests that the ToTodoItem extension method correctly maps from a TodoModel.
    /// </summary>
    [Fact]
    public void ToTodoItem_MapsFromTodoModel()
    {
        // Arrange
        var todoModel = new TodoModel(userId: 1, id: 1, title: "Test Todo", content: "Test Content", createdDate: DateTime.UtcNow);

        // Act
        var todoItem = todoModel.ToTodoItem();

        // Assert
        Assert.Equal(todoModel.Id, todoItem.Id);
        Assert.Equal(todoModel.Title, todoItem.Title);
        Assert.Equal(todoModel.Content, todoItem.Content);
        Assert.Equal(todoModel.CreatedDate, todoItem.CreatedDate);
    }

    /// <summary>
    /// Tests that the ToTodoModel extension method correctly maps from a TodoItem.
    /// </summary>
    [Fact]
    public void ToTodoModel_MapsFromTodoItem()
    {
        // Arrange
        var userId = 1;
        var todoItem = new TodoItem(id: 1, title: "Test Todo", content: "Test Content", createdDate: DateTime.UtcNow);

        // Act
        var todoModel = todoItem.ToTodoModel(userId);

        // Assert
        Assert.Equal(userId, todoModel.UserId);
        Assert.Equal(todoItem.Id, todoModel.Id);
        Assert.Equal(todoItem.Title, todoModel.Title);
        Assert.Equal(todoItem.Content, todoModel.Content);
        Assert.Equal(todoItem.CreatedDate, todoModel.CreatedDate);
    }
}
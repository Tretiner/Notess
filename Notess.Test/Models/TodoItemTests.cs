using Notess.Models;

namespace Notess.Test.Models;

public class TodoItemTests
{
    [Fact]
    public void ToggleEditing_SetsEditingStateAndCopiesValues()
    {
        // Arrange
        var todoItem = new TodoItem(id: 1, title: "Test Todo", content: "Test Content", createdDate: DateTime.UtcNow);

        // Act
        todoItem.ToggleEditing();

        // Assert
        Assert.True(todoItem.IsEditing);
        Assert.Equal(todoItem.Title, todoItem.EditTitle);
        Assert.Equal(todoItem.Content, todoItem.EditContent);
    }

    [Fact]
    public void ToString_ReturnsExpectedString()
    {
        // Arrange
        var todoItem = new TodoItem(id: 1, title: "Test Todo", content: "Test Content", createdDate: DateTime.UtcNow);

        // Act
        var result = todoItem.ToString();

        // Assert
        Assert.Equal($"{todoItem.Id} {todoItem.Title} {todoItem.Content}", result);
    }
}
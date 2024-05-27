using Notess.Models;

namespace NotessTest.Models;

/// <summary>
/// Contains unit tests for the TodoItem class.
/// </summary>
public class TodoItemTests
{
    /// <summary>
    /// Tests that the ToggleEditing method sets the editing state and copies values correctly.
    /// </summary>
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

    /// <summary>
    /// Tests that the ToString method returns the expected string representation of the todo item.
    /// </summary>
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
using Mario.Application.TodoItems.Commands.CreateTodoItem;
using Mario.Application.TodoItems.Commands.DeleteTodoItem;
using Mario.Application.TodoLists.Commands.CreateTodoList;
using Mario.Domain.Entities;

using static Mario.Application.FunctionalTests.Testing;

namespace Mario.Application.FunctionalTests.TodoItems.Commands;
public class DeleteTodoItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand(99);

        await Should.ThrowAsync<NotFoundException>(() => SendAsync(command));
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var itemId = await SendAsync(new CreateTodoItemCommand
        {
            ListId = listId,
            Title = "New Item"
        });

        await SendAsync(new DeleteTodoItemCommand(itemId));

        var item = await FindAsync<TodoItem>(itemId);

        item.ShouldBeNull();
    }
}

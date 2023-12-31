namespace Dotnet_DS_Lib.Tests.QueueTests;
using Dotnet_DS_Lib.LLQueue;

public class QueueTests
{
    private void EnqueueAndPeekTest<T>(T item)
    {
        // Arrange
        var queue = new LLQueue<int>();

        // Act
        queue.Enqueue(1);

        // Assert
        Assert.Equal(1, queue.Peek());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Enqueue_ShouldAddIntItem(int itemToAdd)
    {
        EnqueueAndPeekTest(itemToAdd);
    }

    [Theory]
    [InlineData("apple")]
    [InlineData("banana")]
    public void Enqueue_ShouldAddStringItem(string itemToAdd)
    {
        EnqueueAndPeekTest(itemToAdd);
    }

    // You can add more tests for other types as needed

}
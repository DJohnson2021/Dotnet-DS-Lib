namespace Dotnet_DS_Lib.Tests.TreeTests;
using Dotnet_DS_Lib.Tree;

public class TreeTests
{
    [Fact]
    public void Add_ShouldAddNode()
    {
        // Arrange
        var tree = new Tree<int>(1);

        // Act
        tree.Add(2);

        // Assert
        Assert.Single(tree.Root.Children);
        Assert.Equal(2, tree.Root.Children.First().Value);
    }

    [Fact]
    public void TraverseBFS_ShouldTraverseInBreadthFirstOrder()
    {
        // Arrange
        var tree = new Tree<int>(1);
        tree.Add(2);
        tree.Add(3);
        var resultList = new List<int>();

        // Act
        tree.TraverseBFS(value => resultList.Add(value));

        // Assert
        Assert.Equal(new List<int> { 1, 2, 3 }, resultList);
    }

    [Fact]
    public void TraverseDFS_ShouldTraverseInDepthFirstOrder()
    {
        // Arrange
        var tree = new Tree<int>(1);
        tree.Add(2);
        tree.Root.Children.First().Children.Add(new TreeNode<int>(4)); // Add child to first node
        tree.Add(3);
        var resultList = new List<int>();

        // Act
        tree.TraverseDFS(value => resultList.Add(value));

        // Assert
        Assert.Equal(new List<int> { 1, 2, 4, 3 }, resultList); // Adjust expected order if necessary
    }
}

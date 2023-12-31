namespace Dotnet_DS_Lib.Tree;
using Dotnet_DS_Lib.LLQueue;
using Dotnet_DS_Lib.LLStack;

interface ITree<T>
{
    void Add(T value);
    void Add(TreeNode<T> node);
    void Traverse(Action<T> action);
    void TraverseBFS(Action<T> action);
    void TraverseDFS(Action<T> action);
}

public class TreeNode<T> 
{
    public T Value { get; set; }
    public List<TreeNode<T>> Children { get; set; } 

    public TreeNode(T value)
    {
        Value = value;
        Children = new List<TreeNode<T>>();
    }
}

public class Tree<T> : ITree<T>
{
    public TreeNode<T> Root { get; set; }

    public Tree(T value)
    {
        Root = new TreeNode<T>(value);
    }

    public void Add(T value)
    {
        var node = new TreeNode<T>(value);
        Root.Children.Add(node);
    }

    public void Add(TreeNode<T> node)
    {
        Root.Children.Add(node);
    }

    public void Traverse(Action<T> action)
    {
        Traverse(Root, action);
    }

    private void Traverse(TreeNode<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        action(node.Value);
        foreach (var child in node.Children)
        {
            Traverse(child, action);
        }
    }

    public void TraverseBFS(Action<T> action)
    {
        var queue = new LLQueue<TreeNode<T>>();
        queue.Enqueue(Root);
        while (!queue.IsEmpty())
        {
            var node = queue.Dequeue();
            action(node.Value);
            foreach (var child in node.Children)
            {
                queue.Enqueue(child);
            }
        }
    }

    public void TraverseDFS(Action<T> action)
    {
        var stack = new LLStack<TreeNode<T>>();
        stack.Push(Root);
        while (!stack.IsEmpty())
        {
            var node = stack.Pop();
            action(node.Value);

            // Push the children in reverse order so that the first child is processed last
            for (int i = node.Children.Count - 1; i >= 0; i--)
            {
                stack.Push(node.Children[i]);
            }
        }
    }

}
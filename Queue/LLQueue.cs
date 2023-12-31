namespace Dotnet_DS_Lib.LLQueue;

interface ILLQueue<T>
{
    void Enqueue(T data);
    T Dequeue();
    T Peek();
    bool IsEmpty();
    //bool IsFull();
    void Print();
}

public class LLQueueNode<T>
{
    public T data;
    public LLQueueNode<T>? next;
    public LLQueueNode(T data)
    {
        this.data = data;
        this.next = null;
    }
}

public class LLQueue<T> : ILLQueue<T>
{
    private LLQueueNode<T>? front;
    private LLQueueNode<T>? rear;

    public LLQueue()
    {
        this.front = null;
        this.rear = null;
    }

    public void Enqueue(T data)
    {
        LLQueueNode<T> newNode = new(data);
        if (this.rear == null)
        {
            this.front = newNode;
            this.rear = newNode;
            return;
        }

        this.rear.next = newNode;
        this.rear = newNode;
    }

    public T Dequeue()
    {
        if (this.front == null)
        {
            throw new Exception("LLQueue is empty");
        }

        LLQueueNode<T> temp = this.front;
        this.front = this.front.next;

        if (this.front == null)
        {
            this.rear = null;
        }

        return temp.data;
    }

    public bool IsEmpty()
    {
        return this.front == null;
    }

    public T Peek()
    {
        if (this.front == null)
        {
            throw new Exception("LLQueue is empty");
        }

        return this.front.data;
    }

    public void Print()
    {
        if (this.front == null)
        {
            throw new Exception("LLQueue is empty");
        }

        LLQueueNode<T>? current = this.front;
        while (current != null)
        {
            Console.Write(current.data + " ");
            current = current.next;
        }
        Console.WriteLine();
    }
}

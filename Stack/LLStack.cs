namespace Dotnet_DS_Lib.LLStack
{
    public interface ILLStack<T>
    {
        void Push(T data);
        T Pop();
        T Peek();
        bool IsEmpty();
        //bool IsFull();
        void Print();
    }

    public class LLStackNode<T>
    {
        public T data;
        public LLStackNode<T>? next;
        public LLStackNode(T data)
        {
            this.data = data;
            this.next = null;
        }
    }

    public class LLStack<T> : ILLStack<T>
    {
        private LLStackNode<T>? top;

        public LLStack()
        {
            this.top = null;
        }

        public void Push(T data)
        {
            LLStackNode<T> newNode = new(data);
            newNode.next = this.top;
            this.top = newNode;
        }

        public T Pop()
        {
            if (this.top == null)
            {
                throw new Exception("LLStack is empty");
            }

            LLStackNode<T> temp = this.top;
            this.top = this.top.next;
            return temp.data;
        }

        public T Peek()
        {
            if (this.top == null)
            {
                throw new Exception("LLStack is empty");
            }

            return this.top.data;
        }

        public bool IsEmpty()
        {
            return this.top == null;
        }

        public void Print()
        {
            if (this.top == null)
            {
                throw new Exception("LLStack is empty");
            }

            LLStackNode<T>? current = this.top;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}
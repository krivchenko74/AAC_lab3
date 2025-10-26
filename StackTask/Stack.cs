namespace Lab3.StackTask;


public class Stack<T>
{
    private bool ShowLogs = false;
    
    public int Count { get; private set; }
    private class Node<T>
    {
        public T Data;
        public Node<T>? Next;

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
    private Node<T>? top;

    public Stack()
    {
        top = null;
    }
    
    public Stack(bool showLogs)
    {
        top = null;
        ShowLogs = showLogs;
    }
    
    public void Push(T elem)
    {
        var newNode = new Node<T>(elem);
        newNode.Next = top;
        top = newNode;
        Count++;
        if (ShowLogs) Console.WriteLine($"Pushed {elem.ToString()}");
    }
    
    public bool IsEmpty()
    {
        if (top == null)
        {
            if (ShowLogs) Console.WriteLine("Stack is empty!");
        }
        else
        {
            if (ShowLogs) Console.WriteLine("Stack is not empty");
        }
        return top == null;
    }

    public T? Pop()
    {
        if (IsEmpty())
        {
            // if (ShowLogs) Console.WriteLine("Stack is empty!");
            return default;
        }
        var value = top!.Data;
        if (ShowLogs) Console.WriteLine($"Popped {value.ToString()}");
        top = top.Next;
        Count--;
        return value;
    }

    public T? Peek()
    {
        if (IsEmpty())
        {
            if (ShowLogs) Console.WriteLine("Stack is empty!");
            return default;
        }
        var value = top!.Data;
        if (ShowLogs) Console.WriteLine($"Peeked {value.ToString()}");
        return value;
    }
    
    public T? Top()
    {
        if (IsEmpty())
        {
            if (ShowLogs) Console.WriteLine("Stack is empty!");
            return default;
        }
        if (ShowLogs) Console.WriteLine($"Top: {top!.Data.ToString()}");
        return top!.Data;
    }
    
    public void Print()
    {
        if (IsEmpty())
        {
            if (ShowLogs) Console.WriteLine("Stack is empty!");
            return;
        }

        if (ShowLogs) Console.Write("Stack items: ");
        var current = top;
        while (current != null)
        {
            if (ShowLogs) Console.Write($"{current.Data} ");
            current = current.Next;
        }
        if (ShowLogs) Console.WriteLine();
    }
}

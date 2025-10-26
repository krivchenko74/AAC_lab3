namespace Lab3.QueueTask;

public class LinkedQueue<T>
{
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

    private Node<T>? Head;
    private Node<T>? Tail;
    private readonly bool ShowLogs;

    public LinkedQueue()
    {
        Head = Tail = null;
    }
    
    public LinkedQueue(bool showLogs)
    {
        Head = Tail = null;
        ShowLogs = showLogs;
    }

    public bool IsEmpty()
    {
        if (Head == null)
        {
            if (ShowLogs) Console.WriteLine("Очередь пуста!");
            return true;
        }
        if (ShowLogs) Console.WriteLine("Очередь не пуста!");
        return false;
    }
    
    public void Enqueue(T elem)
    {
        Node<T> node = new Node<T>(elem);

        if (IsEmpty())
        {
            Head = Tail = node;
        }
        else
        {
            Tail!.Next = node;
            Tail = node;
        }

        if (ShowLogs) Console.WriteLine($"Добавлен элемент: {elem.ToString()}");
    }

    public T? Dequeue()
    {
        if (IsEmpty())
        {
            if (ShowLogs) Console.WriteLine("Очередь пуста!");
            return default;
        }

        T value = Head!.Data;
        Head = Head.Next;

        if (Head == null)
            Tail = null;

        if (ShowLogs) Console.WriteLine($"Удалён элемент: {value.ToString()}");
        return value;
    }

    public T? Peek()
    {
        if (IsEmpty())
        {
            if (ShowLogs) Console.WriteLine("Очередь пуста!");
            return default;
        }
        
        T value = Head!.Data;
        if (ShowLogs) Console.WriteLine($"Peeked {value.ToString()}");
        return value;
    }

    public void Print()
    {
        if (IsEmpty())
        {
            if (ShowLogs) Console.WriteLine("Очередь пуста!");
            return;
        }

        if (ShowLogs) Console.Write("Содержимое очереди: ");
        Node<T>? current = Head;
        while (current != null)
        {
            if (ShowLogs) Console.Write($"{current.Data} ");
            current = current.Next;
        }
        if (ShowLogs) Console.WriteLine();
    }
}
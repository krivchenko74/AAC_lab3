using System;

namespace Lab3.LinkedListTask
{
    public class Node<T>
    {
        public T Data;
        public Node<T>? Next;

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
    
    public class CustomLinkedList<T> where T : IComparable<T>
    {
        public Node<T>? Head { get; private set; }
        public Node<T>? Tail { get; private set; }
        public int Count { get; private set; }

        public CustomLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        
        public void AddLast(T data)
        {
            var node = new Node<T>(data);
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail!.Next = node;
                Tail = node;
            }
            Count++;
        }
        
        public void AddFirst(T data)
        {
            var node = new Node<T>(data);
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }
            Count++;
        }
        
        public T? RemoveFirst()
        {
            if (Head == null)
                return default;

            var value = Head.Data;
            Head = Head.Next;
            if (Head == null)
                Tail = null;
            Count--;
            return value;
        }
        
        public T? RemoveLast()
        {
            if (Head == null)
                return default;

            if (Head.Next == null)
            {
                var val = Head.Data;
                Head = null;
                Tail = null;
                Count = 0;
                return val;
            }

            var current = Head;
            while (current.Next != null && current.Next.Next != null)
            {
                current = current.Next;
            }

            var value = current.Next!.Data;
            current.Next = null;
            Tail = current;
            Count--;
            return value;
        }
        
        public bool IsEmpty()
        {
            return Head == null;
        }
        
        public bool Contains(T value)
        {
            var current = Head;
            while (current != null)
            {
                if (Equals(current.Data, value))
                    return true;
                current = current.Next;
            }
            return false;
        }
        
        public bool Remove(T value)
        {
            if (Head == null)
                return false;

            if (Equals(Head.Data, value))
            {
                RemoveFirst();
                return true;
            }

            var current = Head;
            while (current.Next != null)
            {
                if (Equals(current.Next.Data, value))
                {
                    current.Next = current.Next.Next;
                    if (current.Next == null)
                        Tail = current;
                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        
        public bool InsertAfter(T target, T newValue)
        {
            var current = Head;
            while (current != null)
            {
                if (Equals(current.Data, target))
                {
                    var node = new Node<T>(newValue);
                    node.Next = current.Next;
                    current.Next = node;
                    if (current == Tail)
                        Tail = node;
                    Count++;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        
        public bool InsertBefore(T target, T newValue)
        {
            if (Head == null)
                return false;

            if (Equals(Head.Data, target))
            {
                AddFirst(newValue);
                return true;
            }

            var current = Head;
            while (current.Next != null)
            {
                if (Equals(current.Next.Data, target))
                {
                    var node = new Node<T>(newValue);
                    node.Next = current.Next;
                    current.Next = node;
                    Count++;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public void Print()
        {
            if (Head == null)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            var current = Head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
        
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        
        //task 4.1
        public void Reverse()
        {
            if (Head == null || Head.Next == null)
                return; 

            Node<T>? prev = null;
            Node<T>? current = Head;
            Node<T>? next = null;

            Tail = Head; 

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;  
                prev = current;       
                current = next;        
            }

            Head = prev;
        }
        //task 4.2
        public void MoveLastToFirst()
        {
            if (Head == null || Head.Next == null)
                return;

            var lastValue = RemoveLast();
            if (lastValue != null)
                AddFirst(lastValue);
        }
        
        public void MoveFirstToLast()
        {
            if (Head == null || Head.Next == null)
                return; 

            var firstValue = RemoveFirst();
            if (firstValue != null)
                AddLast(firstValue);
        }
        //task 4.3
        public int CountDistinct()
        {
            if (Head == null)
                return 0;
            
            if (typeof(T) != typeof(int))
            {
                Console.WriteLine("Ошибка: функция CountDistinct() применима только для списка с целыми числами.");
                return 0;
            }

            var uniqueValues = new HashSet<int>();
            var current = Head;

            while (current != null)
            {
                var value = (int)(object)current.Data;
                uniqueValues.Add(value);
                current = current.Next;
            }

            return uniqueValues.Count;
        }
        //task 4.4
        public void RemoveNonUnique()
        {
            if (Head == null)
                return;
            
            var counts = new Dictionary<T, int>();
            var current = Head;

            while (current != null)
            {
                var value = current.Data;
                if (counts.ContainsKey(value))
                    counts[value]++;
                else
                    counts[value] = 1;

                current = current.Next;
            }
            
            var dummy = new Node<T>(default!); // фиктивный узел перед головой
            dummy.Next = Head;
            var prev = dummy;
            current = Head;

            while (current != null)
            {
                var value = current.Data;
                if (counts[value] > 1)
                {
                    prev.Next = current.Next;
                    Count--;
                }
                else
                {
                    prev = current;
                }

                current = current.Next;
            }
            
            Head = dummy.Next;
            Tail = Head;
            while (Tail != null && Tail.Next != null)
                Tail = Tail.Next;
        }
        
        public void InsertSelfAfter(T x)
        {
            if (Head == null)
                return;
            
            var current = Head;
            while (current != null && !Equals(current.Data, x))
                current = current.Next;

            if (current == null)
                return;
            
            Node<T>? copyHead = null;
            Node<T>? copyTail = null;
            Node<T>? temp = Head;
            while (temp != null)
            {
                var newNode = new Node<T>(temp.Data);
                if (copyHead == null)
                {
                    copyHead = newNode;
                    copyTail = newNode;
                }
                else
                {
                    copyTail!.Next = newNode;
                    copyTail = newNode;
                }
                temp = temp.Next;
            }
            
            copyTail!.Next = current.Next;
            current.Next = copyHead;
        }
        
        // task 4.6
        public void InsertSorted(T value)
        {
            if (Head == null || value.CompareTo(Head.Data) < 0)
            {
                AddFirst(value);
                return;
            }

            var current = Head;
            while (current.Next != null && current.Next.Data.CompareTo(value) < 0)
            {
                current = current.Next;
            }

            var newNode = new Node<T>(value);
            newNode.Next = current.Next;
            current.Next = newNode;

            if (newNode.Next == null)
                Tail = newNode;

            Count++;
        }
        
        //task 4.7
        public bool RemoveAll(T value)
        {
            if (Head == null)
                return false;

            var removed = false;
            var dummy = new Node<T>(default!); // фиктивный узел
            dummy.Next = Head;
            var current = dummy;

            while (current.Next != null)
            {
                if (Equals(current.Next.Data, value))
                {
                    current.Next = current.Next.Next;
                    Count--;
                    removed = true;
                }
                else
                {
                    current = current.Next;
                }
            }

            Head = dummy.Next;
            if (Head == null)
                Tail = null;
            else
            {
                Tail = current;
            }

            return removed;
        }
        
        // task 4.8
        public bool InsertBeforeElement(T target, T newValue)
        {
            if (Head == null)
                return false;
            
            if (Equals(Head.Data, target))
            {
                AddFirst(newValue);
                return true;
            }

            var current = Head;
            
            while (current.Next != null)
            {
                if (Equals(current.Next.Data, target))
                {
                    var newNode = new Node<T>(newValue);
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    Count++;
                    return true;
                }
                current = current.Next;
            }
            
            return false;
        }

        // task 4.9
        public void AppendList(CustomLinkedList<T> other)
        {
            if (other == null || other.Head == null)
                return;

            if (Head == null)
            {
                Head = other.Head;
                Tail = other.Tail;
                Count = other.Count;
            }
            else
            {
                Tail!.Next = other.Head;
                Tail = other.Tail;
                Count += other.Count;
            }
        }
        
        // task 4.10
        public (CustomLinkedList<T> firstPart, CustomLinkedList<T> secondPart) SplitByValue(T value)
        {
            var firstPart = new CustomLinkedList<T>();
            var secondPart = new CustomLinkedList<T>();

            if (Head == null)
                return (firstPart, secondPart);

            var current = Head;
            Node<T>? splitNode = null;
            
            while (current != null)
            {
                firstPart.AddLast(current.Data);
                if (Equals(current.Data, value))
                {
                    splitNode = current.Next;
                    break;
                }
                current = current.Next;
            }
            
            if (splitNode != null)
            {
                while (splitNode != null)
                {
                    secondPart.AddLast(splitNode.Data);
                    splitNode = splitNode.Next;
                }
            }

            return (firstPart, secondPart);
        }
        
        // task 4.11
        public void Duplicate()
        {
            if (Head == null)
                return;

            Node<T>? current = Head;
            Node<T>? copyHead = null;
            Node<T>? copyTail = null;
            
            while (current != null)
            {
                var newNode = new Node<T>(current.Data);
                if (copyHead == null)
                {
                    copyHead = newNode;
                    copyTail = newNode;
                }
                else
                {
                    copyTail!.Next = newNode;
                    copyTail = newNode;
                }
                current = current.Next;
            }

            Tail!.Next = copyHead;
            Tail = copyTail;

            Count *= 2; 
        }
        
        // task 4.12
        public bool SwapElements(T value1, T value2)
        {
            if (Head == null || Equals(value1, value2))
                return false;

            Node<T>? node1 = null;
            Node<T>? node2 = null;
            Node<T>? current = Head;
            
            while (current != null)
            {
                if (Equals(current.Data, value1))
                    node1 = current;
                else if (Equals(current.Data, value2))
                    node2 = current;

                if (node1 != null && node2 != null)
                    break;

                current = current.Next;
            }
            
            if (node1 == null || node2 == null)
                return false;
            (node1.Data, node2.Data) = (node2.Data, node1.Data);

            return true;
        }
    }
}

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

        /// <summary>
        /// Добавить элемент в начало списка.
        /// </summary>
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

            T value = Head.Data;
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
                T val = Head.Data;
                Head = null;
                Tail = null;
                Count = 0;
                return val;
            }

            Node<T> current = Head;
            while (current.Next != null && current.Next.Next != null)
            {
                current = current.Next;
            }

            T value = current.Next!.Data;
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
            Node<T>? current = Head;
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

            Node<T> current = Head;
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
            Node<T>? current = Head;
            while (current != null)
            {
                if (Equals(current.Data, target))
                {
                    Node<T> node = new Node<T>(newValue);
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

            Node<T> current = Head;
            while (current.Next != null)
            {
                if (Equals(current.Next.Data, target))
                {
                    Node<T> node = new Node<T>(newValue);
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

            Node<T>? current = Head;
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

            T? lastValue = RemoveLast();
            if (lastValue != null)
                AddFirst(lastValue);
        }
        
        public void MoveFirstToLast()
        {
            if (Head == null || Head.Next == null)
                return; 

            T? firstValue = RemoveFirst();
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
            Node<T>? current = Head;

            while (current != null)
            {
                int value = (int)(object)current.Data;
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
            Node<T>? current = Head;

            while (current != null)
            {
                var value = current.Data;
                if (counts.ContainsKey(value))
                    counts[value]++;
                else
                    counts[value] = 1;

                current = current.Next;
            }
            
            Node<T>? dummy = new Node<T>(default!); // фиктивный узел перед головой
            dummy.Next = Head;
            Node<T> prev = dummy;
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
            
            Node<T>? current = Head;
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

    }
    
    
}

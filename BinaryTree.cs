using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class BinaryTree
    {
        public class Node
        {
            public char Data;
            public Node? Left;
            public Node? Right;

            public Node(char data)
            {
                Data = data;
            }
        }

        public Node? Root { get; private set; }

        public BinaryTree(Node root)
        {
            Root = root;
        }
        
        public string DFS()
        {
            var sb = new StringBuilder();
            DFSHelper(Root, sb);
            return sb.ToString();
        }

        private void DFSHelper(Node? node, StringBuilder sb)
        {
            if (node == null)
            {
                sb.Append('*');
                return;
            }

            sb.Append(node.Data);
            DFSHelper(node.Left, sb);
            DFSHelper(node.Right, sb);
        }
        
        public string BFS()
        {
            if (Root == null)
                return string.Empty;

            var sb = new StringBuilder();
            var queue = new Queue<Node?>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == null)
                {
                    sb.Append('*');
                    continue;
                }

                sb.Append(node.Data);
                queue.Enqueue(node.Left);
                queue.Enqueue(node.Right);
            }
            
            var result = sb.ToString().TrimEnd('*');
            return result;
        }
    }
}
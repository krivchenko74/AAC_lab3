using System;

namespace Lab3.RealExamples
{
    public class FileSystemTree
    {
        public class FileNode
        {
            public string Name { get; set; }
            public bool IsDirectory { get; set; }
            public List<FileNode> Children { get; set; } = new();

            public FileNode(string name, bool isDirectory)
            {
                Name = name;
                IsDirectory = isDirectory;
            }

            public void AddChild(FileNode node)
            {
                if (!IsDirectory)
                    throw new InvalidOperationException("Нельзя добавлять элементы в файл.");
                Children.Add(node);
            }
        }
        public FileNode Root { get; private set; }

        public FileSystemTree(string rootName)
        {
            Root = new FileNode(rootName, true);
        }
        
        public void Print(FileNode node, string indent = "")
        {
            Console.WriteLine($"{indent}{(node.IsDirectory ? "📁" : "📄")} {node.Name}");

            foreach (var child in node.Children)
            {
                Print(child, indent + "   ");
            }
        }

        public static void Run()
        {
            Console.WriteLine("=== Симуляция файловой системы ===\n");

            // создаём корень
            var tree = new FileSystemTree("Root");

            // добавляем папки
            var docs = new FileNode("Documents", true);
            var pics = new FileNode("Pictures", true);
            var music = new FileNode("Music", true);

            tree.Root.AddChild(docs);
            tree.Root.AddChild(pics);
            tree.Root.AddChild(music);

            // добавляем файлы
            docs.AddChild(new FileNode("resume.docx", false));
            docs.AddChild(new FileNode("project.pdf", false));

            pics.AddChild(new FileNode("cat.png", false));
            pics.AddChild(new FileNode("dog.jpg", false));

            music.AddChild(new FileNode("rock.mp3", false));

            // вывод структуры
            Console.WriteLine("Структура дерева файловой системы:\n");
            tree.Print(tree.Root);
        }
    }
}
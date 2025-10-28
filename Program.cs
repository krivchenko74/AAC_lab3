using Avalonia;
using System;
using Avalonia.Data;
using Lab3.LinkedListTask;
using Lab3.LinkedListTask.Task10;
using Lab3.QueueTask.TextAnalyzerTask;
using Lab3.RealExamples;
using Lab3.StackTask.InfixToPostfix;
using Lab3.StackTask.PostfixTask;
using Lab3.StackTask.StackTextAnalyzerTask;

namespace Lab3;

class Program
{
    // //Точка входа
    // [STAThread]
    // public static void Main(string[] args) 
    //     => BuildAvaloniaApp()
    //         .StartWithClassicDesktopLifetime(args);
    //
    // // Настройка Avalonia
    // public static AppBuilder BuildAvaloniaApp()
    //     => AppBuilder.Configure<App>()
    //         .UsePlatformDetect()
    //         .LogToTrace();
    // public static void Main(string[] args)
    // {
        // var task = new PostfixTask();
        // task.Run();
        // var task = new InfixToPostfixTask();
        // task.Run();
        // var task = new TextAnalyzerTask(true);
        // task.Run("/Users/slava/Documents/Образование/ЧелГУ/Курс 2/ААС/Lab3/StackTask/TextAnalyzerTask/input.txt");
    // }
    // public static void Main(string[] args)
    // {
    //     var task = new CustomTextAnalyzer(true);
    //     task.Run("/Users/slava/Documents/Образование/ЧелГУ/Курс 2/ААС/Lab3/QueueTask/TextAnalyzerTask/input.txt");
    // }
    public static void Main(string[] args)
    {
        var root = new BinaryTree.Node('A');
        var nodeB = new BinaryTree.Node('B');
        var nodeC = new BinaryTree.Node('C');
        var nodeD = new BinaryTree.Node('D');
        var nodeG = new BinaryTree.Node('G');
        var nodeE = new BinaryTree.Node('E');
        var nodeF = new BinaryTree.Node('F');
        var nodeH = new BinaryTree.Node('H');
        var nodeJ = new BinaryTree.Node('J');
        root.Left = nodeB;
        root.Right = nodeC;
        nodeB.Left = nodeD;
        nodeD.Right = nodeG;
        nodeC.Left = nodeE;
        nodeC.Right = nodeF;
        nodeF.Left = nodeH;
        nodeF.Right = nodeJ;
        
        var tree = new BinaryTree(root);
        Console.WriteLine("DFS: " + tree.DFS());
        Console.WriteLine("BFS:" + tree.BFS());
    }
    // public static void Main(string[] args)
    // {
    //     var list = new CustomLinkedList<int>();
    //     list.AddLast(1);
    //     list.AddLast(2);
    //     list.AddLast(3);
    //     list.AddLast(4);
    //     list.InsertSorted(2);
    //     list.InsertSorted(3);
    //     list.InsertSorted(5);
    //     list.RemoveAll(2);
    //     list.InsertBefore(4, 10);
    //     list.Print();
    //     list.AddLast(9);
    //     list.Print();
    //     var list2 = Task9.Run();
    //     list2.AddLast(10);
    //     list2.AddFirst(10);
    //     list2.InsertBefore(6, 228);
    //     list2.Print();
    //     var (part1, part2) = list2.SplitByValue(228);
    //     part1.AddFirst(777);
    //     part1.AddLast(777);
    //     part2.AddFirst(777);
    //     part2.AddLast(777);
    //     part1.Duplicate();
    //     part2.SwapElements(6, 10);
    //     part1.Print();
    //     part2.Print();
    // }
    // public static void Main(string[] args)
    // {
    //     ToDoList.Run();
    //     CalculatorUndo.Run();
    //     TechnicalSupport.Run();
    //     FileSystemTree.Run();
    // }
}


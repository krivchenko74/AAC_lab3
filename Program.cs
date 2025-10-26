using Avalonia;
using System;
using Lab3.LinkedListTask;
using Lab3.LinkedListTask.Task10;
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
    //     // var infixToPostfixTask = new InfixToPostfix();
    //     // infixToPostfixTask.Run();
    //     // var postFixTask = new PostfixTask();
    //     // Console.WriteLine(postFixTask.Run());
    // }
    public static void Main(string[] args)
    {
        var list = new CustomLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.AddLast(4);
        list.InsertSorted(2);
        list.InsertSorted(3);
        list.InsertSorted(5);
        list.RemoveAll(2);
        list.InsertBefore(4, 10);
        list.Print();
        list.AddLast(9);
        list.Print();
        var list2 = Task9.Run();
        list2.AddLast(10);
        list2.AddFirst(10);
        list2.InsertBefore(6, 228);
        list2.Print();
        var (part1, part2) = list2.SplitByValue(228);
        part1.AddFirst(777);
        part1.AddLast(777);
        part2.AddFirst(777);
        part2.AddLast(777);
        part1.Duplicate();
        part2.SwapElements(6, 10);
        part1.Print();
        part2.Print();
    }
    
}


using Avalonia;
using System;
using Lab3.LinkedListTask;
using Lab3.StackTask.InfixToPostfix;
using Lab3.StackTask.PostfixTask;

namespace Lab3;

class Program
{
    // Точка входа
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
    //     var task = new InfixToPostfix();
    //     var postfixTask = new PostfixTask();
    //     Console.WriteLine(postfixTask.Run());
    //     task.Run();
    // }
    public static void Main(string[] args)
    {
        var list = new CustomLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.AddLast(4);

        // Console.WriteLine("Исходный список:");
        // list.Print();
        //
        // list.Reverse();
        //
        // Console.WriteLine("После переворота:");
        // list.Print();
        list.InsertSelfAfter(2);
        list.Print();
        list.AddLast(9);
        list.Print();
    }
    
}


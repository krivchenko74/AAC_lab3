using Avalonia;
using System;
using Lab3.LinkedListTask;
using Lab3.StackTask.InfixToPostfix;
using Lab3.StackTask.PostfixTask;
using Lab3.StackTask.StackTextAnalyzerTask;

namespace Lab3;

class Program
{
    //Точка входа
    [STAThread]
    public static void Main(string[] args) 
        => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    
    // Настройка Avalonia
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();
    // public static void Main(string[] args)
    // {
    //     // var infixToPostfixTask = new InfixToPostfix();
    //     // infixToPostfixTask.Run();
    //     // var postFixTask = new PostfixTask();
    //     // Console.WriteLine(postFixTask.Run());
    // }
    // public static void Main(string[] args)
    // {
    //     // var list = new CustomLinkedList<int>();
    //     // list.AddLast(1);
    //     // list.AddLast(2);
    //     // list.AddLast(3);
    //     // list.AddLast(4);
    //     // list.InsertSelfAfter(2);
    //     // list.Print();
    //     // list.AddLast(9);
    //     // list.Print();
    //     var task = new TextAnalyzer(true);
    //     task.Run(
    //         "/Users/slava/Documents/Образование/ЧелГУ/Курс 2/ААС/Lab3/StackTask/TextAnalyzerTask/input.txt");
    // }
    
}


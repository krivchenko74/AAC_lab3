using Lab3.Utils;

namespace Lab3.StackTask.StackTextAnalyzerTask;

public class TextAnalyzerTask: ITask
{
    private Stack<string> Stack;

    public TextAnalyzerTask()
    {
        Stack = new Stack<string>(false);
    }
    
    public TextAnalyzerTask(bool showLogs)
    {
        Stack = new Stack<string>(showLogs);
    }
    
    public void Run(List<string> commands)
    {
        foreach (var cmd in commands)
        {
            if (cmd.StartsWith("1,"))
            {
                var value = cmd.Substring(2);
                Stack.Push(value);
            }
            else
            {
                switch (cmd)
                {
                    case "2":
                        Stack.Pop();
                        break;
                    case "3":
                        Stack.Top();
                        break;
                    case "4":
                        Stack.IsEmpty();
                        break;
                    case "5":
                        Stack.Print();
                        break;
                }
            }
        }
    }
    
    public void Run(string filePath)
    {
        var commands = File.ReadAllText(filePath).Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var cmd in commands)
        {
            if (cmd.StartsWith("1,"))
            {
                var value = cmd.Substring(2);
                Stack.Push(value);
            }
            else
            {
                switch (cmd)
                {
                    case "2":
                        Stack.Pop();
                        break;
                    case "3":
                        Stack.Top();
                        break;
                    case "4":
                        Stack.IsEmpty();
                        break;
                    case "5":
                        Stack.Print();
                        break;
                }
            }
        }
    }
}
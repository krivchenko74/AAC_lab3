using Lab3.Utils;

namespace Lab3.StackTask;

public class TextAnalyzer: ITask
{
    private Stack<string> Stack = new (false);
    
    public void Run(List<string> commands)
    {

        // string[] commands = cmdString.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var cmd in commands)
        {
            if (cmd.StartsWith("1,"))
            {
                string value = cmd.Substring(2);
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
using Lab3.Utils;

namespace Lab3.QueueTask.TextAnalyzerTask;

public class CustomTextAnalyzer: ITask
{
    private LinkedQueue<string> Queue = new();
    public void Run(List<string> commands)
    {
        foreach (var cmd in commands)
        {
            if (cmd.StartsWith("1,"))
            {
                var value = cmd.Substring(2);
                Queue.Enqueue(value);
            }
            else
            {
                switch (cmd)
                {
                    case "2":
                        Queue.Dequeue();
                        break;
                    case "3":
                        Queue.Peek();
                        break;
                    case "4":
                        Queue.IsEmpty();
                        break;
                    case "5":
                        Queue.Print();
                        break;
                }
            }
        }
    }
}
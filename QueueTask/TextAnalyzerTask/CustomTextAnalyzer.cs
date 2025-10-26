using Lab3.Utils;

namespace Lab3.QueueTask.TextAnalyzerTask;

public class CustomTextAnalyzer: ITask
{
    private LinkedQueue<string> queue = new();
    public void Run(List<string> commands)
    {
        foreach (var cmd in commands)
        {
            if (cmd.StartsWith("1,"))
            {
                string value = cmd.Substring(2);
                queue.Enqueue(value);
            }
            else
            {
                switch (cmd)
                {
                    case "2":
                        queue.Dequeue();
                        break;
                    case "3":
                        queue.Peek();
                        break;
                    case "4":
                        queue.IsEmpty();
                        break;
                    case "5":
                        queue.Print();
                        break;
                }
            }
        }
    }
}
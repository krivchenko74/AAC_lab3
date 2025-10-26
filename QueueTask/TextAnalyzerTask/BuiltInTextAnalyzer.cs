using Lab3.Utils;

namespace Lab3.QueueTask.TextAnalyzerTask;

public class BuiltInTextAnalyzer: ITask
{
    private Queue<string> queue = new ();
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
                        if (queue.Count > 0) queue.Dequeue();
                        break;
                    case "3":
                        if (queue.Count > 0) queue.Peek();
                        break;
                    case "4":
                        var _ = queue.Count == 0;
                        break;
                    case "5":
                        foreach (var item in queue)
                        {
                            var tmp = item;
                        };
                        break;
                }
            }
        }
    }
}
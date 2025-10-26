using Lab3.Utils;

namespace Lab3.QueueTask.TextAnalyzerTask;

public class BuiltInTextAnalyzer: ITask
{
    private Queue<string> Queue = new ();
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
                        if (Queue.Count > 0) Queue.Dequeue();
                        break;
                    case "3":
                        if (Queue.Count > 0) Queue.Peek();
                        break;
                    case "4":
                        var _ = Queue.Count == 0;
                        break;
                    case "5":
                        foreach (var item in Queue)
                        {
                            var tmp = item;
                        };
                        break;
                }
            }
        }
    }
}
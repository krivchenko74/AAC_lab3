using System.Diagnostics;
using Lab3.StackTask;

namespace Lab3.Utils;

public class Benchmark
{
    public static double Measure(ITask task, List<string> commands, int iterations = 5)
    {
        double total = 0.0;
        
        for (int r = 0; r < iterations; r++)
        {
            var sw = Stopwatch.StartNew();
            task.Run(commands);
            sw.Stop();
            total += sw.Elapsed.TotalMilliseconds;
        }

        return total / iterations;
    }
    
    public static double[] RunRange(int maxN, Func<ITask> generateTask, CommandMode mode)
    {
        var result = new double[maxN];
        var commands = InputGenerator.GenerateCommands(maxN, mode);

        for (int i = 0; i < 10; i++)
        {
            var task = generateTask();
            task.Run(commands.Slice(1, 50));
        } 
        
        GC.Collect();
        GC.WaitForPendingFinalizers(); 
        
        for (int n = 1; n <= maxN; n++)
        {
            var commandsForCurrent = commands.Slice(0, n);
            var task = generateTask();
            result[n-1] = Measure(task, commandsForCurrent);
        }
        
        return result;
    }
    
    public static double[] RunNumber(int maxN, Func<ITask> generateTask, CommandMode mode)
    {
        var result = new double[maxN];
        var commands = InputGenerator.GenerateCommands(maxN * 10, mode);

        for (int i = 0; i < 10; i++)
        {
            var task = generateTask();
            task.Run(commands.Slice(1, 50));
        } 
        
        GC.Collect();
        GC.WaitForPendingFinalizers(); 
        
        for (int n = 1; n <= maxN; n++)
        {
            var task = generateTask();
            result[n-1] = Measure(task, commands);
        }
        
        return result;
    }
    
    public static double[] RunRange(int maxN, Func<ITask> generateTask)
    {
        var result = new double[maxN];
        var commands = InputGenerator.GenerateCommands(maxN);

        for (int i = 0; i < 10; i++)
        {
            var task = generateTask();
            task.Run(commands.Slice(1, 50));
        } 
        
        GC.Collect();
        GC.WaitForPendingFinalizers(); 
        
        for (int n = 1; n <= maxN; n++)
        {
            var commandsForCurrent = commands.Slice(0, n);
            var task = generateTask();
            result[n-1] = Measure(task, commandsForCurrent);
        }
        
        return result;
    }
}
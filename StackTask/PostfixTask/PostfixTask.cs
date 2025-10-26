namespace Lab3.StackTask.PostfixTask;

public class PostfixTask
{
    public double Run()
    {
        var stack = new Stack<double>(true);
        var commands = File.ReadAllText("/Users/slava/Documents/Образование/ЧелГУ/Курс 2/ААС/Lab3/StackTask/PostfixTask/input.txt").Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var cmd in commands)
        {
            if (double.TryParse(cmd, out var value))
            {
                stack.Push(value);
            }
            else
            {
                switch (cmd)
                {
                    case "+":
                    {
                        var b = stack.Pop();
                        var a = stack.Pop();
                        stack.Push(a + b);
                        break;
                    }
                    case "-":
                    {
                        var b = stack.Pop();
                        var a = stack.Pop();
                        stack.Push(a - b);
                        break;
                    }
                    case "*":
                    {
                        var b = stack.Pop();
                        var a = stack.Pop();
                        stack.Push(a * b);
                        break;
                    }
                    case ":":
                    case "/":
                    {
                        var b = stack.Pop();
                        var a = stack.Pop();
                        stack.Push(a / b);
                        break;
                    }
                    case "^":
                    {
                        var b = stack.Pop();
                        var a = stack.Pop();
                        stack.Push(Math.Pow(a, b));
                        break;
                    }
                    case "ln":
                        stack.Push(Math.Log(stack.Pop()));
                        break;
                    case "sin":
                        stack.Push(Math.Sin(stack.Pop()));
                        break;
                    case "cos":
                        stack.Push(Math.Cos(stack.Pop()));
                        break;
                    case "sqrt":
                        stack.Push(Math.Sqrt(stack.Pop()));
                        break;
                    default:
                        Console.WriteLine($"Unknown Command: {cmd}");
                        break;
                }
            }
        }
        return stack.Pop();
    }
}
namespace Lab3.StackTask.PostfixTask;

public class PostfixTask
{
    public double Run()
    {
        var stack = new Stack<double>();
        var commands = File.ReadAllText("/Users/slava/Documents/Образование/ЧелГУ/Курс 2/ААС/Lab3/StackTask/PostfixTask/input.txt").Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var cmd in commands)
        {
            if (double.TryParse(cmd, out double value))
            {
                stack.Push(value);
            }
            else
            {
                switch (cmd)
                {
                    case "+":
                    {
                        double b = stack.Pop();
                        double a = stack.Pop();
                        stack.Push(a + b);
                        break;
                    }
                    case "-":
                    {
                        double b = stack.Pop();
                        double a = stack.Pop();
                        stack.Push(a - b);
                        break;
                    }
                    case "*":
                    {
                        double b = stack.Pop();
                        double a = stack.Pop();
                        stack.Push(a * b);
                        break;
                    }
                    case ":":
                    case "/":
                    {
                        double b = stack.Pop();
                        double a = stack.Pop();
                        stack.Push(a / b);
                        break;
                    }
                    case "^":
                    {
                        double b = stack.Pop();
                        double a = stack.Pop();
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
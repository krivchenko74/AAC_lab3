using System;

namespace Lab3.RealExamples
{
    public static class CalculatorUndo
    {
        private static StackTask.Stack<int> stack = new();
        private static int current = 0;

        private static void Add(int x)
        {
            stack.Push(current);
            current += x;
        }

        private static void Subtract(int x)
        {
            stack.Push(current);
            current -= x;
        }

        private static void Undo()
        {
            if (!stack.IsEmpty())
            {
                current = stack.Pop();
                Console.WriteLine("Отмена выполнена!");
            }
            else
            {
                Console.WriteLine("Нечего отменять!");
            }
        }

        public static void Run()
        {
            Console.WriteLine("=== Калькулятор с функцией Undo ===");
            Console.WriteLine("Команды: +N, -N, undo, exit\n");

            while (true)
            {
                Console.Write($"Текущее значение: {current} > ");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                if (input.Equals("undo", StringComparison.OrdinalIgnoreCase))
                {
                    Undo();
                }
                else if (input.StartsWith("+"))
                {
                    if (int.TryParse(input.Substring(1), out int num))
                        Add(num);
                    else
                        Console.WriteLine("Ошибка: введите число после +");
                }
                else if (input.StartsWith("-"))
                {
                    if (int.TryParse(input.Substring(1), out int num))
                        Subtract(num);
                    else
                        Console.WriteLine("Ошибка: введите число после -");
                }
                else
                {
                    Console.WriteLine("Неизвестная команда.");
                }
            }

            Console.WriteLine("\nРабота завершена. Итоговое значение: " + current);
        }
    }
}

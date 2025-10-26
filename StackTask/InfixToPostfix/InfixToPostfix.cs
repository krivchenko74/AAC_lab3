using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab3.StackTask.InfixToPostfix
{
    public class InfixToPostfix
    {
        private static readonly Dictionary<string, int> Precedence = new()
        {
            { "ln", 4 }, { "sin", 4 }, { "cos", 4 }, { "sqrt", 4 },
            { "^", 3 },
            { "*", 2 }, { ":", 2 }, { "/", 2 },
            { "+", 1 }, { "-", 1 }
        };

        private static bool IsOperator(string token) => Precedence.ContainsKey(token);
        private static bool IsFunction(string token) => token is "ln" or "sin" or "cos" or "sqrt";

        public void Run()
        {
            string filePath = "/Users/slava/Documents/Образование/ЧелГУ/Курс 2/ААС/Lab3/StackTask/InfixToPostfix/input.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл {filePath} не найден!");
                return;
            }

            string infix = File.ReadAllText(filePath).Trim();
            Console.WriteLine($"Инфиксное выражение: {infix}");

            string postfix = ConvertToPostfix(infix);
            Console.WriteLine($"Постфиксное выражение: {postfix}");
        }

        public static string ConvertToPostfix(string infix)
        {
            string[] tokens = infix.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>();
            StringBuilder output = new StringBuilder();

            foreach (string token in tokens)
            {
                // Если число — сразу в выход
                if (double.TryParse(token, out _))
                {
                    output.Append(token + " ");
                }
                // Если функция (sin, cos, ln)
                else if (IsFunction(token))
                {
                    stack.Push(token);
                }
                // Если оператор (+, -, *, /, ^)
                else if (IsOperator(token))
                {
                    while (stack.Count > 0 && IsOperator(stack.Peek()) &&
                           Precedence[stack.Peek()] >= Precedence[token])
                    {
                        output.Append(stack.Pop() + " ");
                    }
                    stack.Push(token);
                }
                // Открывающая скобка
                else if (token == "(")
                {
                    stack.Push(token);
                }
                // Закрывающая скобка
                else if (token == ")")
                {
                    while (stack.Count > 0 && stack.Peek() != "(")
                        output.Append(stack.Pop() + " ");

                    if (stack.Count > 0 && stack.Peek() == "(")
                        stack.Pop(); // удалить "("

                    if (stack.Count > 0 && IsFunction(stack.Peek()))
                        output.Append(stack.Pop() + " ");
                }
                else
                {
                    Console.WriteLine($"Неизвестный токен: {token}");
                }
            }

            // Выталкиваем остаток стека
            while (stack.Count > 0)
            {
                output.Append(stack.Pop() + " ");
            }

            return output.ToString().Trim();
        }
    }
}

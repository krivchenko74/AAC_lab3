using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab3.StackTask.InfixToPostfix
{
    public class InfixToPostfixTask
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
            var filePath = "/Users/slava/Documents/Образование/ЧелГУ/Курс 2/ААС/Lab3/StackTask/InfixToPostfix/input.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл {filePath} не найден!");
                return;
            }

            var infix = File.ReadAllText(filePath).Trim();
            Console.WriteLine($"Инфиксное выражение: {infix}");

            var postfix = ConvertToPostfix(infix);
            Console.WriteLine($"Постфиксное выражение: {postfix}");
        }

        private static string ConvertToPostfix(string infix)
        {
            var tokens = infix.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<string>();
            var output = new StringBuilder();

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out _))
                {
                    output.Append(token + " ");
                }
                else if (IsFunction(token))
                {
                    stack.Push(token);
                }
                else if (IsOperator(token))
                {
                    while (stack.Count > 0 && IsOperator(stack.Peek()) &&
                           Precedence[stack.Peek()] >= Precedence[token])
                    {
                        output.Append(stack.Pop() + " ");
                    }
                    stack.Push(token);
                }
                else if (token == "(")
                {
                    stack.Push(token);
                }
                else if (token == ")")
                {
                    while (stack.Count > 0 && stack.Peek() != "(")
                        output.Append(stack.Pop() + " ");

                    if (stack.Count > 0 && stack.Peek() == "(")
                        stack.Pop();

                    if (stack.Count > 0 && IsFunction(stack.Peek()))
                        output.Append(stack.Pop() + " ");
                }
                else
                {
                    Console.WriteLine($"Неизвестный токен: {token}");
                }
            }
            
            while (stack.Count > 0)
            {
                output.Append(stack.Pop() + " ");
            }

            return output.ToString().Trim();
        }
    }
}

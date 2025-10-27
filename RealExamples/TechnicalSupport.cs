using System;
using System.Threading;
using Lab3.QueueTask;

namespace Lab3.RealExamples
{
    public static class TechnicalSupport
    {
        private static LinkedQueue<string> supportQueue = new();

        public static void Run()
        {
            Console.WriteLine("=== Система поддержки клиентов ===");
            Console.WriteLine("Введите описание проблемы (или 'start' для начала обработки, 'exit' для выхода):");

            var ticketNumber = 1;
            
            while (true)
            {
                Console.Write($"Заявка {ticketNumber}: ");
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    return;

                if (input.Equals("start", StringComparison.OrdinalIgnoreCase))
                    break;

                var ticket = $"#{ticketNumber} ({DateTime.Now:T}) — {input}";
                supportQueue.Enqueue(ticket);
                ticketNumber++;
                Console.WriteLine("✅ Заявка добавлена в очередь.\n");
            }

            Console.WriteLine("\nНачинаем обработку заявок...\n");
            
            var processed = 0;
            var rand = new Random();

            while (!supportQueue.IsEmpty())
            {
                var issue = supportQueue.Dequeue();
                Console.WriteLine($"🔧 Обрабатывается: {issue}");
                Thread.Sleep(rand.Next(1000, 2500)); // имитация работы оператора
                Console.WriteLine($"✅ Заявка обработана: {issue}\n");
                processed++;
            }

            Console.WriteLine($"Все заявки обработаны! Всего: {processed}");
        }
    }
}
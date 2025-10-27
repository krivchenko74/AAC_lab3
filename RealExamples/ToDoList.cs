using System;
using Lab3.LinkedListTask;

namespace Lab3.RealExamples
{
    public static class ToDoList
    {
        public static void Run()
        {
            var taskList = new CustomLinkedList<string>();
            var running = true;

            Console.Clear();
            Console.WriteLine("📝 === Список дел ===\n");

            while (running)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1 — Добавить задачу");
                Console.WriteLine("2 — Удалить задачу");
                Console.WriteLine("3 — Показать все задачи");
                Console.WriteLine("4 — Очистить список");
                Console.WriteLine("0 — Выйти\n");

                Console.Write("Ваш выбор: ");
                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите задачу: ");
                        string? newTask = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newTask))
                        {
                            taskList.AddLast(newTask);
                            Console.WriteLine("✅ Задача добавлена!");
                        }
                        else
                        {
                            Console.WriteLine("⚠️ Пустая строка не может быть задачей.");
                        }
                        break;

                    case "2":
                        if (taskList.IsEmpty())
                        {
                            Console.WriteLine("⚠️ Список пуст!");
                            break;
                        }
                        Console.Write("Введите задачу для удаления: ");
                        string? delTask = Console.ReadLine();
                        if (taskList.Remove(delTask!))
                            Console.WriteLine("🗑️ Задача удалена.");
                        else
                            Console.WriteLine("❌ Задача не найдена.");
                        break;

                    case "3":
                        Console.WriteLine("📋 Ваш список задач:");
                        PrintTasks(taskList);
                        break;

                    case "4":
                        taskList.Clear();
                        Console.WriteLine("🧹 Список очищен.");
                        break;

                    case "0":
                        running = false;
                        Console.WriteLine("👋 До свидания!");
                        break;

                    default:
                        Console.WriteLine("❌ Неверный ввод. Попробуйте снова.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void PrintTasks(CustomLinkedList<string> list)
        {
            if (list.IsEmpty())
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            var i = 1;
            var current = list.Head;
            while (current != null)
            {
                Console.WriteLine($"{i}. {current.Data}");
                current = current.Next;
                i++;
            }
        }
    }
}

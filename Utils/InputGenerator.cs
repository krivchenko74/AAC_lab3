using System;
using System.Collections.Generic;

namespace Lab3.StackTask
{
    /// <summary>
    /// Режим генерации команд.
    /// </summary>
    public enum CommandMode
    {
        Balanced,          
        HeavyEnqueue,    
        HeavyDequeue,    
        HeavyPeek,    
        HeavyIsEmpty,    
        HeavyPrint    
    }

    public static class InputGenerator
    {
        private static readonly Random random = new();
        private static readonly string[] words = 
            { "cat", "dog", "bird", "fish", "tree", "house", "car" };
        
        public static List<string> GenerateCommands(int operationCount, CommandMode mode = CommandMode.Balanced)
        {
            var commands = new List<string>();

            for (var i = 0; i < operationCount; i++)
            {
                var operation = GetOperationType(mode);

                if (operation == 1)
                {
                    string value;
                    if (random.Next(0, 2) == 0)
                    {
                        value = random.Next(1, 100).ToString();
                    }
                    else
                    {
                        var index = random.Next(0, words.Length);
                        value = words[index];
                    }

                    commands.Add("1," + value);
                }
                else
                {
                    commands.Add(operation.ToString());
                }
            }

            return commands;
        }
        
        private static int GetOperationType(CommandMode mode)
        {
            if (mode == CommandMode.Balanced)
            {
                return random.Next(1, 6);
            }
            
            int dominantOperation = (int)mode; 
            if (dominantOperation < 1 || dominantOperation > 5)
                dominantOperation = 1;
            
            int[] values = { 1, 2, 3, 4, 5 };
            var weights = new double[5];

            for (var i = 0; i < 5; i++)
            {
                if (i + 1 == dominantOperation)
                    weights[i] = 0.6; 
                else
                    weights[i] = 0.1; 
            }

            return WeightedChoice(values, weights);
        }

        private static int WeightedChoice(int[] values, double[] weights)
        {
            double total = 0;
            for (var i = 0; i < weights.Length; i++)
                total += weights[i];

            var r = random.NextDouble() * total;
            double cumulative = 0;

            for (var i = 0; i < values.Length; i++)
            {
                cumulative += weights[i];
                if (r < cumulative)
                    return values[i];
            }

            return values[values.Length - 1];
        }
    }
}

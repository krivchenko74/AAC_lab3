using System.Collections.Generic;
using Avalonia.Controls;
using Lab3;
using Lab3.StackTask;
using Lab3.Utils;

namespace Lab3;

public partial class MainWindow : Window
    {
        private static List<TabItemModel> Tabs = new();

        public MainWindow()
        {
            DataContext = Tabs;
            // var tabForStackTextAnalyzer = TabGenerator.GenerateTabForStackTextAnalyzer(20_000);
            // Tabs.Add(tabForStackTextAnalyzer);
            // var tab2ForQueueTextAnalyzer = TabGenerator.GenerateTabForQueueTextAnalyzer(49000, 50000, CommandMode.Balanced);
            // Tabs.Add(tab2ForQueueTextAnalyzer);
            var tab3ForQueueTextAnalyzer = TabGenerator.GenerateTabForQueueTextAnalyzer(0,5000, CommandMode.HeavyIsEmpty, "Attempt number");
            Tabs.Add(tab3ForQueueTextAnalyzer);
            InitializeComponent();
        }

        
    }
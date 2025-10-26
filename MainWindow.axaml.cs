using System.Collections.Generic;
using Avalonia.Controls;
using Lab3;
using Lab3.StackTask;
using Lab3.Utils;

namespace Lab3;

public partial class MainWindow : Window
    {
        public static List<TabItemModel> Tabs = new();

        public MainWindow()
        {
            DataContext = Tabs;
            var tabForStackTextAnalyzer = TabGenerator.GenerateTabForStackTextAnalyzer(3_000);
            Tabs.Add(tabForStackTextAnalyzer);
            // var tab2ForQueueTextAnalyzer = TabGenerator.GenerateTabForQueueTextAnalyzer(1000, CommandMode.Balanced);
            // Tabs.Add(tab2ForQueueTextAnalyzer);
            // var tab3ForQueueTextAnalyzer = TabGenerator.GenerateTabForQueueTextAnalyzer(10000, CommandMode.HeavyEnqueue);
            // Tabs.Add(tab3ForQueueTextAnalyzer);
            InitializeComponent();
        }

        
    }
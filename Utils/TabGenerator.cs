using System;
using System.Linq;
using Lab3.QueueTask;
using Lab3.QueueTask.TextAnalyzerTask;
using Lab3.StackTask;
using Lab3.Utils;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
namespace Lab3.Utils;

public class TabGenerator
{
    private static PlotModel CreatePlot(string title, int[] x, double[] y, string axis = "Time, ms")
    {
        var model = new PlotModel { Title = title };
        Legend legend = new Legend();
        legend.LegendOrientation = LegendOrientation.Horizontal;
        legend.LegendPlacement = LegendPlacement.Inside;
        legend.LegendPosition = LegendPosition.TopLeft;
        model.Legends.Add(legend);
        model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = axis, AxislineColor = OxyColors.Red});
        model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Size" });
        var series1 = new LineSeries
        {
            Title = "Экспериментальные результаты",
            Color = OxyColors.Blue
        };
        for (int i = 0; i < x.Length; i++)
            series1.Points.Add(new DataPoint(x[i], y[i]));
        model.Series.Add(series1);
        return model;
    }
    
    private static PlotModel CreatePlot(string title, int[] x, double[] y, double[] y2, string axis = "Time, ms")
    {
        var model = new PlotModel { Title = title };
        Legend legend = new Legend();
        legend.LegendOrientation = LegendOrientation.Horizontal;
        legend.LegendPlacement = LegendPlacement.Inside;
        legend.LegendPosition = LegendPosition.TopLeft;
        model.Legends.Add(legend);
        model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = axis, AxislineColor = OxyColors.Red});
        model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Size" });
        var series1 = new LineSeries
        {
            Title = "Результаты для встроенной",
            Color = OxyColors.Blue
        };
        var series2 = new LineSeries
        {
            Title = "Результаты для кастомной",
            Color = OxyColors.Red
        };
        for (int i = 0; i < x.Length; i++)
        {
            series1.Points.Add(new DataPoint(x[i], y[i]));
            series2.Points.Add(new DataPoint(x[i], y2[i])); 
        }
        model.Series.Add(series1);
        model.Series.Add(series2);
        return model;
    }

    public static TabItemModel GenerateTabForStackTextAnalyzer(int maxN)
    {
        var x = new int[maxN];

        for (int i = 0; i < maxN; i++)
        {
            x[i] = i + 1;
        }
        
        var y = Benchmark.RunRange(maxN, () => new TextAnalyzer());
        return new TabItemModel("StackTextAnalyzer", CreatePlot("StackTextAnalyzer", x, y));
    }
    
    public static TabItemModel GenerateTabForQueueTextAnalyzer(int maxN, CommandMode mode)
    {
        if (mode != CommandMode.Balanced) maxN /= 10;
        var x = new int[maxN];

        for (var i = 0; i < maxN; i++)
        {
            x[i] = i + 1;
        }
        
        double[] y;
        double[] y2;
        
        if (mode == CommandMode.Balanced)
        {
            y = Benchmark.RunRange(maxN, () => new CustomTextAnalyzer(), mode);
            y2 = Benchmark.RunRange(maxN, () => new BuiltInTextAnalyzer(), mode);
        }
        else
        {
            y = Benchmark.RunNumber(maxN, () => new CustomTextAnalyzer(), mode);
            y2 = Benchmark.RunNumber(maxN, () => new BuiltInTextAnalyzer(), mode);
        }
        
        var title = "QueueTextAnalyzer (" + mode + ")";
        return new TabItemModel(title, CreatePlot(title, x, y, y2));
    }
}
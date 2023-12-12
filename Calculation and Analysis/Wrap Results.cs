using Spectre.Console;
public abstract class WrapResults
{
    public double Sum { get; set; }
    public double Size { get; set; }
    public double Mean { get; set; }
    public double Median { get; set; }
    public double Mode { get; set; }
    public double Range { get; set; }
    public double InterquartileRange { get; set; }
    public double Variance { get; set; }
    public double StandardDeviation { get; set; }
    public double Minimum { get; set; }
    public double Maximum { get; set; }
    public double Quartile1 { get; set; }
    public double Quartile2 { get; set; }
    public double Quartile3 { get; set; }
    public double Percentile25 { get; set; }
    public double Percentile50 { get; set; }
    public double Percentile75 { get; set; }
    public double Skewness { get; set; }
    public double Kurtosis { get; set; }
    public double CoefficientOfVariation { get; set; }

    public WrapResults(double sum, double size, double mean, double median, double mode, double range, double interquartileRange,
                       double variance, double standardDeviation, double minimum, double maximum, double quartile1, double quartile2,
                       double quartile3, double percentile25, double percentile50, double percentile75, double skewness, double kurtosis,
                       double coefficientOfVariation)
    {
        Sum = sum;
        Size = size;
        Mean = mean;
        Median = median;
        Mode = mode;
        Range = range;
        InterquartileRange = interquartileRange;
        Variance = variance;
        StandardDeviation = standardDeviation;
        Minimum = minimum;
        Maximum = maximum;
        Quartile1 = quartile1;
        Quartile2 = quartile2;
        Quartile3 = quartile3;
        Percentile25 = percentile25;
        Percentile50 = percentile50;
        Percentile75 = percentile75;
        Skewness = skewness;
        Kurtosis = kurtosis;
        CoefficientOfVariation = coefficientOfVariation;
    }

    public abstract void DisplayStatisticalResults();
}

public class ConcreteWrapResults : WrapResults
{
    public ConcreteWrapResults(double sum, double size, double mean, double median, double mode, double range, double interquartileRange,
                               double variance, double standardDeviation, double minimum, double maximum, double quartile1, double quartile2,
                               double quartile3, double percentile25, double percentile50, double percentile75, double skewness, double kurtosis,
                               double coefficientOfVariation)
        : base(sum, size, mean, median, mode, range, interquartileRange, variance, standardDeviation, minimum, maximum, quartile1, quartile2,
               quartile3, percentile25, percentile50, percentile75, skewness, kurtosis, coefficientOfVariation)
    {
    }

    public override void DisplayStatisticalResults()
    {
        try {
            // Provide the implementation for displaying statistical results
            var table = new Table();
            table.AddColumn("Statistic");
            table.AddColumn("Value");
            table.BorderColor(Color.Green3);
            table.Centered();
            table.Columns[0].LeftAligned();
            table.HeavyHeadBorder();

            // Add rows for each statistical result
            table.AddRow("Sum", Sum.ToString("F2"));
            table.AddRow("Size", Size.ToString("F2"));
            table.AddRow("Mean", Mean.ToString("F2"));
            table.AddRow("Median", Median.ToString("F2"));
            table.AddRow("Mode", Mode.ToString("F2"));
            table.AddRow("Range", Range.ToString("F2"));
            table.AddRow("Interquartile Range", InterquartileRange.ToString("F2"));
            table.AddRow("Variance", Variance.ToString("F2"));
            table.AddRow("Standard Deviation", StandardDeviation.ToString("F2"));
            table.AddRow("Minimum", Minimum.ToString("F2"));
            table.AddRow("Maximum", Maximum.ToString("F2"));
            table.AddRow("Quartile 1", Quartile1.ToString("F2"));
            table.AddRow("Quartile 2", Quartile2.ToString("F2"));
            table.AddRow("Quartile 3", Quartile3.ToString("F2"));
            table.AddRow("Percentile 25", Percentile25.ToString("F2"));
            table.AddRow("Percentile 50", Percentile50.ToString("F2"));
            table.AddRow("Percentile 75", Percentile75.ToString("F2"));
            table.AddRow("Skewness", Skewness.ToString("F2"));
            table.AddRow("Kurtosis", Kurtosis.ToString("F2"));
            table.AddRow("Coefficient of Variation", CoefficientOfVariation.ToString("F2"));

            // Display the table
            AnsiConsole.Write(table);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while displaying statistical results: {ex.Message}");
        }
    }
}

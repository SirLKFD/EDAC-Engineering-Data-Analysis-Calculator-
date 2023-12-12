using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Statistics;
public interface ICalculate
{
    double CalculateMean();
    double CalculateMedian();
    double CalculateMode();
    double CalculateRange();
    double CalculateStandardDeviation();
}

public interface ICalculateVariance
{
    double CalculateVariance();
}

public interface ICalculateInterquartileRange
{
    double CalculateInterquartileRange();
}
public interface ICalculateMedian
{
    double CalculateMedian();
}

class StatisticCalculation : ICalculate, ICalculateVariance, ICalculateInterquartileRange, ICalculateMedian
{
    private List<double> values;

    public StatisticCalculation(List<TableofValues> tableValues)
    {
        values = tableValues.Select(v => v.Value).ToList();
    }

    public double CalculateMean()
    {
        return values.Average();
    }

    public double CalculateMedian()
    {
        return values.Count > 0 ? Statistics.Median(values) : 0.0;
    }

    public double CalculateMode()
    {
        if (values.Count == 0)
        {
            return 0.0; // No mode for an empty list
        }

        Dictionary<double, int> frequencyCount = new Dictionary<double, int>();

        foreach (double value in values)
        {
            if (frequencyCount.ContainsKey(value))
            {
                frequencyCount[value]++;
            }
            else
            {
                frequencyCount[value] = 1;
            }
        }

        // Find the mode(s)
        List<double> modes = new List<double>();
        int maxFrequency = frequencyCount.Values.Max();

        foreach (var kvp in frequencyCount)
        {
            if (kvp.Value == maxFrequency)
            {
                modes.Add(kvp.Key);
            }
        }

        // Return the first mode if available, otherwise return double.NaN
        return modes.Count > 0 ? modes.First() : double.NaN;
    }

    public double CalculateRange()
    {
        // Implement the calculation of the range
        return values.Count > 0 ? values.Max() - values.Min() : 0.0;
    }

    public double CalculateInterquartileRange()
    {
        // Implement the calculation of the interquartile range
        if (values.Count < 4)
        {
            return 0.0; // Not enough data for interquartile range
        }

        values.Sort();

        int n = values.Count;
        int lowerIndex = n / 4;
        int upperIndex = (3 * n) / 4;

        double lowerQuartile = values[lowerIndex];
        double upperQuartile = values[upperIndex];

        return upperQuartile - lowerQuartile;
    }

    public double CalculateVariance()
    {       
        return values.Count > 1
            ? values.Select(v => Math.Pow(v - CalculateMean(), 2)).Sum() / (values.Count - 1)
            : 0.0; // Need at least two data points for variance
    }

    public double CalculateStandardDeviation()
    {
        // Call the CalculateVariance method and take the square root
        double variance = CalculateVariance();
        return Math.Sqrt(variance);
    }

    public double CalculateMinimum()
    {
        return values.Count > 0 ? values.Min() : 0.0;
    }

    public double CalculateMaximum()
    {
        return values.Count > 0 ? values.Max() : 0.0;
    }

  

    public double CalculateQuartile1()
    {
        if (values.Count < 4)
        {
            return 0.0; // Not enough data for quartiles
        }

        values.Sort();

        int n = values.Count;
        int index = n / 4;

        return values[index];
    }

    public double CalculateQuartile2()
    {
        return CalculateMedian(); // Quartile 2 is the same as the median
    }

    public double CalculateQuartile3()
    {
        if (values.Count < 4)
        {
            return 0.0; // Not enough data for quartiles
        }

        values.Sort();

        int n = values.Count;
        int index = (3 * n) / 4;

        return values[index];
    }

    public double CalculateTotalSum()
    {
        return values.Sum();
    }

    public int CalculateSize()
    {
        return values.Count;
    }

    public double CalculateSkewness()
    {
        if (values.Count < 3)
        {
            return 0.0; // Not enough data for skewness
        }

        return Statistics.Skewness(values);
    }

    public double CalculateKurtosis()
    {
        if (values.Count < 4)
        {
            return 0.0; // Not enough data for kurtosis
        }

        return Statistics.Kurtosis(values);
    }

    public double CalculateCoefficientOfVariation()
    {
        double mean = CalculateMean();
        double standardDeviation = CalculateStandardDeviation();

        return (standardDeviation / mean) * 100;
    }

    public double CalculatePercentile25()
    {
        if (values.Count < 4)
        {
            return 0.0; // Not enough data for percentiles
        }

        values.Sort();

        int n = values.Count;
        int index = n / 4;

        return values[index];
    }

    public double CalculatePercentile50()
    {
        return CalculateMedian(); // Percentile 50 is the same as the median
    }


    public double CalculatePercentile75()
    {
        if (values.Count < 4)
        {
            return 0.0; // Not enough data for percentiles
        }

        values.Sort();

        int n = values.Count;
        int index = (3 * n) / 4;

        return values[index];
    }

}

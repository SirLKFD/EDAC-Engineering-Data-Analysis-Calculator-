class Interquartile : InheritNumbers, ICalculate
{
    public double Calculate()
    {
        CollectNumbers();

        if (numbers.Length < 4)
        {
            throw new ArgumentException("At least four data points are required to calculate the interquartile range.");
        }

        // Sort the data points in ascending order
        Array.Sort(numbers);

        // Calculate the first quartile (Q1) and the third quartile (Q3)
        double q1 = CalculateQuartile(1);
        double q3 = CalculateQuartile(3);

        // Calculate the interquartile range (IQR)
        double iqr = q3 - q1;

        return iqr;
    }

    // Helper method to calculate the quartile (Q1, Q3)
    public double CalculateQuartile(int quartile)
    {
        int n = numbers.Length;
        double k = quartile * (n + 1) / 4.0;
        int k1 = (int)k;
        double d = k - k1;

        if (k1 == 0)
        {
            return numbers[0];
        }
        else if (k1 == n)
        {
            return numbers[n - 1];
        }
        else
        {
            return numbers[k1 - 1] + d * (numbers[k1] - numbers[k1 - 1]);
        }
    }
}
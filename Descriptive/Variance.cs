class Variance : InheritNumbers, ICalculate
{
    public double Calculate()
    {
        CollectNumbers();

        if (numbers.Length <= 1)
        {
            return 0;
        }
        else
        {
            double mean = numbers.Average();
            double sumOfSquares = CalculateSumOfSquares(mean);
            int n = numbers.Length;

            // Calculate sample variance (n - 1) or population variance (n)
            double variance = sumOfSquares / (n - 1);

            return variance;
        }
    }

    private double CalculateSumOfSquares(double mean)
    {
        double sumOfSquares = 0.0;

        foreach (int num in numbers)
        {
            sumOfSquares += Math.Pow((num - mean), 2.0);
        }

        return sumOfSquares;
    }
}

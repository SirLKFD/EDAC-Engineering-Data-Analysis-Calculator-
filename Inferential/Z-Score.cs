using MathNet.Numerics;

class ZScore : ICalculate
{
    private double x;
    private double mean;
    private double standardDeviation;

    public ZScore(double x, double mean, double standardDeviation)
    {
        this.x = x;
        this.mean = mean;
        this.standardDeviation = standardDeviation;
    }

    public double Calculate()
    {
        double zScore = (x - mean) / standardDeviation;
        return zScore;
    }

    public double CalculateProbability()
    {
        // Use MathNet.Numerics SpecialFunctions.Erf to calculate the error function (Erf)
        double zScore = Calculate();
        double probability = 0.5 * (1 + SpecialFunctions.Erf(zScore / Math.Sqrt(2)));

        return probability;
    }

    public double PLessThanX()
    {
        double zScore = Calculate();
        double probability = CalculateProbability();
        return probability;
    }

    public double PGreaterThanX()
    {
        double probability = 1 - PLessThanX();
        return probability;
    }

    public double PBetweenX(double lowerBound)
    {
        double pLessThanLowerBound = new ZScore(lowerBound, mean, standardDeviation).PLessThanX();
        double pBetween = PLessThanX() - pLessThanLowerBound;
        return pBetween;
    }
}

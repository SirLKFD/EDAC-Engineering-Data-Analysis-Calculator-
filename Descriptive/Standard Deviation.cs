class StandardDeviation : Variance
{
    public double CalculateStandardDeviation()
    {
        double variance = Calculate(); // Inherited from Variance
        double standardDeviation = Math.Sqrt(variance);
        return standardDeviation;
    }
}

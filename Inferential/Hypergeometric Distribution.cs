class Hypergeometric
{
    private int populationSize;
    private int sampleSize;
    private int successCount;
    private string condition;

    public Hypergeometric(int populationSize, int sampleSize, int successCount, string condition)
    {
        this.populationSize = populationSize;
        this.sampleSize = sampleSize;
        this.successCount = successCount;
        this.condition = condition;
    }

    public double Calculate(int x)
    {
        double hypergeometricProbability = 0;

        switch (condition)
        {
            case "Equal":
                hypergeometricProbability = (Choose(successCount, x) * Choose(populationSize - successCount, sampleSize - x)) / Choose(populationSize, sampleSize);
                break;
            case "Less Than":
                hypergeometricProbability = CumulativeLessThan(x);
                break;
            case "Less Than or Equal":
                hypergeometricProbability = CumulativeLessThan(x + 1);
                break;
            case "Greater Than":
                hypergeometricProbability = 1 - CumulativeLessThan(x + 1);
                break;
            case "Greater Than or Equal":
                hypergeometricProbability = 1 - CumulativeLessThan(x);
                break;
            default:
                break;
        }

        return hypergeometricProbability;
    }

    private double Choose(int n, int k)
    {
        if (k < 0 || k > n)
            return 0;

        double result = 1;
        for (int i = 1; i <= k; i++)
        {
            result *= (n - i + 1) / (double)i;
        }
        return result;
    }

    private double CumulativeLessThan(int x)
    {
        double cumulativeProbability = 0;
        for (int i = 0; i < x; i++)
        {
            cumulativeProbability += (Choose(successCount, i) * Choose(populationSize - successCount, sampleSize - i)) / Choose(populationSize, sampleSize);
        }
        return cumulativeProbability;
    }

    public string GetCondition()
    {
        return condition;
    }
}

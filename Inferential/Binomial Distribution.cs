class Binomial
{
    private int n;
    private double p;
    private string condition;

    public Binomial(int n, double p, string condition)
    {
        this.n = n;
        this.p = IsWholeNumber(p) ? (double)p / 100.0 : p;
        this.condition = condition;
    }

    public double Calculate(int x)
    {
        double binomialProbability = 0;

        switch (condition)
        {
            case "Equal":
                binomialProbability = BinomialCoefficient(n, x) * Math.Pow(p, x) * Math.Pow(1 - p, n - x);
                break;
            case "Less Than":
                binomialProbability = CumulativeLessThan(x);
                break;
            case "Less Than or Equal":
                binomialProbability = CumulativeLessThan(x + 1);
                break;
            case "Greater Than":
                binomialProbability = 1 - CumulativeLessThan(x + 1);
                break;
            case "Greater Than or Equal":
                binomialProbability = 1 - CumulativeLessThan(x);
                break;
            default:
                break;
        }

        return binomialProbability;
    }

    private double BinomialCoefficient(int n, int k)
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
            cumulativeProbability += BinomialCoefficient(n, i) * Math.Pow(p, i) * Math.Pow(1 - p, n - i);
        }
        return cumulativeProbability;
    }

    private bool IsWholeNumber(double number)
    {
        return number % 1 == 0;
    }

    public string GetCondition()
    {
        return condition;
    }
}

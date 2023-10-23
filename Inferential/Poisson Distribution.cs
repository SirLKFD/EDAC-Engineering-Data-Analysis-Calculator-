class Poisson
{
    private double lambda;
    private string condition;

    public Poisson(double lambda, string condition)
    {
        this.lambda = lambda;
        this.condition = condition;
    }

    public double Calculate(int x)
    {
        double poissonProbability = 0;

        switch (condition)
        {
            case "Equal":
                poissonProbability = (Math.Pow(lambda, x) * Math.Exp(-lambda)) / Factorial(x);
                break;
            case "Less Than":
                poissonProbability = CumulativeLessThan(x);
                break;
            case "Less Than or Equal":
                poissonProbability = CumulativeLessThan(x + 1);
                break;
            case "Greater Than":
                poissonProbability = 1 - CumulativeLessThan(x + 1);
                break;
            case "Greater Than or Equal":
                poissonProbability = 1 - CumulativeLessThan(x);
                break;
            default:
                break;
        }

        return poissonProbability;
    }

    private double Factorial(int n)
    {
        if (n == 0)
            return 1;

        double result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    private double CumulativeLessThan(int x)
    {
        double cumulativeProbability = 0;
        for (int i = 0; i < x; i++)
        {
            cumulativeProbability += (Math.Pow(lambda, i) * Math.Exp(-lambda)) / Factorial(i);
        }
        return cumulativeProbability;
    }

    public string GetCondition()
    {
        return condition;
    }
}

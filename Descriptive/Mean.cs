class Mean : InheritNumbers, ICalculate
{
    public double Calculate()
    {
        CollectNumbers();

        if (numbers.Length == 0)
        {
            return 0;
        }
        else
        {
            double mean = numbers.Average();
            return mean;
        }
    }
}
class Median : InheritNumbers, ICalculate
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
            Array.Sort(numbers);
            if (numbers.Length % 2 == 0)
            {
                int mid = numbers.Length / 2;
                double median = (numbers[mid - 1] + numbers[mid]) / 2.0;
                return median;
            }
            else
            {
                int mid = numbers.Length / 2;
                double median = numbers[mid];
                return median;
            }
        }
    }
}
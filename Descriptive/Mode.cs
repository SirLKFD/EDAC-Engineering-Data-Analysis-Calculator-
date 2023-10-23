class Mode : InheritNumbers, ICalculate
{
    public double Calculate()
    {
        CollectNumbers();

        Dictionary<double, int> numberCount = new Dictionary<double, int>();
        int maxCount = 0;
        double mode = 0;

        if (numbers.Length == 0)
        {
            return 0;
        }
        else
        {
            foreach (var number in numbers)
            {
                if (numberCount.ContainsKey(number))
                {
                    numberCount[number]++;
                }
                else
                {
                    numberCount[number] = 1;
                }
            }

            foreach (var kvp in numberCount)
            {
                if (kvp.Value > maxCount)
                {
                    maxCount = kvp.Value;
                    mode = kvp.Key;
                }
            }

            if (maxCount == 1)
            {
                Console.WriteLine("No unique mode found.");
                return 0;
            }
            else
            {
                return mode;
            }
        }
    }
}
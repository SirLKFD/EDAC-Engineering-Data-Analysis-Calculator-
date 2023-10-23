class InheritNumbers 
{
    protected double[] numbers;
    protected int count;

    public InheritNumbers()
    {
        numbers = new double[0];
        count = 1;
    }

    public virtual double Calculate()
    {
        CollectNumbers();
        return 0;
    }

    protected void CollectNumbers()
    {
        Console.WriteLine($"Enter numbers and type 'DONE' to calculate the {GetType().Name.Replace("StandardDeviation", "Standard Deviation").Replace("Interquartile", "Interquartile Range").ToLower()}: ");
        while (true)
        {
            Console.Write($"Enter number #{count}: ");
            string input = Console.ReadLine();

            if (input.ToUpper() == "DONE")
            {
                if (numbers.Length == 0)
                {
                    Console.WriteLine("No numbers entered.");
                }
                break;
            }
            else
            {
                if (double.TryParse(input, out double number))
                {
                    Array.Resize(ref numbers, numbers.Length + 1);
                    numbers[numbers.Length - 1] = number;
                    count++;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number or type 'DONE'.");
                }
            }
        }
    }
}

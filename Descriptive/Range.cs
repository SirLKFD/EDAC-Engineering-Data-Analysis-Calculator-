using System;

class Range : InheritNumbers, ICalculate
{
    public double Calculate()
    {
        double[] numbers = new double[0];
        int count = 1;

        Console.WriteLine("Enter numbers to calculate the range, and type 'DONE' to finish: ");

        while (true)
        {
            Console.Write($"Enter number #{count}: ");
            string input = Console.ReadLine();

            if (input.ToUpper() == "DONE")
            {
                if (numbers.Length == 0)
                {
                    Console.WriteLine("No numbers entered.");
                    return 0;
                }
                else
                {
                    double range = CalculateRange(numbers);
                    return range;
                }
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

    public double CalculateRange(double[] numbers)
    {
        if (numbers.Length == 0)
        {
            return 0;
        }

        double min = numbers[0];
        double max = numbers[0];

        foreach (double number in numbers)
        {
            if (number < min)
            {
                min = number;
            }
            if (number > max)
            {
                max = number;
            }
        }

        double range = max - min;
        return range;
    }
}

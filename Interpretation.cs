class Interpretation
{
    private string interpretation;
    private string unit;

    public Interpretation(string interpretation, string unit = null)
    {
        this.interpretation = interpretation;
        this.unit = unit;
    }

    public string GetInterpretation(string statisticType, double value)
    {
        if (!string.IsNullOrEmpty(unit))
        {
            return $"The {statisticType} of the {this.interpretation} is {value.ToString("F2")} {unit}";
        }
        else
        {
            return $"{statisticType} - {this.interpretation}: {value.ToString("F2")}";
        }
    }

    public static string GetPercentileInterpretation(string dataName, double q1, double q2, double q3)
    {
        return $"{dataName} - 25th Percentile (Q1): {q1:F2}, 50th Percentile (Q2): {q2:F2}, 75th Percentile (Q3): {q3:F2}";
    }

    public static string HandleInterpretation(string dataName, double value, string unit, string userInterpretation)
    {
        if (!string.IsNullOrEmpty(unit))
        {
            return $"{dataName} - {userInterpretation}: {value.ToString("F2")} {unit}";
        }
        else
        {
            return $"{dataName} - {userInterpretation}: {value.ToString("F2")}";
        }
    }

    public static string HandleInterpretation(string dataName, double value)
    {
        Console.Write("Do you want to include a unit in the interpretation? Y - yes, N - no: ");
        string userIncludeUnit = Console.ReadLine();

        if (userIncludeUnit.ToUpper() == "Y")
        {
            Console.Write("Please enter the unit measurement (e.g., km, mm, cm): ");
            string unit = Console.ReadLine();
            Console.Write("Please enter your interpretation: ");
            string interpret = Console.ReadLine();
            Interpretation interpretation = new Interpretation(interpret, unit);
            return interpretation.GetInterpretation(dataName, value);
        }
        else if (userIncludeUnit.ToUpper() == "N")
        {
            Console.Write("Do you want a simple interpretation (S) or just print the output (P)? ");
            string userChoice = Console.ReadLine();
            if (userChoice.ToUpper() == "S")
            {
                Console.Write("Please enter your interpretation: ");
                string interpret = Console.ReadLine();
                Interpretation interpretation = new Interpretation(interpret);
                return interpretation.GetInterpretation(dataName, value);
            }
            else if (userChoice.ToUpper() == "P")
            {
                return $"{dataName} - {value.ToString("F2")}";
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 'S' for a simple interpretation or 'P' to print the output.");
                return HandleInterpretation(dataName, value);
            }
        }
        else
        {
            return $"{dataName} - {value.ToString("F2")}";
        }
    }

}

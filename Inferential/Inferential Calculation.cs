class InferentialCalculation
{
    public static void CalculateZScore(List<TableofValues> tableValues, Sequencing sequencing)
    {
        try
        {
            Console.Write("Enter the raw score (x): ");
            double x = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the total mean: ");
            double mean = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the total standard deviation: ");
            double standardDeviation = Convert.ToDouble(Console.ReadLine());

            ZScore zScoreCalculator = new ZScore(x, mean, standardDeviation);
            double zScore = zScoreCalculator.Calculate();

            Console.Write("Do you want to include interpretation? (Y/N): ");
            string wantInterpretationInput = Console.ReadLine();
            bool wantInterpretation = wantInterpretationInput.Equals("Y", StringComparison.OrdinalIgnoreCase);

            string result = null;
            string unit = ""; // Initialize unit as an empty string
            string userInterpretation = ""; // Initialize userInterpretation


            if (wantInterpretation)
            {              
                Console.Write("Please enter your interpretation for Z-Score: ");
                userInterpretation = Console.ReadLine(); // Set the value of userInterpretation here
                Console.Write("Please enter the unit measurement (e.g., km, mm, cm): ");
                unit = Console.ReadLine();
                result = Interpretation.HandleInterpretation("Z-Score", zScore, unit, userInterpretation);
            }

            if (result != null)
            {
                Console.WriteLine(result);
            }

            // Calculate p-values
            double pLessThanX = zScoreCalculator.PLessThanX();
            double pGreaterThanX = zScoreCalculator.PGreaterThanX();
            double pBetween12AndX = zScoreCalculator.PBetweenX(12);

            Console.WriteLine($"P(x < {x}) = {Math.Abs(pLessThanX):P4} or {Math.Abs(pLessThanX):F4}");
            Console.WriteLine($"P(x > {x}) = {Math.Abs(pGreaterThanX):P4} or {Math.Abs(pGreaterThanX):F4}");
            Console.WriteLine($"P(12 < x < {x}) = {Math.Abs(pBetween12AndX):P4} or {Math.Abs(pBetween12AndX):F4}");

            int zScoreCount = sequencing.GetNextCount("Z-Score");
            //             TableofValues meanValue = new TableofValues(tableValues.Count, $"Mean # {meanCount}", mean, "", unit, userInterpretation);
            TableofValues zScoreValue = new TableofValues(tableValues.Count, $"Z-Score # {zScoreCount}", zScore, "", unit, userInterpretation);
            tableValues.Add(zScoreValue);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid input. Please enter numeric values for raw score (x), mean, and standard deviation.");
        }
    }

    public static void CalculateBinomialDistribution(List<TableofValues> tableValues, Sequencing sequencing)
    {
        try
        {
            Console.Write("Enter the number of trials (n): ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the probability of success (p): ");
            double p = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the specific value (x): ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select a condition:");
            Console.WriteLine("1. Equal");
            Console.WriteLine("2. Less Than");
            Console.WriteLine("3. Greater Than");
            Console.WriteLine("4. Less Than or Equal");
            Console.WriteLine("5. Greater Than or Equal");
            Console.Write("Enter the condition (1-5): ");

            string condition = "";

            int conditionChoice = Convert.ToInt32(Console.ReadLine());

            switch (conditionChoice)
            {
                case 1:
                    condition = "Equal";
                    break;
                case 2:
                    condition = "Less Than";
                    break;
                case 3:
                    condition = "Greater Than";
                    break;
                case 4:
                    condition = "Less Than or Equal";
                    break;
                case 5:
                    condition = "Greater Than or Equal";
                    break;
                default:
                    Console.WriteLine("Invalid condition choice.");
                    return;
            }

            Binomial binomialCalculator = new Binomial(n, p, condition);
            double binomialProbability = binomialCalculator.Calculate(x) * 100; // Multiply by 100 to convert to percentage

            Console.Write("Do you want to include interpretation? (Y/N): ");
            string wantInterpretationInput = Console.ReadLine();
            bool wantInterpretation = wantInterpretationInput.Equals("Y", StringComparison.OrdinalIgnoreCase);

            string result = null;
            string unit = ""; // Initialize unit as an empty string
            string userInterpretation = ""; // Initialize userInterpretation


            if (wantInterpretation)
            {
                Console.Write("Please enter your interpretation for Binomial Distribution: ");
                userInterpretation = Console.ReadLine(); // Set the value of userInterpretation here
                Console.Write("Please enter the unit measurement (e.g., km, mm, cm): ");
                unit = Console.ReadLine();
                result = Interpretation.HandleInterpretation("Binomial Distribution", binomialProbability, unit, userInterpretation);
            }

            if (result != null)
            {
                Console.WriteLine(result);
            }

            if (condition == "Equal")
            {
                Console.WriteLine($"Binomial probability: P(X {condition} {x}) = {binomialProbability:F2}%");
            }
            else
            {
                Console.WriteLine($"Cumulative probability: P(X {condition} {x}) = {binomialProbability:F2}%");
            }

            int BinomialCount = sequencing.GetNextCount("Binomial");
            TableofValues binomialValue = new TableofValues(tableValues.Count, $"Binomial # {BinomialCount}", binomialProbability, "", unit, userInterpretation);
            tableValues.Add(binomialValue);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid input. Please enter numeric values for the number of trials (n), probability of success (p), and the specific value (x).");
        }
    }

    public static void CalculatePoissonDistribution(List<TableofValues> tableValues, Sequencing sequencing)
    {
        try
        {
            Console.Write("Enter the value of lambda: ");
            double lambda = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the specific value (x): ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select a condition:");
            Console.WriteLine("1. Equal");
            Console.WriteLine("2. Less Than");
            Console.WriteLine("3. Greater Than");
            Console.WriteLine("4. Less Than or Equal");
            Console.WriteLine("5. Greater Than or Equal");
            Console.Write("Enter the condition (1-5): ");

            string condition = "";

            int conditionChoice = Convert.ToInt32(Console.ReadLine());

            switch (conditionChoice)
            {
                case 1:
                    condition = "Equal";
                    break;
                case 2:
                    condition = "Less Than";
                    break;
                case 3:
                    condition = "Greater Than";
                    break;
                case 4:
                    condition = "Less Than or Equal";
                    break;
                case 5:
                    condition = "Greater Than or Equal";
                    break;
                default:
                    Console.WriteLine("Invalid condition choice.");
                    return;
            }

            Poisson poissonCalculator = new Poisson(lambda, condition);
            double poissonProbability = poissonCalculator.Calculate(x) * 100; // Multiply by 100 to convert to a percentage

            Console.Write("Do you want to include interpretation? (Y/N): ");
            string wantInterpretationInput = Console.ReadLine();
            bool wantInterpretation = wantInterpretationInput.Equals("Y", StringComparison.OrdinalIgnoreCase);

            string result = null;
            string unit = ""; // Initialize unit as an empty string
            string userInterpretation = ""; // Initialize userInterpretation

            /* string userInterpretation = ""; // Initialize userInterpretation

            if (wantInterpretation)
            {
                Console.Write("Please enter your interpretation for Hypergeometric Distribution: ");
                userInterpretation = Console.ReadLine(); // Set the value of userInterpretation here
                Console.Write("Please enter the unit measurement (e.g., km, mm, cm): ");
                unit = Console.ReadLine();
                result = Interpretation.HandleInterpretation("Hypergeometric Distribution", hypergeometricProbability, unit, userInterpretation);
            }

            if (result != null)
            {
                Console.WriteLine(result);
            }

            if (condition == "Equal")
            {
                Console.WriteLine($"P(X {condition} {x}) = {hypergeometricProbability:F2}%");
            }
            else
            {
                Console.WriteLine($"Cumulative probability: P(X {condition} {x}) = {hypergeometricProbability:F2}%");
            }

            int HypergeometricCount = sequencing.GetNextCount("Hypergeometric");

            TableofValues hypergeometricValue = new TableofValues(tableValues.Count, $"Hypergeometric # {HypergeometricCount}", hypergeometricProbability, "", unit, userInterpretation);
            tableValues.Add(hypergeometricValue);
        }*/

            if (wantInterpretation)
            {
                Console.Write("Please enter your interpretation for Poisson Distribution: ");
                userInterpretation = Console.ReadLine(); // Set the value of userInterpretation here
                Console.Write("Please enter the unit measurement (e.g., km, mm, cm): ");
                unit = Console.ReadLine();
                result = Interpretation.HandleInterpretation("Poisson Distribution", poissonProbability, unit, userInterpretation);
            }

            if (result != null)
            {
                Console.WriteLine(result);
            }

            if (condition == "Equal")
            {
                Console.WriteLine($"P(X {condition} {x}) = {poissonProbability:F2}%");
            }
            else
            {
                Console.WriteLine($"Cumulative probability: P(X {condition} {x}) = {poissonProbability:F2}%");
            }

            int PoissonCount = sequencing.GetNextCount("Poisson");
            TableofValues poissonValue = new TableofValues(tableValues.Count, $"Poisson # {PoissonCount}", poissonProbability, "", unit, userInterpretation);
            tableValues.Add(poissonValue);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid input. Please enter numeric values for lambda and the specific value (x).");
        }
    }

    public static void CalculateHypergeometricDistribution(List<TableofValues> tableValues, Sequencing sequencing)
    {
        try
        {
            Console.Write("Enter the population size: ");
            int populationSize = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the sample size: ");
            int sampleSize = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the number of successful outcomes: ");
            int successCount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Number of successes in sample: ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select a condition:");
            Console.WriteLine("1. Equal");
            Console.WriteLine("2. Less Than");
            Console.WriteLine("3. Greater Than");
            Console.WriteLine("4. Less Than or Equal");
            Console.WriteLine("5. Greater Than or Equal");
            Console.Write("Enter the condition (1-5): ");

            string condition = "";

            int conditionChoice = Convert.ToInt32(Console.ReadLine());

            switch (conditionChoice)
            {
                case 1:
                    condition = "Equal";
                    break;
                case 2:
                    condition = "Less Than";
                    break;
                case 3:
                    condition = "Greater Than";
                    break;
                case 4:
                    condition = "Less Than or Equal";
                    break;
                case 5:
                    condition = "Greater Than or Equal";
                    break;
                default:
                    Console.WriteLine("Invalid condition choice.");
                    return;
            }

            Hypergeometric hypergeometricCalculator = new Hypergeometric(populationSize, sampleSize, successCount, condition);
            double hypergeometricProbability = hypergeometricCalculator.Calculate(x) * 100; // Multiply by 100 to convert to percentage

            Console.Write("Do you want to include interpretation? (Y/N): ");
            string wantInterpretationInput = Console.ReadLine();
            bool wantInterpretation = wantInterpretationInput.Equals("Y", StringComparison.OrdinalIgnoreCase);

            string result = null;
            string unit = ""; // Initialize unit as an empty string
            string userInterpretation = ""; // Initialize userInterpretation

            if (wantInterpretation)
            {
                Console.Write("Please enter your interpretation for Hypergeometric Distribution: ");
                userInterpretation = Console.ReadLine(); // Set the value of userInterpretation here
                Console.Write("Please enter the unit measurement (e.g., km, mm, cm): ");
                unit = Console.ReadLine();
                result = Interpretation.HandleInterpretation("Hypergeometric Distribution", hypergeometricProbability, unit, userInterpretation);
            }

            if (result != null)
            {
                Console.WriteLine(result);
            }

            if (condition == "Equal")
            {
                Console.WriteLine($"P(X {condition} {x}) = {hypergeometricProbability:F2}%");
            }
            else
            {
                Console.WriteLine($"Cumulative probability: P(X {condition} {x}) = {hypergeometricProbability:F2}%");
            }

            int HypergeometricCount = sequencing.GetNextCount("Hypergeometric");

            TableofValues hypergeometricValue = new TableofValues(tableValues.Count, $"Hypergeometric # {HypergeometricCount}", hypergeometricProbability, "", unit, userInterpretation);
            tableValues.Add(hypergeometricValue);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid input. Please enter numeric values for the population size, sample size, number of successful outcomes, and the specific value (x).");
        }
    }
}

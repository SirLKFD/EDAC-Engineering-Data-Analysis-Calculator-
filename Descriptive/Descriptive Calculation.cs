class DescriptiveCalculation
{
    public static void CalculateAndStoreMean(List<TableofValues> tableValues, Sequencing sequencing)
    {
        try
        {
            Mean mean_calc = new Mean();
            double mean = mean_calc.Calculate();
            Console.Write("Do you want to include units in the interpretation? Y - yes, N - no: ");
            string userIncludeUnits = Console.ReadLine();
            string unit = null;

            if (userIncludeUnits.ToUpper() == "Y")
            {
                Console.Write("Please enter the unit measurement (e.g., km, mm, cm): ");
                unit = Console.ReadLine();
            }

            Console.Write("Please enter your interpretation for Mean: ");
            string userInterpretation = Console.ReadLine();
            string interpretationResult = Interpretation.HandleInterpretation("Mean", mean, unit, userInterpretation);
            Console.WriteLine(interpretationResult);

            int meanCount = sequencing.GetNextCount("Mean");      
            TableofValues meanValue = new TableofValues(tableValues.Count, $"Mean # {meanCount}", mean, "", unit, userInterpretation);
            tableValues.Add(meanValue);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


    public static void CalculateAndStoreMedian(List<TableofValues> tableValues, Sequencing sequencing)
    {
        try
        {
            Median median_calc = new Median();
            double median = median_calc.Calculate();
            Console.Write("Do you want to include units in the interpretation? Y - yes, N - no: ");
            string userIncludeUnits = Console.ReadLine();
            string unit = null;

            if (userIncludeUnits.ToUpper() == "Y")
            {
                Console.Write("Please enter the unit measurement (e.g., km, mm, cm): ");
                unit = Console.ReadLine();
            }

            Console.Write("Please enter your interpretation for Median: ");
            string userInterpretation = Console.ReadLine();
            string interpretationResult = Interpretation.HandleInterpretation("Median", median, unit, userInterpretation);
            Console.WriteLine(interpretationResult);

            int medianCount = sequencing.GetNextCount("Median");
            TableofValues medianValue = new TableofValues(tableValues.Count, $"Median # {medianCount}", median, "", unit, userInterpretation);
            tableValues.Add(medianValue);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void CalculateAndStoreMode(List<TableofValues> tableValues, Sequencing sequencing)
    {
        try
        {
            Mode mode_calc = new Mode();
            double mode = mode_calc.Calculate();
            Console.Write("Do you want to include units in the interpretation? Y - yes, N - no: ");
            string userIncludeUnits = Console.ReadLine();
            string unit = null;

            if (userIncludeUnits.ToUpper() == "Y")
            {
                Console.Write("Please enter the unit measurement (e.g., km, mm, cm): ");
                unit = Console.ReadLine();
            }

            Console.Write("Please enter your interpretation for Mode: ");
            string userInterpretation = Console.ReadLine();
            string interpretationResult = Interpretation.HandleInterpretation("Mode", mode, unit, userInterpretation);
            Console.WriteLine(interpretationResult);

            int modeCount = sequencing.GetNextCount("Mode");
            TableofValues modeValue = new TableofValues(tableValues.Count, $"Mode # {modeCount}", mode, "", unit, userInterpretation);
            tableValues.Add(modeValue);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void CalculateAndStoreRange(List<TableofValues> tableValues, Sequencing sequencing)
    {
        try
        {
            Range range_calc = new Range();
            double range = range_calc.Calculate();
            Console.Write("Do you want to include units in the interpretation? Y - yes, N - no: ");
            string userIncludeUnits = Console.ReadLine();
            string unit = null;

            if (userIncludeUnits.ToUpper() == "Y")
            {
                Console.Write("Please enter the unit measurement (e.g., km, mm, cm): ");
                unit = Console.ReadLine();
            }

            Console.Write("Please enter your interpretation for Range: ");
            string userInterpretation = Console.ReadLine();
            string interpretationResult = Interpretation.HandleInterpretation("Range", range, unit, userInterpretation);
            Console.WriteLine(interpretationResult);

            int rangeCount = sequencing.GetNextCount("Range");
            TableofValues rangeValue = new TableofValues(tableValues.Count, $"Range # {rangeCount}", range, "", unit, userInterpretation);
            tableValues.Add(rangeValue);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    //QUARTILES WILL NOT CALCULATE PROPERLY, UNDER CONSTRUCTION
    public static void CalculateAndStoreInterquartile(List<TableofValues> tableValues, Sequencing sequencing)
    {
        try
        {
            Interquartile interquartile_calc = new Interquartile();
            double interquartile = interquartile_calc.Calculate();

            // Calculate Q1 (25th Percentile), Q2 (50th Percentile), and Q3 (75th Percentile)
            double q1 = interquartile_calc.CalculateQuartile(1);
            double q2 = interquartile_calc.CalculateQuartile(2);
            double q3 = interquartile_calc.CalculateQuartile(3);

            Console.Write("Do you want to include units in the interpretation? Y - yes, N - no: ");
            string userIncludeUnits = Console.ReadLine();
            string unit = null;

            if (userIncludeUnits.ToUpper() == "Y")
            {
                Console.Write("Please enter the unit measurement (e.g., km, mm, cm): ");
                unit = Console.ReadLine();
            }

            Console.Write("Please enter your interpretation for Interquartile Range: ");
            string userInterpretation = Console.ReadLine();
            string interpretationResult = Interpretation.HandleInterpretation("Interquartile Range", interquartile, unit, userInterpretation);
            Console.WriteLine(interpretationResult);

            int interquartileCount = sequencing.GetNextCount("Interquartile Range");
            TableofValues interquartileValue = new TableofValues(tableValues.Count, $"Interquartile Range # {interquartileCount}", interquartile, "", unit, userInterpretation);
            tableValues.Add(interquartileValue);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void CalculateAndStoreVariance(List<TableofValues> tableValues, Sequencing sequencing)
    {
        try
        {
            Variance variance_calc = new Variance();
            double variance = variance_calc.Calculate();
            Console.Write("Do you want to include units in the interpretation? Y - yes, N - no: ");
            string userIncludeUnits = Console.ReadLine();
            string unit = null;

            if (userIncludeUnits.ToUpper() == "Y")
            {
                Console.Write("Please enter the unit measurement (e.g., km, mm, cm): ");
                unit = Console.ReadLine();
            }

            Console.Write("Please enter your interpretation for Variance: ");
            string userInterpretation = Console.ReadLine();
            string interpretationResult = Interpretation.HandleInterpretation("Variance", variance, unit, userInterpretation);
            Console.WriteLine(interpretationResult);

            int varianceCount = sequencing.GetNextCount("Variance");
            TableofValues varianceValue = new TableofValues(tableValues.Count, $"Variance # {varianceCount}", variance, "", unit, userInterpretation);
            tableValues.Add(varianceValue);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void CalculateAndStoreStandardDeviation(List<TableofValues> tableValues, Sequencing sequencing)
    {
        try
        {
            StandardDeviation SD_calc = new StandardDeviation();
            double sd = SD_calc.Calculate();
            Console.Write("Do you want to include units in the interpretation? Y - yes, N - no: ");
            string userIncludeUnits = Console.ReadLine();
            string unit = null;

            if (userIncludeUnits.ToUpper() == "Y")
            {
                Console.Write("Please enter the unit measurement (e.g., km, mm, cm): ");
                unit = Console.ReadLine();
            }

            Console.Write("Please enter your interpretation for Standard Deviation: ");
            string userInterpretation = Console.ReadLine();
            string interpretationResult = Interpretation.HandleInterpretation("Standard Deviation", sd, unit, userInterpretation);
            Console.WriteLine(interpretationResult);

            int SDCount = sequencing.GetNextCount("Standard Deviation");
            TableofValues sdValue = new TableofValues(tableValues.Count, $"Standard Deviation # {SDCount}", sd, "", unit, userInterpretation);
            tableValues.Add(sdValue);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

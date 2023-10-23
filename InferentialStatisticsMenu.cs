using System;
using System.Linq;
using MathNet.Numerics.Distributions;
using OxyPlot;
using OxyPlot.Series;
using static System.Formats.Asn1.AsnWriter;

class InferentialStatisticsMenu
{
    private static List<TableofValues> tableValues = new List<TableofValues>(); //List of Values
    private static Sequencing sequencing = new Sequencing(); //Sequencing
    public static void Run(List<TableofValues> tableValues, Sequencing sequencing)
    {
      
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Inferential Statistics");
            Console.WriteLine("----------------------");
            Console.WriteLine("1. Calculate Z-Score");
            Console.WriteLine("2. Calculate Binomial Distribution");
            Console.WriteLine("3. Calculate Poisson Distribution");
            Console.WriteLine("4. Calculate Hypergeometric Distribution");
            Console.WriteLine("5. Calculate Normal Distribution (UNDER CONSTRUCTION)");
            Console.WriteLine("6. Calculate Exponential Distribution (UNDER CONSTRUCTION)");
            Console.WriteLine("7. Calculate Sampling Distribution of the Sample Mean (UNDER CONSTRUCTION)");
            Console.WriteLine("8. Calculate Confidence Interval (UNDER CONSTRUCTION)");
            Console.WriteLine("9. Calculate Sample Size Determination (UNDER CONSTRUCTION)");
            Console.WriteLine("10. Table of Values");
            Console.WriteLine("11. Back to Main Menu");
            Console.Write("Please select an option (1-11): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                // Add code to handle each inferential statistics function here
                case "1":
                    // ZScore
                    Console.Clear();
                    InferentialCalculation.CalculateZScore(tableValues, sequencing);
                    break;

                case "2":
                    //Binomial Distribution
                    Console.Clear();
                    InferentialCalculation.CalculateBinomialDistribution(tableValues, sequencing);
                    break;

                case "3":
                    //Poisson Distribution
                    Console.Clear();
                    InferentialCalculation.CalculatePoissonDistribution(tableValues, sequencing);
                    break;
                case "4":
                    //Hypergeometric Distribution
                    Console.Clear();
                    InferentialCalculation.CalculateHypergeometricDistribution(tableValues, sequencing);
                    break;
                case "5":
                    Console.Clear();
                    // Calculate Normal Distribution
                    // Add your implementation here
                    break;
                case "6":
                    Console.Clear();
                    // Calculate Exponential Distribution
                    // Add your implementation here
                    break;
                case "7":
                    Console.Clear();
                    // Calculate Sampling Distribution of the Sample Mean 
                    // Add your implementation here
                    break;
                case "8":
                    Console.Clear();
                    // Calculate Confidence Interval PUT OPTIONS WHEN VARIANCE KNOWN, VARIANCE UNKNOWN (WITHIN LESS THAN 30 GREATER THAN OR EQUAL TO 30), AND STANDARD DEVIATION/VARIANCE OF A NORMAL DISTRIBUTION
                    // Add your implementation here
                    break;            
                case "9":
                    Console.Clear();
                    // Calculate Sample Size Determination PUT OPTIONS IF THE USER WANTS MEAN OR PROPORTION
                    // Add your implementation here
                    break;
                case "10":
                    Console.Clear();
                    TableofValues.ManageTable(tableValues, sequencing);
                    break;
                case "11":
                    Console.Clear();
                    // Return to the previous menu
                    return;            
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

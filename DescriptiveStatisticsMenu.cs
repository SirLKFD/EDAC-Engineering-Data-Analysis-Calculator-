using System;
using System.Collections.Generic;
using System.Text;

class DescriptiveStatisticsMenu
{
    private static List<TableofValues> tableValues = new List<TableofValues>(); //List of Values
    private static Sequencing sequencing = new Sequencing(); //Sequencing

    public static void Run(List<TableofValues> tableValues, Sequencing sequencing)
    {    
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Descriptive Statistics");
            Console.WriteLine("----------------------");
            Console.WriteLine("1. Calculate Mean");
            Console.WriteLine("2. Calculate Median");
            Console.WriteLine("3. Calculate Mode");
            Console.WriteLine("4. Calculate Range");
            Console.WriteLine("5. Calculate Interquartile Range (UNDER CONSTRUCTION, WILL NOT CALCULATE PROPERLY)");
            Console.WriteLine("6. Calculate Variance");
            Console.WriteLine("7. Calculate Standard Deviation");
            Console.WriteLine("8. Table of Values");
            Console.WriteLine("9. Back to Main Menu");
            Console.Write("Please select an option (1-8): ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                // descriptive statistics methods
                case 1:
                    Console.Clear();
                    DescriptiveCalculation.CalculateAndStoreMean(tableValues, sequencing);
                    break;
               
                case 2:
                    Console.Clear();
                    DescriptiveCalculation.CalculateAndStoreMedian(tableValues, sequencing);
                    break;
              
                case 3:
                    Console.Clear();
                    DescriptiveCalculation.CalculateAndStoreMode(tableValues, sequencing);
                    break;
                
                case 4:
                    Console.Clear();
                    DescriptiveCalculation.CalculateAndStoreRange(tableValues, sequencing);
                    break;

                case 5:
                    Console.Clear();
                    DescriptiveCalculation.CalculateAndStoreInterquartile(tableValues, sequencing);
                    break;
               
                case 6:
                    Console.Clear();
                    DescriptiveCalculation.CalculateAndStoreVariance(tableValues, sequencing);
                    break;
                
                case 7:
                    Console.Clear();
                    DescriptiveCalculation.CalculateAndStoreStandardDeviation(tableValues, sequencing);
                    break;
                case 8:
                    Console.Clear();
                    TableofValues.DisplayTable(tableValues);
                    TableofValues.ManageTable(tableValues, sequencing);
                    break;
                 
                case 9:
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
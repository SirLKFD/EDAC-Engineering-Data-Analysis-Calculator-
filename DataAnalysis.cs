using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;
using MathNet.Numerics.Distributions;

class DataAnalysis
{
    public static void GenerateBarGraph(List<TableofValues> tableValues)
    {
        Console.Clear();
        TableofValues.DisplayTable(tableValues);
        Console.WriteLine("Data Analysis - Bar Graph");
        Console.WriteLine();

        // Ask the user to select IDs for the values to be used in the bar graph
        Console.WriteLine("Select the IDs of the values to be used for the bar graph (comma-separated):");
        string idInput = Console.ReadLine();
        List<int> selectedIds = idInput.Split(',').Select(int.Parse).ToList();

        List<TableofValues> selectedValues = tableValues.Where(tv => selectedIds.Contains(tv.ID)).ToList();

        // Ask the user for interpretation
        Console.Write("Enter the data interpretation for the bar graph: ");
        string dataInterpretation = Console.ReadLine();

        Console.WriteLine();

        // Determine the maximum value for scaling
        double maxValue = selectedValues.Max(tv => tv.Value);
        double scaleFactor = 1.0;

        // Define a maximum width for the bars
        int maxWidth = 60; // Adjust this value as needed

        if (maxValue > maxWidth)
        {
            scaleFactor = maxWidth / maxValue;
        }

        // Create a table for the bar graph using ConsoleTables
        var table = new ConsoleTable("Categories", dataInterpretation, "");

        // Define an array of color codes (you can customize this)
        string[] colorCodes = { "\x1b[31m", "\x1b[32m", "\x1b[33m", "\x1b[34m", "\x1b[35m", "\x1b[36m", "\x1b[37m" };

        // Add rows to the table for the bar graph
        for (int i = 0; i < selectedValues.Count; i++)
        {
            var value = selectedValues[i];
            int barLength = (int)(value.Value * scaleFactor);
            var bar = new string('█', barLength); // Create a bar using '█' characters

            // Apply a color code to each bar
            var coloredBar = colorCodes[i % colorCodes.Length] + bar + "\x1b[0m"; // Reset color

            table.AddRow(value.Interpretation, coloredBar, value.Value.ToString("N2"));
        }

        // Display the table with the bar graph, including the values
        table.Write(Format.MarkDown);

        Console.WriteLine("\nPress any key to return");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;
using MathNet.Numerics.Distributions;
using OxyPlot;
using OxyPlot.Series;

class DataAnalysis
{
    public static void GenerateBarGraph(List<TableofValues> tableValues)
    {
        Console.Clear();
        Console.WriteLine("Data Analysis - Bar Graph");

        // Ask the user to select IDs for the values to be used in the bar graph
        Console.WriteLine("Select the IDs of the values to be used for the bar graph (comma-separated):");
        string idInput = Console.ReadLine();
        List<int> selectedIds = idInput.Split(',').Select(int.Parse).ToList();

        List<TableofValues> selectedValues = tableValues.Where(tv => selectedIds.Contains(tv.ID)).ToList();

        // Ask the user for interpretation
        Console.Write("Enter the data interpretation for the bar graph: ");
        string dataInterpretation = Console.ReadLine();

        // Create a table for the bar graph using ConsoleTables
        var table = new ConsoleTable("Value", "Bar");

        // Add rows to the table for the bar graph
        foreach (var value in selectedValues)
        {
            var bar = new string('█', (int)value.Value); // Create a bar using '█' characters
            table.AddRow(value.Value, bar);
        }

        // Display the table with the bar graph
        table.Write(Format.MarkDown);

        // Display data interpretation below the bar graph
        Console.WriteLine("\nData Interpretation: " + dataInterpretation);
    }
}
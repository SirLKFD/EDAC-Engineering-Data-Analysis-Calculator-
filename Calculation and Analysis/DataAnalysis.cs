using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;

class DataAnalysis
{
    public static void GenerateBarGraph(List<TableofValues> tableValues)
    {
        Console.Clear();
        TableofValues.DisplayTable(tableValues);
        Console.WriteLine("Data Analysis - Bar Graph");
        Console.WriteLine();

        var graphOption = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select Graph Option:")
                .AddChoices(new[] { "All Datasets", "Selected Dataset/s", "Individual IDs", "Go Back" })
                .HighlightStyle(new Style().Foreground(Color.Green))
        );

        List<TableofValues> selectedValues;

        switch (graphOption)
        {
            case "All Datasets":
                Music.PlaySelectSound();
                // Graph all datasets together
                selectedValues = tableValues;
                break;

            case "Individual IDs":
                Music.PlaySelectSound();
                Console.WriteLine("Select the IDs of the values to be used for the bar graph (comma-separated):");
                string idInput = Console.ReadLine();
                List<int> selectedIds = idInput.Split(',').Select(int.Parse).ToList();
                selectedValues = tableValues.Where(tv => selectedIds.Contains(tv.ID)).ToList();
                break;

            case "Selected Dataset/s":
                Music.PlaySelectSound();
                Console.WriteLine("Select the datasets to be used for the bar graph (comma-separated):");
                string datasetsInput = Console.ReadLine();
                List<int> selectedDatasets = datasetsInput.Split(',').Select(int.Parse).ToList();
                DisplaySelectedBarGraphs(tableValues, selectedDatasets);
                return;     

            case "Go Back":
                Music.PlaySelectSound();
                Console.WriteLine("Press any key to continue");
                return;

            default:
                Music.PlayErrorSound();
                Console.WriteLine("Invalid option. Exiting data analysis.");
                return;
        }

        // Ask the user for interpretation for each graph
        Music.PlaySelectSound();
        Console.Write("Enter the data interpretation for all datasets: ");
        string allDatasetsInterpretation = Console.ReadLine();

        // Display graphs for all datasets
        Music.PlaySuccessSound();
        DisplayBarGraph(selectedValues, allDatasetsInterpretation);

        Console.WriteLine("\nPress any key to return");

    }

    private static void DisplaySelectedBarGraphs(List<TableofValues> tableValues, List<int> datasetNumbers)
    {
        List<Tuple<List<TableofValues>, string>> datasetsWithInterpretations = new List<Tuple<List<TableofValues>, string>>();

        foreach (int datasetNumber in datasetNumbers)
        {
            Music.PlaySelectSound();
            Console.Write($"Enter the data interpretation for DATASET {datasetNumber}: ");
            string interpretation = Console.ReadLine();
            List<TableofValues> selectedValues = FilterTableByDatasetNumber(tableValues, datasetNumber);

            datasetsWithInterpretations.Add(new Tuple<List<TableofValues>, string>(selectedValues, interpretation));
        }

        Console.Clear();  

        foreach (var datasetWithInterpretation in datasetsWithInterpretations)
        {
            Console.WriteLine(); // Add a newline for clarity
            Music.PlaySuccessSound();
            DisplayBarGraph(datasetWithInterpretation.Item1, datasetWithInterpretation.Item2);

        }
    }

    private static void DisplayBarGraph(List<TableofValues> selectedValues, string dataInterpretation)
    {
        // Determine the maximum and minimum values for scaling
        double maxValue = selectedValues.Max(tv => tv.Value);
        double minValue = selectedValues.Min(tv => tv.Value);

        // Define a maximum and minimum height for the bars
        int maxHeight = 20; // Adjust this value as needed
        int minHeight = 3;  // Adjust this value as needed

        // Calculate the scale factors
        double scaleFactor = 1.0;
        double minValueScaleFactor = 1.0;

        if (maxValue > maxHeight)
        {
            scaleFactor = maxHeight / maxValue;
        }

        if (minValue < minHeight)
        {
            minValueScaleFactor = minHeight / minValue;
        }

        // Determine the overall scale factor
        double overallScaleFactor = Math.Min(scaleFactor, minValueScaleFactor);

        // Create a table for the bar graph using Spectre.Console
        var table = new Table();

        // Add columns to the table
        table.AddColumn(new TableColumn("Categories"));
        table.AddColumn(new TableColumn($"[palegreen1 underline bold rapidblink]{dataInterpretation}[/]"));
        table.AddColumn(new TableColumn("Value"));
        table.Centered();
        table.BorderColor(Color.Yellow1);
        table.Border = TableBorder.Horizontal;

        // Define an array of color codes (you can customize this)
        string[] colorCodes = {
        "[red]", "[green]", "[yellow]", "[blue]", "[purple]", "[cyan]", "[white]",
        "[maroon]", "[darkred]", "[darkgreen]", "[yellow1]", "[blue1]", "[fuchsia]",
        "[dodgerblue2]", "[deeppink4_2]", "[hotpink3]", "[red3]", "[lightsteelblue]", "[darkseagreen2]", "[darkkhaki]"
    };

        // Add rows to the table for the bar graph
        for (int i = 0; i < selectedValues.Count; i++)
        {
            var value = selectedValues[i];
            int barHeight = (int)(value.Value * overallScaleFactor);
            var bar = new string('█', Math.Max(barHeight, minHeight)); // Use Math.Max to ensure a minimum height

            // Apply a color code to each bar
            var coloredBar = colorCodes[i % colorCodes.Length] + bar + "[/]";

            table.AddRow(value.Name, coloredBar, value.Value.ToString("N2"));
        }

        // Render the table with the bar graph
        AnsiConsole.Write(table);

        TableofValues.DisplayTable(selectedValues); // Display only the selected dataset
    }



    private static List<TableofValues> FilterTableByDatasetNumber(List<TableofValues> tableValues, int datasetNumber)
    {
        return tableValues.Where(tv => tv.GetDatasetNumberForName(tv.Name) == datasetNumber).ToList();
    }

    private static List<TableofValues> FilterTableByDatasetNumbers(List<TableofValues> tableValues, List<int> datasetNumbers)
    {
        return tableValues.Where(tv => datasetNumbers.Contains(tv.GetDatasetNumberForName(tv.Name))).ToList();
    }

}

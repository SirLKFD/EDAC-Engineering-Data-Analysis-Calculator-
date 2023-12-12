using System;
using System.Collections.Generic;
using System.Linq;
using NAudio.Wave;
using Spectre.Console;

class DataSets
{
   
    public static void Run(List<TableofValues> tableValues, Sequencing sequencing)
    {
        try
        {
            // Find the highest existing dataset number
            int highestDatasetNumber = tableValues
                .Select(v => v.GetDatasetNumberForName(v.Name))
                .DefaultIfEmpty(0)
                .Max();

            while (true)
            {
                var numDatasets = AnsiConsole.Prompt(new TextPrompt<int>("[yellow underline]\nEnter the number of dataset tables to create[/] [italic white]enter 0 to go back:[/]"));
                Music.PlaySelectSound();

                if (numDatasets == 0)
                {
                    Music.PlaySelectSound();
                    break; // Go back to the main menu
                }
                else if (numDatasets < 0) 
                {
                    Music.PlayErrorSound();
                    AnsiConsole.Write(new Markup("[red]Negative values are not allowed.[/]\n"));
                    continue; // Ask the user to reinput
                }

                AnsiConsole.Write(new Markup($"\n[bold white on navyblue]Creating {numDatasets} dataset(s)[/]\n"));

                for (int datasetIndex = highestDatasetNumber + 1; datasetIndex <= highestDatasetNumber + numDatasets; datasetIndex++)
                {
                    AnsiConsole.Write(new Markup($"\nCREATING [bold yellow]DATASET {datasetIndex}:[/]\n\n"));

                    Numbers dataCollector = new Numbers();
                    dataCollector.CollectData();

                    double[] numbers = dataCollector.GetNumbers();
                    string[] dataTypes = dataCollector.GetDataTypes();

                    string unit = null;

                    var userIncludeUnits = AnsiConsole.Prompt(new SelectionPrompt<string>()
                        .Title("\nDo you want to include units for the data?")
                        .AddChoices(new[] { "Yes", "No" })
                        .HighlightStyle(new Style().Foreground(Color.Green)));

                    if (userIncludeUnits == "Yes")
                    {
                        Music.PlaySelectSound();
                        unit = AnsiConsole.Prompt(new TextPrompt<string>("Please enter the unit measurement [bold springgreen1](money, measurement, etc.):[/]"));
                    }
                    else if (userIncludeUnits == "No")
                    {
                        Music.PlaySelectSound();
                        unit = "N/A";
                    }
              
                    var userInterpretation = AnsiConsole.Prompt(new TextPrompt<string>("Please enter your [bold cyan1 underline]type of data[/] for the entire dataset:"));

                    // Check if the user entered 'No' for no interpretation
                    if (userInterpretation.ToUpper() == "N")
                    {
                        userInterpretation = "N/A";
                    }

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        double number = numbers[i];
                        string dataType = dataTypes[i];

                        int dataTypeCount = sequencing.GetNextCount(dataType);
                        TableofValues dataTypeValue = new TableofValues(tableValues.Count, $"{datasetIndex}: {dataType}", number, "", unit, userInterpretation);
                        tableValues.Add(dataTypeValue);
                    }

                    Music.PlaySuccessSound();

                    AnsiConsole.Write(new Markup($"\n[chartreuse2 bold]Type of data applied to DATASET {datasetIndex} successfully![/]\n"));
                    //Console.WriteLine($"\nType of data applied to DATASET {datasetIndex} successfully!");
                }

                // Update the highest dataset number for the next iteration
                highestDatasetNumber += numDatasets;
            }
        }
        catch (Exception ex)
        {
            Music.PlayErrorSound();
            Console.WriteLine($"An error occurred: {ex.Message}");
     
        }
    }
}

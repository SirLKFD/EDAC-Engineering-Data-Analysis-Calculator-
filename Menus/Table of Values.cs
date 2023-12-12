using System;
using System.Collections.Generic;
using ConsoleTables;
using Spectre.Console;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using NAudio.Wave;

 class TableofValues 
{

    private List<TableofValues> tableValues = new List<TableofValues>();
    private static string DataPath_Table = "Table of Values Data.csv";
    private static string defaultFolderPath = @"C:\Users\LKFD\Desktop\LORDKENT\College - 2nd Year\Assignments\Object Oriented Programming 1\Project CPE, Engineering Data Analysis Calculator\Engineering Data Analysis Calculator\Database"; // REMEMBER TO REPLACE THIS Set your default folder path here

    public int ID { get; set; }
    public string Name { get; set; }
    public double Value { get; set; }
    public string Condition { get; set; }
    public string Unit { get; set; }
    public string Interpretation { get; set; }
    public TableofValues(int id, string name, double value, string condition, string unit, string userInterpretation)
    {
        ID = id;
        Name = name;
        Value = value;
        Condition = condition;
        Interpretation = userInterpretation;
        Unit = unit;
    }

    public override string ToString()
    {
        return $"{ID,2} {Name,-35} {Condition,-20} {Value:F2,15} {Unit,-20} {Interpretation,-40}";
    }

    public static string DefaultFolderPath
    {
        get { return defaultFolderPath; }
        set { defaultFolderPath = value; }
    }

    public int GetDatasetNumberForName(string name)
    {
        return GetDatasetNumber(name);
    }

    public static string GetDataFilePath()
    {
        return Path.Combine(defaultFolderPath, DataPath_Table);
    }

   // DisplayTable 

    public static void DisplayTable(List<TableofValues> tableValues)
    {
        try
        {
            var groupedByDataset = tableValues.GroupBy(v => GetDatasetNumber(v.Name));

            foreach (var datasetGroup in groupedByDataset)
            {
                var table = new Table();
                table.AddColumns("[yellow]ID[/]", $"[yellow]{datasetGroup.First().Interpretation}[/]", "[yellow]Value[/]", "[yellow]Unit[/]");
                table.Border = TableBorder.DoubleEdge;
                table.BorderColor(Color.Blue);


                AnsiConsole.Write(new Markup($"[underline rapidblink yellow1]DATASET {datasetGroup.Key}[/]").Centered());

                foreach (var value in datasetGroup)
                {
                    string[] nameParts = value.Name.Split('#');
                    string dataType = nameParts.Length > 0 ? nameParts[0].Trim() : "N/A"; // Extract type of data

                    // Modify this line to remove the dataset number from the display
                    table.AddRow(value.ID.ToString(), dataType, value.Value.ToString("F2"), value.Unit);
                }

                AnsiConsole.Render(table.Centered());
            }
        }
        catch (Exception ex)
        {
            AnsiConsole.Write(new Markup($"[bold red]An error occurred while displaying the table: {ex.Message}[/]"));
           // Console.WriteLine($"An error occurred while displaying the table: {ex.Message}");
        }
    }

    private static int GetDatasetNumber(string name)
    {
        string[] nameParts = name.Split(':');
        if (nameParts.Length > 1 && int.TryParse(nameParts[0].Trim(), out int datasetNumber))
        {
            return datasetNumber;
        }
        return 0; // Default dataset number if not found
    }


    public static void ManageTable(List<TableofValues> tableValues, Sequencing sequencing)
    {
        try
        {
            Console.Clear();
            DisplayTable(tableValues);

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Options:")
                    .PageSize(6)
                    .AddChoices(new[]
                        {
                            "Edit Value",
                            "Edit Unit",
                            "Edit Name of Data",
                            "Edit Type of Data",
                            "Delete Dataset",
                            "Delete Type of Data",
                            "Save Data",
                            "Search",
                            "Statistic Calculation",
                            "Data Analysis",
                            "Go Back",
                        })

                    .HighlightStyle(new Style().Foreground(Color.Green))
                    .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")

                    );

            Music.PlaySelectSound();

            switch (selection)
            {
                // Edit Value
                case "Edit Value":
                    Music.PlaySelectSound();
                    int editId = -1;

                    while (editId < 0 || editId >= tableValues.Count)
                    {
                        AnsiConsole.Write(new Markup("[bold yellow]Enter ID to edit: [/]"));
                        if (!int.TryParse(Console.ReadLine(), out editId) || editId < 0 || editId >= tableValues.Count)
                        {
                            Music.PlayErrorSound();
                            AnsiConsole.Write(new Markup("[bold red]Invalid ID. Please enter a valid ID.\n[/]"));
                        }
                    }

                    TableofValues editedValue = tableValues[editId];
                    double newValue;

                    while (true)
                    {
                        Music.PlaySelectSound();
                        AnsiConsole.Write(new Markup("[bold yellow]Enter new value: [/]"));
                        string userInput = Console.ReadLine();

                        if (!double.TryParse(userInput, out newValue) || newValue < 0)
                        {
                            Music.PlayErrorSound();
                            AnsiConsole.Write(new Markup("[bold red]Invalid input. Please enter a valid positive number for the new value.\n[/]"));
                        }
                        else
                        {
                            editedValue.Value = newValue;

                            // Update the edited value in the list
                            tableValues[editId] = editedValue;
                            Music.PlaySuccessSound();
                            AnsiConsole.Write(new Markup("[bold green]Value edited successfully!\n[/]"));
                            break;
                        }
                    }
                    break;



                case "Edit Name of Data":
                    // Edit Contents of the 2nd Row
                    Music.PlaySelectSound();
                    AnsiConsole.Write(new Markup("[bold yellow]Enter ID to edit name of data: [/]"));
                    int editId2 = Convert.ToInt32(Console.ReadLine());
                    if (editId2 >= 0 && editId2 < tableValues.Count)
                    {
                        TableofValues editedValue2 = tableValues[editId2];

                        // Assuming that the 2nd row corresponds to the 'Name' property
                        Music.PlaySelectSound();
                        AnsiConsole.Write(new Markup("[bold yellow]Enter new name of data: [/]"));
                        string newContents = Console.ReadLine();

                        // Save the original dataset number
                        int originalDatasetNumber = GetDatasetNumber(editedValue2.Name);

                        // Update the contents directly without creating a new dataset
                        editedValue2.Name = $"{originalDatasetNumber}:{newContents}";

                        // Update the edited contents in the list
                        tableValues[editId2] = editedValue2;

                        Music.PlaySuccessSound();
                        AnsiConsole.Write(new Markup("[bold green]Name of data edited successfully!\n[/]"));
                    }
                    else
                    {
                        Music.PlayErrorSound();
                        AnsiConsole.Write(new Markup("[bold red]Invalid ID. Please enter a valid ID.\n[/]"));
                    }
                    break;

                case "Edit Type of Data":
                    // Edit Type of Data
                    Music.PlaySelectSound();
                    AnsiConsole.Write(new Markup("[bold yellow]Enter the dataset number to edit type of data: [/]"));
                    int editDatasetNumber = Convert.ToInt32(Console.ReadLine());

                    var datasetToEdit = tableValues.FirstOrDefault(v => GetDatasetNumber(v.Name) == editDatasetNumber);

                    if (datasetToEdit != null)
                    {
                        Music.PlaySelectSound();
                        AnsiConsole.Write(new Markup("[bold yellow]Enter new type of data: [/]"));
                        string newInterpretation = Console.ReadLine();

                        // Update the interpretation for all entries in the dataset
                        foreach (var value in tableValues.Where(v => GetDatasetNumber(v.Name) == editDatasetNumber))
                        {
                            value.Interpretation = newInterpretation;
                        }
                        Music.PlaySuccessSound();
                        AnsiConsole.Write(new Markup($"[bold green]Type of data for DATASET {editDatasetNumber} edited successfully!\n[/]"));
                    }
                    else
                    {
                        Music.PlayErrorSound();
                        AnsiConsole.Write(new Markup($"[bold red]Dataset {editDatasetNumber} not found. Type of Data not edited.\n[/]"));
                    }
                    break;

                case "Edit Unit":
                    // Edit Unit
                    Music.PlaySelectSound();
                    AnsiConsole.Write(new Markup("[bold yellow]Enter ID to edit unit: [/]"));
                    int editId3 = Convert.ToInt32(Console.ReadLine());
                    if (editId3 >= 0 && editId3 < tableValues.Count)
                    {
                        TableofValues editedValue3 = tableValues[editId3];
                        Music.PlaySelectSound();
                        AnsiConsole.Write(new Markup("[bold yellow]Enter new unit: [/]"));
                        string newUnit = Console.ReadLine();
                        editedValue3.Unit = newUnit;

                        // Update the edited unit in the list
                        tableValues[editId3] = editedValue3;
                        Music.PlaySuccessSound();
                        AnsiConsole.Write(new Markup("[bold green]Unit edited successfully!\n[/]"));
                    }
                    else
                    {
                        Music.PlayErrorSound();
                        AnsiConsole.Write(new Markup("[bold red]Invalid ID. Unit not edited.\n[/]"));
                    }
                    break;


                case "Delete Type of Data":
                    // Delete Value
                    Music.PlaySelectSound();
                    AnsiConsole.Write(new Markup("[bold yellow]Enter ID to delete: [/]"));
                    int deleteId = Convert.ToInt32(Console.ReadLine());
                    if (deleteId >= 0 && deleteId < tableValues.Count)
                    {
                        AnsiConsole.Write(new Markup($"[bold yellow]Are you sure you want to delete the type of data with ID {deleteId}?[/][bold white] (y/n): [/]"));
                        Music.PlaySelectSound();
                        string confirmation = Console.ReadLine().ToLower();
                        if (confirmation == "yes" || confirmation == "y")
                        {
                            string deletedStatType = tableValues[deleteId].Name.Split(' ')[0];

                            // Adjust the count in the Sequencing class
                            sequencing.AdjustCount(deletedStatType, deleteId);

                            tableValues.RemoveAt(deleteId);

                            // Update IDs for remaining items
                            int newId = 0;
                            foreach (var item in tableValues.OrderBy(v => v.ID))
                            {
                                item.ID = newId++;
                            }

                            Music.PlaySuccessSound();
                            AnsiConsole.Write(new Markup("[bold green]Value deleted successfully!\n[/]"));
                        }
                        else
                        {
                            Music.PlayCancelSound();
                            Console.WriteLine("Deletion canceled.");
                        }
                    }
                    else
                    {
                        Music.PlayErrorSound();
                        AnsiConsole.Write(new Markup("[bold red]Invalid ID. Value not deleted.\n[/]"));
                    }
                    break;

                case "Delete Dataset":
                    try
                    {
                        Music.PlaySelectSound();
                        AnsiConsole.Write(new Markup("[bold yellow]Enter the dataset number to delete: [/]"));
                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out int deleteDatasetNumber) || deleteDatasetNumber < 0)
                        {
                            throw new FormatException();
                        }

                        AnsiConsole.Write(new Markup($"[bold yellow]Are you sure you want to delete all values in dataset {deleteDatasetNumber}?[/][bold white] (y/n): [/]"));
                        Music.PlaySelectSound();
                        string confirmation = Console.ReadLine().ToLower();

                        if (confirmation == "yes" || confirmation == "y")
                        {
                            // Get the IDs of the items in the dataset to be deleted
                            var idsToDelete = tableValues.Where(v => GetDatasetNumber(v.Name) == deleteDatasetNumber).Select(v => v.ID).ToList();

                            // Remove all entries with the specified dataset number
                            tableValues.RemoveAll(v => GetDatasetNumber(v.Name) == deleteDatasetNumber);

                            // Update IDs for remaining items
                            int newId = 0;
                            foreach (var item in tableValues.OrderBy(v => v.ID))
                            {
                                item.ID = newId++;
                            }

                            // Update dataset numbers for remaining items
                            foreach (var item in tableValues)
                            {
                                int currentDatasetNumber = GetDatasetNumber(item.Name);
                                if (currentDatasetNumber > deleteDatasetNumber)
                                {
                                    item.Name = $"{currentDatasetNumber - 1}:{item.Name.Split(':')[1]}";
                                }
                            }

                            Music.PlaySuccessSound();
                            AnsiConsole.Write(new Markup($"[bold green]Dataset {deleteDatasetNumber} deleted successfully![/]\n"));
                        }
                        else
                        {
                            Music.PlayCancelSound();
                            Console.WriteLine("Deletion canceled.");
                        }
                    }
                    catch (FormatException)
                    {
                        Music.PlayErrorSound();
                        AnsiConsole.Write(new Markup("[bold red]Invalid input. Please enter a valid non-negative dataset number.\n[/]"));
                    }
                    catch (Exception ex)
                    {
                        Music.PlayErrorSound();
                        AnsiConsole.Write(new Markup($"[bold red]An error occurred while deleting the dataset: {ex.Message}\n[/]"));
                    }
                    break;



                case "Save Data":
                    Music.PlaySuccessSound();
                    SaveTableData(tableValues, DataPath_Table);
                    AnsiConsole.Write(new Markup($"[bold green]Table of Values Data saved successfully![/]\n"));
                    break;

                case "Search":
                    do
                    {
                        try
                        {
                            Music.PlaySelectSound();
                            Console.Clear();
                            AnsiConsole.Write(new Markup("[bold yellow]Enter the name of data to search for: [/]"));
                            string searchType = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(searchType))
                            {
                                Music.PlayErrorSound();
                                AnsiConsole.Write(new Markup("[bold red]Invalid input. Please enter a valid search term.\n[/]"));
                                System.Threading.Thread.Sleep(0);
                            }
                            else
                            {
                                var searchResults = SearchByType(tableValues, searchType);

                                if (searchResults.Any())
                                {
                                    Music.PlaySuccessSound();
                                    DisplayTable(searchResults);
                                    break; // Exit the loop if matching data is found
                                }
                                else
                                {
                                    Music.PlayErrorSound();
                                    AnsiConsole.Write(new Markup("[bold red]No matching data found. Please try again.\n[/]"));
                                    System.Threading.Thread.Sleep(2000); // Introduce a delay to keep the error message visible for 2 seconds
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Music.PlayErrorSound();
                            AnsiConsole.Write(new Markup($"[bold red]An error occurred during search: {e.Message}\n[/]"));
                            System.Threading.Thread.Sleep(2000); // Introduce a delay to keep the error message visible for 2 seconds
                            break; // Exit the loop in case of an error
                        }
                    } while (true);
                    break;



                case "Statistic Calculation":
                    try
                    {
                        Console.WriteLine();
                        var optionPrompt = new SelectionPrompt<string>()
                            .Title("Choose what to calculate:")
                            .PageSize(4)
                            .AddChoices(new[] { "All Datasets", "Selected Dataset/s", "Individual IDs", "Go Back" })
                            .HighlightStyle(new Style().Foreground(Color.Green))
                            .MoreChoicesText("[grey](Move up and down to reveal more options)[/]");

                        string statOption = AnsiConsole.Prompt(optionPrompt);

                        switch (statOption)
                        {
                            case "Selected Dataset/s":
                                try
                                {
                                    Music.PlaySelectSound();
                                    AnsiConsole.Write(new Markup("[bold white]Enter dataset number/s (comma-separated): [/]"));
                                    string datasetInput = Console.ReadLine();
                                    List<int> selectedDatasets = datasetInput.Split(',').Select(int.Parse).ToList();

                                    foreach (var selectedDataset in selectedDatasets)
                                    {
                                        var valuesForDataset = FilterTableByDatasetNumber(tableValues, selectedDataset);

                                        if (valuesForDataset.Any())
                                        {
                                            Music.PlaySuccessSound();
                                            var statCalc = new StatisticCalculation(valuesForDataset);
                                            WrapResults wrapResults = new ConcreteWrapResults(
                                            statCalc.CalculateTotalSum(),
                                            statCalc.CalculateSize(),
                                            statCalc.CalculateMean(),
                                            statCalc.CalculateMedian(),
                                            statCalc.CalculateMode(),
                                            statCalc.CalculateRange(),
                                            statCalc.CalculateInterquartileRange(),
                                            statCalc.CalculateVariance(),
                                            statCalc.CalculateStandardDeviation(),
                                            statCalc.CalculateMinimum(),
                                            statCalc.CalculateMaximum(),
                                            statCalc.CalculateQuartile1(),
                                            statCalc.CalculateQuartile2(),
                                            statCalc.CalculateQuartile3(),
                                            statCalc.CalculatePercentile25(),
                                            statCalc.CalculatePercentile50(),
                                            statCalc.CalculatePercentile75(),
                                            statCalc.CalculateSkewness(),
                                            statCalc.CalculateKurtosis(),
                                            statCalc.CalculateCoefficientOfVariation()
                                            );

                                            // Display statistics for the current dataset
                                            AnsiConsole.Write(new Markup($"[underline cyan1]\nStatistics for DATASET {selectedDataset}[/]").Centered());
                                            wrapResults.DisplayStatisticalResults();
                                        }
                                        else
                                        {
                                            Music.PlayErrorSound();
                                            AnsiConsole.Write(new Markup($"[bold red]No values found for statistical calculations in DATASET {selectedDataset}.\n[/]"));
                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                    Music.PlayErrorSound();
                                    AnsiConsole.Write(new Markup($"[bold red]An error occurred during statistical calculations: {e.Message}\n[/]"));
                                }
                                break;


                            case "All Datasets":
                                Music.PlaySelectSound();
                                var allDatasetNumbers = tableValues.Select(tv => tv.GetDatasetNumberForName(tv.Name)).Distinct().ToList();

                                foreach (var datasetNumber in allDatasetNumbers)
                                {
                                    var valuesForDataset = FilterTableByDatasetNumber(tableValues, datasetNumber);
                                    if (valuesForDataset.Any())
                                    {
                                        Music.PlaySuccessSound();
                                        var statCalc = new StatisticCalculation(valuesForDataset);
                                        WrapResults wrapResults = new ConcreteWrapResults(
                                            statCalc.CalculateTotalSum(),
                                            statCalc.CalculateSize(),
                                            statCalc.CalculateMean(),
                                            statCalc.CalculateMedian(),
                                            statCalc.CalculateMode(),
                                            statCalc.CalculateRange(),
                                            statCalc.CalculateInterquartileRange(),
                                            statCalc.CalculateVariance(),
                                            statCalc.CalculateStandardDeviation(),
                                            statCalc.CalculateMinimum(),
                                            statCalc.CalculateMaximum(),
                                            statCalc.CalculateQuartile1(),
                                            statCalc.CalculateQuartile2(),
                                            statCalc.CalculateQuartile3(),
                                            statCalc.CalculatePercentile25(),
                                            statCalc.CalculatePercentile50(),
                                            statCalc.CalculatePercentile75(),
                                            statCalc.CalculateSkewness(),
                                            statCalc.CalculateKurtosis(),
                                            statCalc.CalculateCoefficientOfVariation()
                                        );

                                        // Display statistics for the current dataset number
                                        AnsiConsole.Write(new Markup($"[underline cyan1]\nStatistics for DATASET {datasetNumber}[/]").Centered());
                                        wrapResults.DisplayStatisticalResults();
                                    }
                                }
                                break;

                            case "Individual IDs":
                                Music.PlaySelectSound();
                                AnsiConsole.Write(new Markup("[bold white]Enter individual IDs (comma-separated): [/]"));
                                string idInput = Console.ReadLine();
                                List<int> selectedIds = idInput.Split(',').Select(int.Parse).ToList();
                                var selectedValues = tableValues.Where(tv => selectedIds.Contains(tv.ID)).ToList();

                                if (selectedValues.Any())
                                {
                                    Music.PlaySuccessSound();
                                    var statCalc = new StatisticCalculation(selectedValues);
                                    WrapResults wrapResults = new ConcreteWrapResults(
                                            statCalc.CalculateTotalSum(),
                                            statCalc.CalculateSize(),
                                            statCalc.CalculateMean(),
                                            statCalc.CalculateMedian(),
                                            statCalc.CalculateMode(),
                                            statCalc.CalculateRange(),
                                            statCalc.CalculateInterquartileRange(),
                                            statCalc.CalculateVariance(),
                                            statCalc.CalculateStandardDeviation(),
                                            statCalc.CalculateMinimum(),
                                            statCalc.CalculateMaximum(),
                                            statCalc.CalculateQuartile1(),
                                            statCalc.CalculateQuartile2(),
                                            statCalc.CalculateQuartile3(),
                                            statCalc.CalculatePercentile25(),
                                            statCalc.CalculatePercentile50(),
                                            statCalc.CalculatePercentile75(),
                                            statCalc.CalculateSkewness(),
                                            statCalc.CalculateKurtosis(),
                                            statCalc.CalculateCoefficientOfVariation()
                                    );

                                    AnsiConsole.Write(new Markup($"[underline cyan1]\nStatistics for DATASET[/][italic yellow] (Selected ID/s)[/]").Centered());
                                    wrapResults.DisplayStatisticalResults();
                                }
                                else
                                {
                                    Music.PlayErrorSound();
                                    AnsiConsole.Write(new Markup("[bold red]No matching data found for the provided IDs.\n[/]"));
                                }
                                break;

                            case "Go Back":
                                Music.PlaySelectSound();
                                break;

                            default:
                                Music.PlayErrorSound();
                                AnsiConsole.Write(new Markup("[bold red]Invalid option. Please select a valid option.\n[/]"));
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"An error occurred during statistical calculations: {e.Message}");
                    }
                    break;

                case "Data Analysis":
                    try
                    {
                        Music.PlaySelectSound();
                        DataAnalysis.GenerateBarGraph(tableValues);
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred during data analysis: {ex.Message}");
                    }
                    break;


                case "Go Back":
                    Music.PlaySelectSound();
                    break;

                default:
                    Music.PlayErrorSound();
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Music.PlayErrorSound();
            Console.WriteLine($"An error occurred while managing the table: {ex.Message}");
        }


    }

    public static void SaveTableData(List<TableofValues> tableValues, string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(defaultFolderPath, filename)))
            {
                foreach (var value in tableValues)
                {
                    // Format the Value property with two decimal places
                    string formattedValue = value.Value.ToString("F2");

                    // Serialize the data and write it to the file
                    writer.WriteLine($"{value.ID},{value.Name},{formattedValue},{value.Condition},{value.Unit},{value.Interpretation}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving table data: {ex.Message}");
        }
    }


    public static List<TableofValues> LoadTableData(string filename)
    {
        try
        {
            List<TableofValues> loadedTableValues = new List<TableofValues>();
            if (File.Exists(Path.Combine(defaultFolderPath, filename)))
            {
                using (StreamReader reader = new StreamReader(Path.Combine(defaultFolderPath, filename)))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 6)
                        {
                            int id = int.Parse(parts[0]);
                            string name = parts[1];
                            double value = double.Parse(parts[2]);
                            string condition = parts[3];
                            string unit = parts[4];
                            string interpretation = parts[5];
                            loadedTableValues.Add(new TableofValues(id, name, value, condition, unit, interpretation));
                        }
                    }
                }
            }
            return loadedTableValues;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading table data: {ex.Message}");
            return new List<TableofValues>();
        }
    }

    public static List<TableofValues> SearchByType(List<TableofValues> tableValues, string searchTerm)
    {
        searchTerm = searchTerm.ToLower(); // Convert to lowercase for case-insensitive search

        return tableValues
            .Where(v => v.Name.ToLower().Contains(searchTerm) ||
                        v.Interpretation.ToLower().Contains(searchTerm) ||
                        v.Value.ToString("F2").ToLower().Contains(searchTerm) ||
                        v.Unit.ToLower().Contains(searchTerm) || 
                        GetDatasetNumber(v.Name).ToString().Contains(searchTerm) ||
                        v.ID.ToString().Contains(searchTerm))
            .ToList();
    }

    private static List<TableofValues> FilterTableByDatasetNumber(List<TableofValues> tableValues, int datasetNumber)
    {
        return tableValues.Where(tv => tv.GetDatasetNumberForName(tv.Name) == datasetNumber).ToList();
    }

}

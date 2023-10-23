using System;
using System.Collections.Generic;
using ConsoleTables;

class TableofValues
{

    private static string dataFileName = "Table of Values Data.csv";
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
        return $"{ID,2} {Name,-15} {Value,10:F2} {Unit,-20} {Interpretation,-20}";
    }

    // DisplayTable method using ConsoleTables
    public static void DisplayTable(List<TableofValues> tableValues)
    {
        var table = new ConsoleTable("ID", "Statistic", "Value", "Unit", "Interpretation");
        foreach (var value in tableValues)
        {
            table.AddRow(value.ID, value.Name, value.Value, value.Unit, value.Interpretation);
        }
        table.Write(Format.MarkDown);
    }


    public static void ManageTable(List<TableofValues> tableValues, Sequencing sequencing)
    {
        Console.Clear();
        DisplayTable(tableValues);

        Console.WriteLine("Options:");
        Console.WriteLine("A. Edit Value");
        Console.WriteLine("B. Edit Interpretation");
        Console.WriteLine("C. Edit Unit");
        Console.WriteLine("D. Delete Value");
        Console.WriteLine("E. Save Data");
        Console.WriteLine("F. Load Data");
        Console.WriteLine("G. Data Analysis, (UNDER CONSTRUCTION, BUGGY! AND BAR GRAPH FOR NOW) ");
        Console.WriteLine("H. Go Back");
        Console.Write("Select an option (A/B/C/D/E/F/G/H): ");


        char tableOption = Console.ReadLine().ToUpper()[0];

        switch (tableOption)
        {
            case 'A':
                // Edit Value
                Console.Write("Enter ID to edit: ");
                int editId = Convert.ToInt32(Console.ReadLine());
                if (editId >= 0 && editId < tableValues.Count)
                {
                    TableofValues editedValue = tableValues[editId];
                    Console.Write("Enter new value: ");
                    double newValue = Convert.ToDouble(Console.ReadLine());
                    editedValue.Value = newValue;

                    // Update the edited value in the list
                    tableValues[editId] = editedValue;

                    Console.WriteLine("Value edited successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid ID. Value not edited.");
                }
                break;

            case 'B':
                // Edit Interpretation
                Console.Write("Enter ID to edit interpretation: ");
                int editId2 = Convert.ToInt32(Console.ReadLine());
                if (editId2 >= 0 && editId2 < tableValues.Count)
                {
                    TableofValues editedValue = tableValues[editId2];
                    Console.Write("Enter new interpretation: ");
                    string newInterpretation = Console.ReadLine();
                    editedValue.Interpretation = newInterpretation;

                    // Update the edited interpretation in the list
                    tableValues[editId2] = editedValue;

                    Console.WriteLine("Interpretation edited successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid ID. Interpretation not edited.");
                }
                break;

            case 'C':
                // 
                Console.Write("Enter ID to edit unit: ");
                int editId3 = Convert.ToInt32(Console.ReadLine());
                if (editId3 >= 0 && editId3 < tableValues.Count)
                {
                    TableofValues editedValue = tableValues[editId3];
                    Console.Write("Enter new unit: ");
                    string newUnit = Console.ReadLine();
                    editedValue.Unit = newUnit;

                    // Update the edited unit in the list
                    tableValues[editId3] = editedValue;

                    Console.WriteLine("Unit edited successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid ID. Unit not edited.");
                }
                break;

            case 'D':
                // Delete Value
                Console.Write("Enter ID to delete: ");
                int deleteId = Convert.ToInt32(Console.ReadLine());
                if (deleteId >= 0 && deleteId < tableValues.Count)
                {
                    string deletedStatType = tableValues[deleteId].Name.Split(' ')[0];
                    sequencing.AdjustCount(deletedStatType, deleteId);

                    tableValues.RemoveAt(deleteId);
                    Console.WriteLine("Value deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid ID. Value not deleted.");
                }
                break;

            case 'E':
                SaveTableData(tableValues, dataFileName);
                Console.WriteLine("Data saved successfully!");
                break;

            case 'F':
                // Load Data
                tableValues = LoadTableData(dataFileName);
                Console.WriteLine("Data loaded successfully!");
                break;

            case 'G':
                DataAnalysis.GenerateBarGraph(tableValues);
                Console.ReadKey();
                break;

            case 'H':
                // Go back to the previous menu
                break;

            default:
                Console.WriteLine("Invalid option. Please select a valid option.");
                break;
        }

    }

    public static void SaveTableData(List<TableofValues> tableValues, string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var value in tableValues)
            {
                // Serialize the data and write it to the file
                writer.WriteLine($"{value.ID},{value.Name},{value.Value},{value.Condition},{value.Unit},{value.Interpretation}");
            }
        }
    }

    public static List<TableofValues> LoadTableData(string filename)
    {
        List<TableofValues> loadedTableValues = new List<TableofValues>();
        if (File.Exists(filename))
        {
            using (StreamReader reader = new StreamReader(filename))
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
}




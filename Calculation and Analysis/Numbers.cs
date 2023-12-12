using Spectre.Console;
using System;

class Numbers
{
    protected double[] numbers;
    protected string[] dataTypes;
    protected int count;

    public Numbers()
    {
        numbers = new double[0];
        dataTypes = new string[0];
        count = 1;
    }

    public virtual void CollectData()
    {
        AnsiConsole.Write(new Markup($"Enter dataset and type [bold green1] 'DONE' [/] if you are done.\n"));

        while (true)
        {
            AnsiConsole.Write(new Markup($"Enter number [bold yellow1]#{count}: [/]"));

            try
            {
                string input = Console.ReadLine();

                if (input.ToUpper() == "DONE")
                {
                    if (numbers.Length == 0)
                    {
                        Music.PlayErrorSound();
                        Console.WriteLine("No numbers entered.");
                    }
                    break;
                }
                else
                {
                    if (double.TryParse(input, out double number))
                    {
                        if (number < 0)
                        {
                            AnsiConsole.Write(new Markup("[bold red]Negative numbers are not allowed.[/]\n"));
                            Music.PlayErrorSound();
                            continue; // Ask the user to re-enter the number
                        }

                        Array.Resize(ref numbers, numbers.Length + 1);
                        numbers[numbers.Length - 1] = number;

                        Music.PlaySelectSound();

                        AnsiConsole.Write(new Markup($"What [bold cyan1 underline]name of data[/] is this for number [bold cyan1]#{count}: [/]"));
                        string dataType = Console.ReadLine();
                        Array.Resize(ref dataTypes, dataTypes.Length + 1);
                        dataTypes[dataTypes.Length - 1] = dataType;

                        count++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number or type 'DONE'.");
                        Music.PlayErrorSound();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Music.PlayErrorSound();
            }
        }
    }

    public double[] GetNumbers()
    {
        return numbers;
    }

    public string[] GetDataTypes()
    {
        return dataTypes;
    }
}

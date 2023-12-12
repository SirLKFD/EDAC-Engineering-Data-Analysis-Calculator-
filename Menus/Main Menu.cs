using System;
using System.Collections.Generic;
using System.Threading;
using Spectre.Console;
using NAudio.Wave;
public class MainMenu : Info
{
    private static List<TableofValues> tableValues;
    private static Sequencing sequencing;

    public MainMenu(string name, string id, string yearOfBirth, string monthOfBirth, string dayOfBirth) : base(name, id, yearOfBirth, monthOfBirth, dayOfBirth)
    {
    }

    public static void Run()
    {
        try
        {

            string dataFileName = "Table of Values Data.csv"; // You can change the file name and extension

            // Load the table data when the program starts
            List<TableofValues> tableValues = TableofValues.LoadTableData(dataFileName);

            // Create the sequencing object
            Sequencing sequencing = new Sequencing(); // Modify this as needed

            // Attach an event handler to capture when the user closes the console window
            Console.CancelKeyPress += (sender, e) =>
            {
                // Save the table data before exiting the program
                TableofValues.SaveTableData(tableValues, dataFileName);
            };

            Console.Clear();

            Registration registration = new Registration();
            Info info = registration.LoginOrRegister();

            while (true)
            {
                Console.Clear();

                var rule1 = new Rule("[rapidblink bold yellow1]+-x÷[/]");
                rule1.Style = Style.Parse("blue");
                rule1.Justification = Justify.Left;
                AnsiConsole.Write(rule1);


                var rule3 = new Rule("[rapidblink italic bold skyblue1]E[/][rapidblink italic bold yellow1]   -[/][rapidblink italic bold honeydew2]   D[/][rapidblink italic bold yellow1]   -[/][rapidblink italic bold magenta3_2]   A[/][rapidblink italic bold yellow1]   -[/][rapidblink italic bold palevioletred1]   C[/]");
                rule3.Style = Style.Parse("springgreen2");
                rule3.Justification = Justify.Center;
                AnsiConsole.Write(rule3);


                var rule2 = new Rule("[rapidblink bold yellow1]+-x÷[/]");
                rule2.Style = Style.Parse("red");
                rule2.Justification = Justify.Right;
                AnsiConsole.Write(rule2);



                AnsiConsole.Write(new Markup($"\nWelcome [yellow]{info.GetName()}[/]\n"));
                AnsiConsole.Write(new Markup($"Account ID: [yellow]{info.GetStudentID()}[/]\n\n"));


                var choices = new List<(string Label, Action Action)>
                {
                    ("Enter Datasets", () => DataSets.Run(tableValues, sequencing)),                                      
                    ("Table of Values", () => {
                        Console.Clear();
                        TableofValues.DisplayTable(tableValues);
                        TableofValues.ManageTable(tableValues, sequencing);
                    }),
                    ("About Me", () => AboutMe.View(info)),
                    ("Logout", () => {
                        Music.PlayCancelSound();
                        TableofValues.SaveTableData(tableValues, dataFileName);
                        registration = new Registration();
                        info = registration.LoginOrRegister();


                    }),
                    ("Exit", () => Environment.Exit(0))
                };
         
                var selection = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select an option:")
                        .PageSize(5)
                        .MoreChoicesText("[red](Move up and down to reveal more options)[/]")
                        .AddChoices(choices.ConvertAll(choice => choice.Label)));
                         Music.PlaySelectSound();


                var selectedChoice = choices.Find(choice => choice.Label == selection);
                selectedChoice.Action.Invoke();

                Console.WriteLine("Press any key to continue...");
             

                Console.ReadKey();

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in the main menu: {ex.Message}");
        }

       
    }
}

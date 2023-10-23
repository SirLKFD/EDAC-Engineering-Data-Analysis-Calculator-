using System;
using System.Threading;

public class MainMenu
{
    private static List<TableofValues> tableValues;
    private static Sequencing sequencing;

    public static void Run()
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
        StudentInfo student = registration.LoginOrRegister();

        while (true)
        {
            Console.Clear();

            string welcome = $"Engineering Data Analysis Calculator\nPRE-ALPHA BUILD v0.0.1\nWelcome {student.GetName()} \nAccount ID: {student.GetStudentID()}";
            foreach (char c2 in welcome)
            {
                Console.Write(c2);
                Thread.Sleep(10);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1. Descriptive Statistics");
            Console.WriteLine("2. Inferential Statistics");
            Console.WriteLine("3. Statistical Tables (UNDER CONSTRUCTION)");
            Console.WriteLine("4. My Account");
            Console.WriteLine("5. Logout");
            Console.WriteLine("6. Exit");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine();
            Console.Write("Please select an option (1-6): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Descriptive Statistics Menu
                    DescriptiveStatisticsMenu.Run(tableValues, sequencing);
                    break;
                case "2":
                    // Inferential Statistics Menu
                    InferentialStatisticsMenu.Run(tableValues, sequencing);
                    break;
                case "3":
                    // Statistcal Tables Menu           
                    break;
                case "4":
                    // View Account Info
                    UserInfo.View(student);
                    break;
                case "5":
                    // Log out
                    TableofValues.SaveTableData(tableValues, dataFileName); 
                    registration = new Registration(); 
                    student = registration.LoginOrRegister();
                    break;
                case "6":
                    // Save the table data and exit the program
                    TableofValues.SaveTableData(tableValues, dataFileName);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

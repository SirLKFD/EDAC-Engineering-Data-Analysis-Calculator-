using System;
using System.IO;
using System.Collections.Generic;
using Spectre.Console;
using NAudio.Wave;

class Registration
{
    private static string DataPath_Account = "Accounts.csv";
    private static string defaultFolderPath = @"C:\Users\LKFD\Desktop\LORDKENT\College - 2nd Year\Assignments\Object Oriented Programming 1\Project CPE, Engineering Data Analysis Calculator\Engineering Data Analysis Calculator\Database"; // Set your default folder path here
    // WHEN BORROWING A LAPTOP FOR PRESENTATION, DONT FORGET TO CHANGE THIS FILE PATH!!!

    public static string DefaultFolderPath
    {
        get { return defaultFolderPath; }
        set { defaultFolderPath = value; }
    }

    public static string GetDataFilePath()
    {
        return Path.Combine(defaultFolderPath, DataPath_Account);
    }


private static readonly Dictionary<string, string> MonthNameToNumber = new Dictionary<string, string>
    {
        { "January", "01" },
        { "February", "02" },
        { "March", "03" },
        { "April", "04" },
        { "May", "05" },
        { "June", "06" },
        { "July", "07" },
        { "August", "08" },
        { "September", "09" },
        { "October", "10" },
        { "November", "11" },
        { "December", "12" }
    };

    private string ConvertMonthNumberToName(string monthNumber)
    {
        foreach (var kvp in MonthNameToNumber)
        {
            if (kvp.Value == monthNumber)
            {
                return kvp.Key;
            }
        }
        return "Unknown"; // Handle the case where the number doesn't match any month.
    }

    public MainMenu LoginOrRegister()
    {
        while (true)
        {
            try
            {
                Console.Clear();
                Music.PlaySuccessSound();

                var rule1 = new Rule("[rapidblink bold yellow1]+-x÷[/]");
                rule1.Style = Style.Parse("red");
                rule1.Justification = Justify.Left;
                AnsiConsole.Write(rule1);


                var rule3 = new Rule("[rapidblink italic bold skyblue1]E[/][rapidblink italic bold yellow1]   -[/][rapidblink italic bold honeydew2]   D[/][rapidblink italic bold yellow1]   -[/][rapidblink italic bold magenta3_2]   A[/][rapidblink italic bold yellow1]   -[/][rapidblink italic bold palevioletred1]   C[/]");
                rule3.Style = Style.Parse("springgreen2");
                rule3.Justification = Justify.Center;
                AnsiConsole.Write(rule3);


                var rule2 = new Rule("[rapidblink bold yellow1]+-x÷[/]");
                rule2.Style = Style.Parse("blue");
                rule2.Justification = Justify.Right;
                AnsiConsole.Write(rule2);


                Console.WriteLine();
            
                var choice = AnsiConsole.Prompt(

          new SelectionPrompt<string>()
              .PageSize(3)
              .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
              .AddChoices(new[] { "Login", "Register", "Exit" }));

                Music.PlaySelectSound();



                switch (choice)
                {
                    case "Login":
                        string loginUsername = AnsiConsole.Ask<string>("[yellow]Enter your username:[/]");
                        Music.PlaySelectSound();
                        string loginPassword = AnsiConsole.Prompt(
                            new TextPrompt<string>("[yellow]Enter password:[/]")
                                .Secret());

                        var loggedInStudent = IsLoginValid(loginUsername, loginPassword);
                        if (loggedInStudent != null)
                        {
                            AnsiConsole.Markup("[green]Login successful. Press any key to continue.[/] ");
                            Music.PlayLoginSound();
                            Console.ReadKey();


                            return loggedInStudent;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid username or password. Press any key to re-enter.", Console.ForegroundColor);
                            Music.PlayErrorSound();
                            Console.ReadKey();
                        }
                        break;

                    case "Register":
                        string name;
                        string newUsername;
                        string month;
                        string day;
                        string year;
                        string newPassword;
                        string confirmPassword;

                        bool isRegistrationComplete = false;

                        while (!isRegistrationComplete)
                        {
                            Console.Write("Please enter your name: ");
                            Music.PlaySelectSound();
                            name = Console.ReadLine();
                            Console.Write("Enter your preferred username: ");
                            Music.PlaySelectSound();
                            newUsername = Console.ReadLine();

                            if (IsUsernameTaken(newUsername))
                            {
                                Console.WriteLine("Username already taken. Please re-enter.");
                                Music.PlayErrorSound();
                                continue;
                            }

                            Console.Write("Enter your month of birth (e.g., January): ");
                            Music.PlaySelectSound();
                            string monthName = Console.ReadLine();

                            if (MonthNameToNumber.TryGetValue(monthName, out month))
                            {
                                Console.Write("Enter your day of birth (dd): ");
                                Music.PlaySelectSound();
                                day = Console.ReadLine();

                                Console.Write("Enter your year of birth (yyyy): ");
                                Music.PlaySelectSound();
                                year = Console.ReadLine();

                                Console.Write("Create a password: ");
                                Music.PlaySelectSound();
                                newPassword = GetHiddenPassword();
                                Console.Write("Re-enter your password for verification: ");
                                Music.PlaySelectSound();
                                confirmPassword = GetHiddenPassword();

                                if (newPassword != confirmPassword)
                                {
                                    Console.WriteLine("Passwords do not match. Please re-enter.");
                                    Music.PlayErrorSound();
                                    continue;
                                }

                                string studentID = $"{year} - {GenerateRandomStudentID()}";

                                // Save the new student data (including name, year, month, day, and student ID)
                                string newStudentData = $"{newUsername}|{newPassword}|{name}|{year}|{ConvertMonthNumberToName(month)}|{day}|{studentID}\n";
                                File.AppendAllText(Registration.GetDataFilePath(), newStudentData);

                                var newStudent = new MainMenu(name, studentID, year, ConvertMonthNumberToName(month), day);
                                AboutMe.View(newStudent);

                                Console.WriteLine("Account created successfully. Press any key to continue.");
                                Music.PlaySuccessSound();
                                Console.ReadKey();
                                isRegistrationComplete = true;

                                string newFilePath = Registration.GetDataFilePath();
                                File.Move(DataPath_Account, newFilePath);
                                DataPath_Account = newFilePath;

                                // Convert the numeric month to its name
                                newStudent.SetMonthOfBirth(ConvertMonthNumberToName(month));
                                return newStudent;
                            }
                            else
                            {
                                Console.WriteLine("Invalid month name. Please re-enter the month using the full name (e.g., January).");
                                Music.PlayErrorSound();
                                continue;
                            }
                        }
                        break;

                    case "Exit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Press any key to re-enter.");
                        Music.PlayErrorSound();
                        Console.ReadKey();
                        break;
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Error: Unauthorized Access - {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: File Not Found - {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error: Input/Output Exception - {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }


    private string GetHiddenPassword()
    {
        try
        {
            string password = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                if (char.IsControl(key.KeyChar))
                {
                    if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while getting the password: {ex.Message}");
            throw; // Re-throw the exception to propagate it up the call stack
        }
    }

    private bool IsUsernameTaken(string username)
    {
        try
        {
            if (File.Exists(DataPath_Account))
            {
                string[] lines = File.ReadAllLines(DataPath_Account);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length > 0)
                    {
                        string storedUsername = parts[0].Trim();
                        if (storedUsername == username)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while checking if the username is taken: {ex.Message}");
            throw; // Re-throw the exception to propagate it up the call stack
        }
    }

    private bool IsValidDate(string year, string month, string day)
    {
        try
        {
            int yearInt, monthInt, dayInt;

            if (!int.TryParse(year, out yearInt) || !int.TryParse(month, out monthInt) || !int.TryParse(day, out dayInt))
            {
                return false;
            }

            if (yearInt < 1900 || yearInt > DateTime.Now.Year)
            {
                return false;
            }

            if (monthInt < 1 || monthInt > 12)
            {
                return false;
            }

            if (dayInt < 1 || dayInt > DateTime.DaysInMonth(yearInt, monthInt))
            {
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while validating the date: {ex.Message}");
            throw; // Re-throw the exception to propagate it up the call stack
        }
    }

    private string GenerateRandomStudentID()
    {
        try
        {
            Random rand = new Random();
            int randomNumber = rand.Next(10000, 99999);
            return randomNumber.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while generating a random student ID: {ex.Message}");
            throw; // Re-throw the exception to propagate it up the call stack
        }
    }

    private MainMenu IsLoginValid(string username, string password)
    {
        try
        {
            if (File.Exists(Registration.GetDataFilePath()))
            {
                string[] lines = File.ReadAllLines(Registration.GetDataFilePath());
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 2)
                    {
                        string storedUsername = parts[0].Trim();
                        string storedPassword = parts[1].Trim();
                        if (string.Equals(storedUsername, username, StringComparison.OrdinalIgnoreCase) &&
                            string.Equals(storedPassword, password))
                        {
                            if (parts.Length >= 7)
                            {
                                string name = parts[2].Trim();
                                string year = parts[3].Trim();
                                string month = parts[4].Trim();
                                string day = parts[5].Trim();
                                string studentID = parts[6].Trim();
                                return new MainMenu(name, studentID, year, month, day);
                            }
                        }
                    }
                }
            }
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while checking login validity: {ex.Message}");
            return null; // Return null to indicate an error occurred
        }
    }
}


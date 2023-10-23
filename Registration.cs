using System;
using System.IO;
using System.Collections.Generic;

public class Registration
{
    private string DataPath = "Accounts.csv";

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

    public StudentInfo LoginOrRegister()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Login or Register");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.Write("Please select an option (1-3): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.Write("Enter your username: ");
                    string loginUsername = Console.ReadLine();
                    Console.Write("Enter your password: ");
                    string loginPassword = GetHiddenPassword();

                    var loggedInStudent = IsLoginValid(loginUsername, loginPassword);
                    if (loggedInStudent != null)
                    {
                        Console.WriteLine("Login successful. Press any key to continue.");
                        Console.ReadKey();
                        return loggedInStudent;
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password. Press any key to re-enter.");
                        Console.ReadKey();
                    }
                    break;

                case "2":
                    Console.Clear();
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
                        name = Console.ReadLine();
                        Console.Write("Enter your preferred username: ");
                        newUsername = Console.ReadLine();

                        if (IsUsernameTaken(newUsername))
                        {
                            Console.WriteLine("Username already taken. Please re-enter.");
                            continue;
                        }

                        Console.Write("Enter your month of birth (e.g., January): ");
                        string monthName = Console.ReadLine();

                        if (MonthNameToNumber.TryGetValue(monthName, out month))
                        {
                            Console.Write("Enter your day of birth (dd): ");
                            day = Console.ReadLine();

                            Console.Write("Enter your year of birth (yyyy): ");
                            year = Console.ReadLine();

                            Console.Write("Create a password: ");
                            newPassword = GetHiddenPassword();
                            Console.Write("Re-enter your password for verification: ");
                            confirmPassword = GetHiddenPassword();

                            if (newPassword != confirmPassword)
                            {
                                Console.WriteLine("Passwords do not match. Please re-enter.");
                                continue;
                            }

                            string studentID = $"{year} - {GenerateRandomStudentID()}";

                            // Save the new student data (including name, year, month, day, and student ID)
                            File.AppendAllText(DataPath, $"{newUsername}|{newPassword}|{name}|{year}|{ConvertMonthNumberToName(month)}|{day}|{studentID}\n");

                            var newStudent = new StudentInfo(name, studentID, year, ConvertMonthNumberToName(month), day);
                            UserInfo.View(newStudent);

                            Console.WriteLine("Account created successfully. Press any key to continue.");
                            Console.ReadKey();
                            isRegistrationComplete = true;

                            // Convert the numeric month to its name
                            newStudent.SetMonthOfBirth(ConvertMonthNumberToName(month));
                            return newStudent;
                        }
                        else
                        {
                            Console.WriteLine("Invalid month name. Please re-enter the month using the full name (e.g., January).");
                            continue;
                        }
                    }
                    break;

                case "3":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Press any key to re-enter.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private string GetHiddenPassword()
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

    private bool IsUsernameTaken(string username)
    {
        if (File.Exists(DataPath))
        {
            string[] lines = File.ReadAllLines(DataPath);
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

    private bool IsValidDate(string year, string month, string day)
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

    private string GenerateRandomStudentID()
    {
        Random rand = new Random();
        int randomNumber = rand.Next(10000, 99999);
        return randomNumber.ToString();
    }

    private StudentInfo IsLoginValid(string username, string password)
    {
        if (File.Exists(DataPath))
        {
            string[] lines = File.ReadAllLines(DataPath);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length >= 2)
                {
                    string storedUsername = parts[0].Trim();
                    string storedPassword = parts[1].Trim();
                    if (storedUsername == username && storedPassword == password)
                    {
                        if (parts.Length >= 7)
                        {
                            string name = parts[2].Trim();
                            string year = parts[3].Trim();
                            string month = parts[4].Trim();
                            string day = parts[5].Trim();
                            string studentID = parts[6].Trim();
                            return new StudentInfo(name, studentID, year, month, day);
                        }
                    }
                }
            }
        }
        return null;
    }
}


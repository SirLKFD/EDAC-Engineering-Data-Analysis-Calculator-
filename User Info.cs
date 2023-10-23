using System;
using ConsoleTables;

public class UserInfo
{
    public static void View(StudentInfo student)
    {
        Console.Clear();
        Console.WriteLine("My Account:\n");

        var table = new ConsoleTable("Property", "Information")
            .AddRow("Name", student.GetName())
            .AddRow("Account ID", student.GetStudentID())
            .AddRow("Month of Birth", student.GetMonthOfBirth())
            .AddRow("Day of Birth", student.GetDayOfBirth())
            .AddRow("Year of Birth", student.GetYearOfBirth());
            
        table.Write(Format.MarkDown);

        
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }
}

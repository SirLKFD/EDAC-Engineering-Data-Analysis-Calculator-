using System;
using CSharpMath.Atom;
using NAudio.Wave;
using SixLabors.ImageSharp.Processing;
using Spectre.Console;

public class AboutMe
{

    public static void View(Info student)
    {
        Console.Clear();
        Music.PlayAboutMeSound();

        var rule = new Rule("[yellow][bold italic underline]ABOUT ME[/][/]");
        rule.Style = Style.Parse("yellow1");
        rule.Justification = Justify.Center;
        AnsiConsole.Write(rule);

        var table = new Table()
            .BorderColor(Color.Blue)
            .AddColumn(new TableColumn("[yellow]Property[/]"))
            .AddColumn(new TableColumn("[yellow]Information[/]"))
            .AddRow("[white]Name[/]", $"[cyan2]{student.GetName()}[/]")
            .AddRow("[white]Account ID[/]", $"[cyan2]{student.GetStudentID()}[/]")
            .AddRow("[white]Month of Birth[/]", $"[cyan2]{student.GetMonthOfBirth()}[/]")
            .AddRow("[white]Day of Birth[/]", $"[cyan2]{student.GetDayOfBirth()}[/]")
            .AddRow("[white]Year of Birth[/]", $"[cyan2]{student.GetYearOfBirth()}[/]");

        // Set the table to be centered
        table.Expand();
        table.Centered();
        table.Border = TableBorder.DoubleEdge;

        AnsiConsole.Write(table);

        Console.WriteLine();

        AnsiConsole.Write(new Markup("[bold turquoise2]====================================================[/]\n"));
        AnsiConsole.Write(new Markup("[rapidblink bold yellow2]00   EDAC: ENGINEERING DATA ANALYSIS CALCULATOR   00[/]\n"));
        AnsiConsole.Write(new Markup("[bold springgreen2_1]====================================================[/]\n"));
        AnsiConsole.Write(new Markup("[white]Version[/] [bold italic yellow]1.0.0 RELEASE PREVIEW[/]\n"));
        AnsiConsole.Write(new Markup("[white]Program Created by [bold italic yellow]Lord Kent F. Dinampo[/][/]\n"));
        AnsiConsole.Write(new Markup("[white]CPE OOP 1 PROFESSOR [bold italic yellow]Engr. Julian N. Semblante[/][/]\n\n"));


        AnsiConsole.Write(new Markup("[white italic underline]Special thanks to these open-source libraries:[/]\n\n"));
        AnsiConsole.Write(new Markup("[bold yellow]ConsoleTables [white]- for automatic table adjustment[/][/]\n"));
        AnsiConsole.Write(new Markup("[bold yellow]AsciiSharp [white]- for graph calculation [/][/]\n"));
        AnsiConsole.Write(new Markup("[bold yellow]CSharpMath [white]- for extended math functions[/][/]\n"));
        AnsiConsole.Write(new Markup("[bold yellow]OxyPlot [white]- for plotting bar graph[/][/]\n"));
        AnsiConsole.Write(new Markup("[bold yellow]Spectre.Console [white]- for console key menu, text formatting, and outputting bar graph[/][/]\n"));
        AnsiConsole.Write(new Markup("[bold yellow]SixLabors [white]- for image to ASCII conversion[/][/]\n"));
        AnsiConsole.Write(new Markup("[bold yellow]NAudioWave [white]- for sound effects[/][/]\n\n"));

        var image = new CanvasImage("EDAC.png");
        image.MaxWidth(30);
        image.BilinearResampler();
        AnsiConsole.Write(image);
        Console.WriteLine();     

        var back = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .PageSize(5)
                    .AddChoices(new[]
                        {                         
                            "Go Back"
                        })

                    .HighlightStyle(new Style().Foreground(Color.Green))
                    .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")

                    );

        Music.PlaySelectSound();

        switch (back)
        {
            case "Go Back":
                // Go back to the previous menu
                break;

            default:
                Console.WriteLine("Invalid option. Please select a valid option.");
                break;

        }


        
    }
}



/*
using System;
using System.Threading;
using CSharpMath.Atom;
using NAudio.Wave;
using Spectre.Console;

public class AboutMe
{
    public static void View(Info student)
    {
        Console.Clear();
        Music.PlayIntroductionSound();
        var rule = new Rule("[yellow][bold italic underline]ABOUT ME[/][/]");
        rule.Justification = Justify.Center;
        AnsiConsole.Write(rule);

        var table = new Table()
            .BorderColor(Color.Blue)
            .AddColumn(new TableColumn("[yellow]Property[/]"))
            .AddColumn(new TableColumn("[yellow]Information[/]"))
            .AddRow("Name", $"[green]{student.GetName()}[/]")
            .AddRow("Account ID", $"[green]{student.GetStudentID()}[/]")
            .AddRow("Month of Birth", $"[green]{student.GetMonthOfBirth()}[/]")
            .AddRow("Day of Birth", $"[green]{student.GetDayOfBirth()}[/]")
            .AddRow("Year of Birth", $"[green]{student.GetYearOfBirth()}[/]");

        // Set the table to be centered
        table.Expand();
        table.Centered();
        table.Border = TableBorder.DoubleEdge;

        AnsiConsole.Write(table);

        Console.WriteLine();

        DisplayAnimatedCredits();

        var back = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .PageSize(5)
                .AddChoices(new[] { "Go Back" })
                .HighlightStyle(new Style().Foreground(Color.Green))
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]"));

        Music.PlaySelectSound();

        switch (back)
        {
            case "Go Back":
                // Go back to the previous menu
                break;

            default:
                Console.WriteLine("Invalid option. Please select a valid option.");
                break;
        }
    }

    private static void DisplayAnimatedCredits()
    {
        string[] credits = new[]
        {
            "EDAC: ENGINEERING DATA ANALYSIS CALCULATOR",
            "Version 0.8.5 BETA",
            "Program Created by Lord Kent F. Dinampo",
            "",
            "Special thanks to these open-source libraries:",
            "ConsoleTables - for automatic table adjustment",
            "AsciiSharp - for graph calculation",
            "CSharpMath - for extended math functions",
            "OxyPlot - for plotting bar graph",
            "Spectre.Console - for console key menu, text formatting, and outputting bar graph",
            "NAudioWave - for sound effects.\n"
        };

        foreach (var line in credits)
        {
            AnsiConsole.Write(new Markup($"[bold white]{line}[/]\n"));
            Thread.Sleep(500); // Adjust the sleep duration to control the speed of the animation
        }
    }
}
*/




/*
 using System;
using CSharpMath.Atom;
using NAudio.Wave;
using Spectre.Console;

public class AboutMe
{

    public static void View(Info student)
    {
        Console.Clear();
        Music.PlayIntroductionSound();

        var rule = new Rule("[yellow][bold italic underline]ABOUT ME[/][/]");
        rule.Justification = Justify.Center;
        AnsiConsole.Write(rule);

        var table = new Table()
            .BorderColor(Color.Blue)
            .AddColumn(new TableColumn("[yellow]Property[/]"))
            .AddColumn(new TableColumn("[yellow]Information[/]"))
            .AddRow("Name", $"[green]{student.GetName()}[/]")
            .AddRow("Account ID", $"[green]{student.GetStudentID()}[/]")
            .AddRow("Month of Birth", $"[green]{student.GetMonthOfBirth()}[/]")
            .AddRow("Day of Birth", $"[green]{student.GetDayOfBirth()}[/]")
            .AddRow("Year of Birth", $"[green]{student.GetYearOfBirth()}[/]");

        // Set the table to be centered
        table.Expand();
        table.Centered();
        table.Border = TableBorder.DoubleEdge;

        AnsiConsole.Write(table);

        Console.WriteLine();

       
        AnsiConsole.Write(new Markup("[bold black underline italic on yellow]EDAC: ENGINEERING DATA ANALYSIS CALCULATOR[/]\n"));
        AnsiConsole.Write(new Markup("[white]Version[/] [bold italic yellow]0.8.5 BETA[/]\n"));
        AnsiConsole.Write(new Markup("[white]Program Created by [bold italic yellow]Lord Kent F. Dinampo[/][/]\n\n"));


        AnsiConsole.Write(new Markup("[white italic underline]Special thanks to these open-source libraries:[/]\n\n"));
        AnsiConsole.Write(new Markup("[bold yellow]ConsoleTables [white]- for automatic table adjustment[/][/]\n"));
        AnsiConsole.Write(new Markup("[bold yellow]AsciiSharp [white]- for graph calculation [/][/]\n"));
        AnsiConsole.Write(new Markup("[bold yellow]CSharpMath [white]- for extended math functions[/][/]\n"));
        AnsiConsole.Write(new Markup("[bold yellow]OxyPlot [white]- for plotting bar graph[/][/]\n"));
        AnsiConsole.Write(new Markup("[bold yellow]Spectre.Console [white]- for console key menu, text formatting, and outputting bar graph[/][/]\n"));
        AnsiConsole.Write(new Markup("[bold yellow]NAudioWave [white]- for sound effects.[/][/]\n\n"));

        var back = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .PageSize(5)
                    .AddChoices(new[]
                        {                         
                            "Go Back"
                        })

                    .HighlightStyle(new Style().Foreground(Color.Green))
                    .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")

                    );

        Music.PlaySelectSound();

        switch (back)
        {
            case "Go Back":
                // Go back to the previous menu
                break;

            default:
                Console.WriteLine("Invalid option. Please select a valid option.");
                break;

        }

        
    }
}*/
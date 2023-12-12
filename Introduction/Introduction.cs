using System;
using Spectre.Console;
using System.Drawing;
using System.Text;
using Emgu.CV;
using Mat = Emgu.CV.Mat;
using VideoCapture = Emgu.CV.VideoCapture;
using SixLabors.ImageSharp.Processing;


class Introduction
{
    public static void DisplayLoading()
    {
        // Synchronous
        AnsiConsole.Status()
            .Start("Configuring Libraries", ctx =>
            {
                // Simulate some work            
               AnsiConsole.MarkupLine("Starting EDAC");
                Thread.Sleep(1000);

                // Update the status and spinner
                ctx.Status("Starting Program");
                ctx.Spinner(Spinner.Known.Line);
                ctx.SpinnerStyle(Style.Parse("green"));

                // Simulate some work
                AnsiConsole.MarkupLine("Libraries successfully configured");
                Thread.Sleep(1000);
            });

        Console.Clear();
    }

    public static void DisplayWelcomeIntro()
    {

        DisplayAnimatedIntro2();
        DisplayAnimatedIntro3();

        DisplayAnimatedIntro4();

        DisplayAnimatedIntro4();


        Console.WriteLine();

        Music.PlayIntroductionSound();


        string[] intros = {
        "EDAC: ENGINEERING DATA ANALYSIS CALCULATOR",
          };

        int maxIntroLength = intros.Max(s => s.Length);
        int boxWidth = maxIntroLength + 10;
        int leftMargin = (Console.WindowWidth - boxWidth) / 2;
        string topBorder = new string('=', boxWidth);
        Console.SetCursorPosition(leftMargin, Console.CursorTop);
        AnsiConsole.Write(new Markup($"[bold turquoise2]{topBorder}\n[/]"));

        foreach (string intro in intros)
        {
            Console.SetCursorPosition(leftMargin, Console.CursorTop + 1);
            AnsiConsole.Write(new Markup($"[bold rapidblink yellow1]00[/]"));

            int introLeftMargin = (boxWidth - intro.Length) / 2;
            Console.SetCursorPosition(leftMargin + introLeftMargin, Console.CursorTop);
            foreach (char c in intro)
            {
                AnsiConsole.Write(new Markup($"[rapidblink underline bold orange3]{c}[/]"));
                Thread.Sleep(25);
            }

            Console.SetCursorPosition(leftMargin + boxWidth - 2, Console.CursorTop);
            AnsiConsole.Write(new Markup($"[bold rapidblink yellow1]00[/]"));

            Console.WriteLine();
            Console.WriteLine();
        }

        Console.SetCursorPosition(leftMargin, Console.CursorTop);
        AnsiConsole.Write(new Markup($"[bold springgreen2_1]{topBorder}\n[/]"));

        Console.WriteLine();

        var rule = new Rule("[rapidblink bold yellow1]  +-x÷ [/]");
        rule.Style = Style.Parse("springgreen2");
        rule.Justification = Justify.Center;
        AnsiConsole.Write(rule);

        DisplayAnimatedIntro();

        var rule3 = new Rule("[rapidblink bold yellow1]  +-x÷ [/]");
        rule3.Style = Style.Parse("springgreen2");
        rule3.Justification = Justify.Center;
        AnsiConsole.Write(rule3);

        Console.WriteLine();
        var rule4 = new Rule("[bold greenyellow]Created by Lord Kent F. Dinampo[/]");
        rule4.Style = Style.Parse("indianred1_1");
        rule4.Justification = Justify.Center;
        AnsiConsole.Write(rule4);

        var rule2 = new Rule("[bold rapidblink darkslategray3]Press any key to continue...[/]");
        rule2.Style = Style.Parse("indianred1_1");
        rule2.Justification = Justify.Center;
        AnsiConsole.Write(rule2);


    
        /*string intro4 = "Press any key to continue...";


        int leftMargin4 = (Console.WindowWidth - intro4.Length) / 2;
        Console.SetCursorPosition(leftMargin4, Console.CursorTop);
        Console.WriteLine(intro4);

        */

        Console.ReadKey();
        Console.Clear();
    }

    private static void DisplayAnimatedIntro()
    {
        string[] credits = new[]
        {
            "   A   ",
            "\n\n\n\n\n\n\n",

            "   C   ",
            "   P   ",
            "   E   ",
            "\n\n\n\n\n\n\n",

            "   P   ",
            "   R   ",
            "   O   ",
            "   J   ",
            "   E   ",
            "   C   ",
            "   T   ",          
        };

        foreach (var line in credits)
        {
            var rule4 = new Rule($"[bold italic greenyellow]{line}[/]");
            rule4.Style = Style.Parse("turquoise2");
            rule4.Justification = Justify.Center;
            AnsiConsole.Write(rule4);

            Thread.Sleep(530); // Adjust the sleep duration to control the speed of the animation
        }
    }

    private static void DisplayAnimatedIntro2()
    {
        string[] credits = new[]
        {
            "",
            "",       
        };

        foreach (var line in credits)
        {
            var rule4 = new Rule();
            rule4.Style = Style.Parse("blue");
            rule4.Justification = Justify.Center;
            AnsiConsole.Write(rule4);

            Thread.Sleep(10); // Adjust the sleep duration to control the speed of the animation
        }
    }

    private static void DisplayAnimatedIntro3()
    {
        string[] credits = new[]
        {
            "",
            "",           
        };

        foreach (var line in credits)
        {
            var rule4 = new Rule();
            rule4.Style = Style.Parse("red");
            rule4.Justification = Justify.Center;
            AnsiConsole.Write(rule4);

            Thread.Sleep(200); // Adjust the sleep duration to control the speed of the animation
        }
    }

    private static void DisplayAnimatedIntro4()
    {
        string[] credits = new[]
        {
            "",
            "",                 
        };

        foreach (var line in credits)
        {
            var rule4 = new Rule();
            rule4.Style = Style.Parse("green");
            rule4.Justification = Justify.Center;
            AnsiConsole.Write(rule4);

            Thread.Sleep(200); // Adjust the sleep duration to control the speed of the animation
        }
    }


}



/*

public static void DisplayWelcomeIntro()
{
    string asciiChars = ".,:ilwW@@";

    var capture = new VideoCapture("TEST.mp4");
    var img = new Mat();

    StringBuilder sb = new();
    while (capture.IsOpened) 
    {
        capture.Read(img);
        if (img.Cols == 0) break;
        var bit = img.ToBitmap();
        var divideBy = img.Width / 150;
        var resized = new System.Drawing.Size(img.Width / divideBy, img.Height / divideBy);
        Bitmap bitResized = new(bit, resized);

        for (int i = 0; i < bitResized.Height; i++)
        {
            for (int j = 0; j < bitResized.Height; j++)
            {
                var pixel = bitResized.GetPixel(j, i);
                var avg = (pixel.R + pixel.G + pixel.B) / 3;
                sb.Append(asciiChars[avg * 10 / 225 % asciiChars.Length]);
            }
            sb.AppendLine();
        }
    }

    Console.Write(sb.ToString());
    Console.SetCursorPosition(0, 0);
    sb.Clear();

}


*/

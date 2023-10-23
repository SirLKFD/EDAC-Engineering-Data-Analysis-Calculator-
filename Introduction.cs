class Introduction
{
    public static void DisplayLoading()
    {
        Console.Write("Loading, please wait: ");
        for (int i = 1; i <= 100; i++)
        {
            Console.SetCursorPosition(22, Console.CursorTop);
            Console.Write(i + "%");
            Thread.Sleep(1);
            Console.SetCursorPosition(22, Console.CursorTop);
        }
        Console.Clear();
    }

    public static void DisplayWelcomeIntro()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        string[] intros = {
        "ENGINEERING DATA ANALYSIS CALCULATOR", "VERSION 0.0.1 PRE-ALPHA BUILD",
        "Created by Lord Kent F. Dinampo, BSCpE - 2nd Year, CPE261 (H1)",
        "\"PROGRAM UNDER CONSTRUCTION, SUBJECT TO CHANGES, POSSIBLE UNEXPECTED BUGS TO BE PRESENT\""
          };

        int maxIntroLength = intros.Max(s => s.Length);
        int boxWidth = maxIntroLength + 10; 
        int leftMargin = (Console.WindowWidth - boxWidth) / 2;
        string topBorder = new string('=', boxWidth);
        Console.SetCursorPosition(leftMargin, Console.CursorTop);
        Console.WriteLine(topBorder);

        foreach (string intro in intros)
        {
            Console.SetCursorPosition(leftMargin, Console.CursorTop + 1);
            Console.Write("||");

            int introLeftMargin = (boxWidth - intro.Length) / 2;
            Console.SetCursorPosition(leftMargin + introLeftMargin, Console.CursorTop);
            foreach (char c in intro)
            {
                Console.Write(c);
                Thread.Sleep(10);
            }

            Console.SetCursorPosition(leftMargin + boxWidth - 2, Console.CursorTop);
            Console.Write("||");

            Console.WriteLine();
            Console.WriteLine();
        }

        Console.SetCursorPosition(leftMargin, Console.CursorTop);
        Console.WriteLine(topBorder);

        Console.WriteLine();

        string intro4 = "Press any key to continue...";
        

        int leftMargin4 = (Console.WindowWidth - intro4.Length) / 2;
        Console.SetCursorPosition(leftMargin4, Console.CursorTop);
        Console.WriteLine(intro4);

        Console.ReadKey();
        Console.Clear();
    }

}
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Introduction.DisplayLoading();
           Introduction.DisplayWelcomeIntro();

            Console.Clear();
            MainMenu.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }        
    }
}

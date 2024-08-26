//using Spectre.Console;
using System.Runtime.InteropServices;
using static TicTacToe;
using Figgle;
using Colorful;
using System.Drawing;
using System.Text;

public static class Program
{
    public static void Main() //not passing in any arguments from console, so removed string[] args
    {
        System.Console.BackgroundColor = ConsoleColor.DarkMagenta;
        System.Console.Clear();


        /*  AnsiConsole.Write(
       new FigletText("Tic-Tac-Toe")
           .LeftJustified()
           .Color(Color.DarkGoldenrod));
       }*/

        // Generate Figlet text
        string figletText = FiggleFonts.Standard.Render("Tic-Tac-Toe!");

        string asciiart = @"
 ___________
||         ||            _______
||ASCII ART||           | _____ |
||         ||           ||_____||
||_________||           |  ___  |
|  + + + +  |           | |___| |
    _|_|_   \           |       |
   (_____)   \          |       |
              \    ___  |       |
       ______  \__/   \_|       |
      |   _  |      _/  |       |
      |  ( ) |     /    |_______|
      |___|__|    /         CA15
           \_____/";

        System.Console.WriteLine(asciiart);

        // Display Figlet text
        Colorful.Console.WriteLine(figletText);

        Colorful.Console.WriteLine("1. Play Tic-Tac-Toe");
        Colorful.Console.WriteLine("2. Exit");
        Colorful.Console.Write("Enter your choice: ");
        string choice = Colorful.Console.ReadLine();

        switch (choice)
        {
            case "1":
                TicTacToe.PlayGame();
                break;
            case "2":
                Colorful.Console.WriteWithGradient("Goodbye!", Color.Aqua, Color.Red, 2);
                Colorful.Console.WriteWithGradient("Exiting...", Color.Aqua, Color.Red, 2);
                break;
            default:
                Colorful.Console.WriteWithGradient("Invalid choice. Exiting...", Color.Fuchsia, Color.Red, 143);
                break;
        }
    }
}
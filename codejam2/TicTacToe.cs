using System;
using System.Drawing;
using Figgle;
using Colorful;
using Console = System.Console;

public class TicTacToe
{
    // detail each space in the board so a user knows how to select them
    private static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    private static char currentPlayer = 'X';

    public static void PlayGame()
    {
        int move;
        bool gameWon = false;

        // while the game isn't over keep allowing turns
        while (!gameWon && !BoardFull())
        {
            System.Console.Clear();
            PrintBoard(); // print the board at the end
            System.Console.Write($"Player {currentPlayer}, enter your move (1-9): ");
            move = int.Parse(Console.ReadLine()) - 1;

            if (board[move] != 'X' && board[move] != 'O')
            {
                board[move] = currentPlayer;
                gameWon = CheckWin();
                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }
        }

        Console.Clear();
        PrintBoard(); // print the board at the end

        if (gameWon)
        {
            if (currentPlayer == 'X')
            {
                string figletText = FiggleFonts.Cosmic.Render("Player 0 wins!");
                Colorful.Console.WriteLine(figletText);

                
                //Figlet figlet = new Figlet();

                //Colorful.Console.WriteLine(figlet.ToAscii("Player 0 wins!"), ColorTranslator.FromHtml("#8AF!FEF"));
                
            }
            else
            {
                string figletText = FiggleFonts.Chunky.Render("Player X wins!");
                Colorful.Console.WriteLine(figletText);
            }
        }
        else
        {
            string figletText = FiggleFonts.Chiseled.Render("It's a draw!");
            Colorful.Console.WriteLine(figletText);
        }
    }

    private static void PrintBoard()
    {
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
    }

    private static bool CheckWin()
    {
        int[,] winPositions = {
            // the win positions contain rows,
            // columns, and diagonals
            {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, // Rows
            {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, // Columns
            {0, 4, 8}, {2, 4, 6}             // Diagonals
        };

        for (int i = 0; i < winPositions.GetLength(0); i++)
        {
            if (board[winPositions[i, 0]] == board[winPositions[i, 1]] &&
                board[winPositions[i, 1]] == board[winPositions[i, 2]])
            {
                return true;
            }
        }
        return false;
    }

    // this function makes sure that every space in the board
    // has been filled up by a player
    private static bool BoardFull()
    {
        foreach (char c in board)
        {
            if (c != 'X' && c != 'O')
            {
                return false;
            }
        }
        return true;
    }
}


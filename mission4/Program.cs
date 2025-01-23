using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe!");

            // Initialize the game board
            char[,] board = {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
            };

            Board helper = new Board();
            bool isGameRunning = true;
            char currentPlayer = 'X';
            int turnCount = 0;

            while (isGameRunning)
            {
                // Print the game board
                helper.PrintBoard(board);

                // Get player's move
                Console.WriteLine($"Player {currentPlayer}, enter your move (1-9): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int move) && move >= 1 && move <= 9)
                {
                    // Calculate row and column
                    int row = (move - 1) / 3;
                    int col = (move - 1) % 3;

                    // Check if the position is available
                    if (board[row, col] != 'X' && board[row, col] != 'O')
                    {
                        board[row, col] = currentPlayer;
                        turnCount++;

                        // Check if there's a winner
                        if (helper.CheckWinner(board, currentPlayer))
                        {
                            helper.PrintBoard(board);
                            Console.WriteLine($"Player {currentPlayer} wins!");
                            isGameRunning = false;
                        }
                        else if (turnCount == 9) // Check for a draw
                        {
                            helper.PrintBoard(board);
                            Console.WriteLine("It's a draw!");
                            isGameRunning = false;
                        }
                        else
                        {
                            // Switch to the other player
                            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                        }
                    }
                    else
                    {
                        Console.WriteLine("That spot is already taken. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move. Please enter a number between 1 and 9.");
                }
            }
        }
    }
}
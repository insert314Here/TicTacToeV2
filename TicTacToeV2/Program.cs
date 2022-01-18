using System;

namespace TicTacToeV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char player = 'X';

            //create 2 dimensional array for the board characters [row,col]
            //3x3 board to fit all the X/O
            char[,] board = new char[3, 3];

            //bool gameEnd = false; --> using break statement in loop removes need for this game check bool

            InitializeBoard(board);
            int movesPlayed = 0;
            PrintBoard(board);


            //The game plays unitl, win, loss, draw
            while (true)//usage with break statement in loop
            {
                //clear the screen
                Console.Clear();
                //show me the board
                PrintBoard(board);

                //move inputs
                Console.Write("Enter Row: ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("\nEnter Column: ");
                int col = int.Parse(Console.ReadLine());

                //takes the char X or O and places in the row/col based on user input
                // since player will be X or O, respective letter is placed in the row,col
                board[row, col] = player;

                //before we change turns and clear the screen, want to check if someone has won
                
                
                // top row / middle row / bottom row|  [00,01,02] : [10,11,12] : [20,21,22]
                if (player == board[0,0] && player == board[0,1] && player == board[0,2])
                {
                    Console.WriteLine($"{player} has won the game with a TOP ROW WIN");
                    break;
                }
                else if (player == board[1, 0] && player == board[1, 1] && player == board[1, 2])
                {
                    Console.WriteLine($"{player} has won the game with a MIDDLE ROW WIN");
                    break;
                }
                else if (player == board[2, 0] && player == board[2, 1] && player == board[2, 2])
                {
                    Console.WriteLine($"{player} has won the game with a BOTTOM ROW WIN");
                    break;
                }
                // colWins - 1st/ 2nd / 3rd         |  [00,10,20] : [01,11,21] : [02,12,22]
                else if (player == board[0, 0] && player == board[1, 0] && player == board[2, 0])
                {
                    Console.WriteLine($"{player} has won the game with a LEFT COLUMN WIN");
                    break;
                }
                else if (player == board[0, 1] && player == board[1, 1] && player == board[2, 1])
                {
                    Console.WriteLine($"{player} has won the game with a MIDDLE COLUMN WIN");
                    break;
                }
                else if (player == board[0, 2] && player == board[1, 2] && player == board[2, 2])
                {
                    Console.WriteLine($"{player} has won the game with a RIGHT COLUMN WIN");
                    break;
                }
                // L->R diag / R->L Diag            |  [00,11,22] : [02,11,20]
                else if (player == board[0, 0] && player == board[1, 1] && player == board[2, 2])
                {
                    Console.WriteLine($"{player} has won the game with a LEFT DIAGONAL WIN");
                    break;
                }
                else if (player == board[0, 2] && player == board[1, 1] && player == board[2, 0])
                {
                    Console.WriteLine($"{player} has won the game with a RIGHT DIAGONAL WIN");
                    break;
                }

                movesPlayed++;
                if (movesPlayed == 9)
                {
                    Console.WriteLine("Game is in a draw");
                    break;
                }
                //assign player the value of the methods return value(char)
                player = ChangeTurn(player);

            }

            //celebrate winner
            //clear screen
            //printboard
            //mention who won or if draw

        }//outside main

        static char ChangeTurn(char currentPlayer)
        {
            //change player
            if (currentPlayer == 'X')
            {
                return 'O';
            }
            else
            {
                return 'X';
            }
        }

        static void PrintBoard(char[,] board)
        {
            //printing board
            Console.WriteLine("   0   1   2  \n______________");

            for (int row = 0; row < 3; row++)
            {
                Console.Write($"{row}| ");
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(board[row, col]);
                    Console.Write($" | ");
                }
                Console.WriteLine();
            }
        }

        static void InitializeBoard(char[,] board)
        {
            //initialize empty board
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }

        static (int, int) MoveChoice(int r, int c)
        {
            Console.Write("Enter Row: ");
            int row = int.Parse(Console.ReadLine());

            Console.Write("\nEnter Column: ");
            int col = int.Parse(Console.ReadLine());

            return (row, col);
        }
    }
}

using System;
using System.Threading;

namespace TicTacToe
{
    class gameBoard
    {
        public static string [] Create()
        {
            int x = 1;
            string[] board = new string[9];
            for (int i = 0; i < 9; i++)
            {
                board[i] = Convert.ToString(x);
                x++;
            }
            return board;
        }

        public static void Print(string[] board) 
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("    |    |    ");
            Console.WriteLine("  {0} |  {1} |  {2}  ", board[0], board[1], board[2]);
            Console.WriteLine("____|____|____");
            Console.WriteLine("    |    |    ");
            Console.WriteLine("  {0} |  {1} |  {2}  ", board[3], board[4], board[5]);
            Console.WriteLine("____|____|____");
            Console.WriteLine("    |    |    ");
            Console.WriteLine("  {0} |  {1} |  {2}  ", board[6], board[7], board[8]);
            Console.WriteLine();
        }


        public static string [] Move(string[] board)
        {
            int validMove = 0;
            while (validMove != 1)
            {
                Console.WriteLine("Choose where you want to place a move..");
                int move = (int.Parse(Console.ReadLine())) - 1;
                if (board[move] != "X" && board[move] != "O")
                {
                    board[move] = "X";
                    validMove = 1;

                }
                else
                {
                    Console.WriteLine("Position already taken, please choose another.");
                    Thread.Sleep(2000);
                    Print(board);
                };
                
            }
            return board;
        }         
    }
    class Program
    {
  
        static void Main(string[] args)
        {
            string [] board = gameBoard.Create();

            gameBoard.Print(board);
            gameBoard.Move(board);
            gameBoard.Print(board);
            gameBoard.Move(board);
            gameBoard.Print(board);
            gameBoard.Move(board);
            Console.ReadKey();
        }
    }
}

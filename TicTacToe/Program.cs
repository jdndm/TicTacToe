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
            Console.WriteLine("PLAYER1: X PLAYER2: O");
            Console.WriteLine();
            Console.WriteLine("       |    |    ");
            Console.WriteLine("     {0} |  {1} |  {2}  ", board[0], board[1], board[2]);
            Console.WriteLine("   ____|____|____");
            Console.WriteLine("       |    |    ");
            Console.WriteLine("     {0} |  {1} |  {2}  ", board[3], board[4], board[5]);
            Console.WriteLine("   ____|____|____");
            Console.WriteLine("       |    |    ");
            Console.WriteLine("     {0} |  {1} |  {2}  ", board[6], board[7], board[8]);
            Console.WriteLine();
        }


        public static string [] Move(string[] board, bool player1)
        {
            int validMove = 0;
            string player;
            string token;
            while (validMove != 1)
            {
                if (player1 == true)
                {
                    player = "Player 1";
                    token = "X";
                }
                else
                {
                    player = "Player 2";
                    token = "O";
                }

                

                Console.WriteLine("{0}, choose where you want to place a move..", player);
                int move = (int.Parse(Console.ReadLine())) - 1;
                if (board[move] != "X" && board[move] != "O")
                {
                    board[move] = token;
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
            bool player1 = true;
            string [] board = gameBoard.Create();

            gameBoard.Print(board);
            for (int i = 0; i < 3; i++)
            {
                gameBoard.Move(board, player1);
                gameBoard.Print(board);
                player1 = !player1;
            }
            

            Console.ReadKey();
        }
    }
}

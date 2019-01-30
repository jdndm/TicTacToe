using System;
using System.Threading;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            bool player1 = true;
            int win = 0;
            string[] board = GameBoard.Create();
            GameBoard.Print(board);
            do
            {
                GameBoard.Move(board, player1);
                GameBoard.Print(board);
                win = GameBoard.WinDraw(board, win);
                if (win == 0)
                {
                    player1 = !player1;
                } 
            } while (win == 0);
            string[] player = GameBoard.Player(player1);
            if (win == 1)
            {
                Console.WriteLine("Congratulations {0} you have won the game.", player[0]);

            }
            else
            {
                Console.WriteLine("No more moves possible, it is a DRAW.");

            }
            Console.ReadKey();
        }
    }
}

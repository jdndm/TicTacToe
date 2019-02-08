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
            GameBoard board = new GameBoard();
            board.Print();
            do
            {
                board.Move(player1);
                board.Print();
                win = board.WinDraw(win);
                if (win == 0)
                {
                    player1 = !player1;
                } 
            } while (win == 0);
            string[] player = board.Player(player1);
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

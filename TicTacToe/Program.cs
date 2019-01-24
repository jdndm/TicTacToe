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
        public static string [] Player(bool player1)
        {
            string[] player = new string [2];
            if (player1 == true)
            {
                player[0] = "Player 1";
                player[1] = "X";  
            }
            else
            {
                player[0] = "Player 2";
                player[1] = "O";
            }
            return player;
        }
        public static string [] Move(string[] board, bool player1)
        {
            int validMove = 0;
            string[] player = Player(player1);
            while (validMove != 1)
            {

                Console.WriteLine("{0}, choose where you want to place a move..", player[0]);
                int move = (int.Parse(Console.ReadLine())) - 1;
                if (board[move] != "X" && board[move] != "O")
                {
                    board[move] = player[1];
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
        public static bool WinningCondition(string [] board)
        {
            bool win;
            if (board[0] == board[1] && board[1] == board[2])
            {
                win = true;
            }
            else if (board[3] == board[4] && board[4] == board[5])
            {
                win = true;
            }
            else if (board[6] == board[7] && board[7] == board[8])
            {
                win = true;
            }
            else if (board[0] == board[3] && board[3] == board[6])
            {
                win = true;
            }
            else if (board[1] == board[4] && board[4] == board[7])
            {
                win = true;
            }
            else if (board[2] == board[5] && board[5] == board[8])
            {
                win = true;
            }
            else if (board[0] == board[4] && board[4] == board[8])
            {
                win = true;
            }
            else if (board[6] == board[4] && board[4] == board[2])
            {
                win = true;
            }
            else
            {
                win = false;
            }
            return win;
        }
    }
    class Program
    { 
        static void Main(string[] args)
        {
            bool player1 = true;
            bool win = false;
            string [] board = gameBoard.Create();
            gameBoard.Print(board);
            do
            {
                gameBoard.Move(board, player1);
                gameBoard.Print(board);
                win = gameBoard.WinningCondition(board);
                if (win == false)
                {
                    player1 = !player1;
                }
            } while (win == false);

            Console.ReadKey();
        }
    }
}

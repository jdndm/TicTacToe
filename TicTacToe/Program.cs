using System;
using System.Threading;

namespace TicTacToe
{
    class GameBoard
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
                bool validInt = false;
                int move = -1;
                while (!validInt)
                {
                    try
                    {
                        move = int.Parse(Console.ReadLine()) - 1;
                        if (move < 0 || move > 9)
                            throw new Exception();
                        else
                            validInt = true;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Move, please enter an available number..");
                    }
                }

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
        public static int WinningCondition(string [] board, int win)
        {
            int[,] winningMoves = new int[8, 3] { { 0, 1, 2 },
                                                  { 3, 4, 5 },
                                                  { 6, 7, 8 },
                                                  { 0, 3, 6 },
                                                  { 1, 4, 7 },
                                                  { 2, 5, 8 },
                                                  { 0, 4, 8 },
                                                  { 6, 4, 2 } };

            for (int i = 0; i < 8; i++)
            {
                if (board[winningMoves[i,0]] == board[winningMoves[i,1]] && board[winningMoves[i,1]] == board[winningMoves[i, 2]])
                {
                    win = 1;
                    break;
                }
                else
                {
                    win = 0;
                }
            }
            return win;
        }
        public static int DrawCondition (string [] board, int win)
        {
            string[] drawArray = new string[] { "1", "2", "3,", "4", "5", "6", "7", "8", "9" };
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == drawArray[i])
                {
                    win = 0;
                    break;
                }
                else
                {
                    win = -1;
                }
            }
            return win;
        }
        public static int WinDraw (string [] board, int win)
        {
            win = GameBoard.WinningCondition(board, win);
            if (win == 0)
            {
                win = GameBoard.DrawCondition(board, win);                
            }
            return win;
        }
    }
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

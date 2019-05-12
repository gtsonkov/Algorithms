using System;

namespace EightQeens
{
    using System.Text;
    class EightQeens
    {
        static int count = 0;
        static void Main(string[] args)
        {
            bool[,] board = new bool[8, 8];
            FillBoard(board, 8, 0);
            Console.WriteLine("---" + count + "---");
        }
        static void FillBoard(bool[,] board, int queens, int index)
        {
            if (index >= queens)
            {
                count++;
                PrintBoard(board);
            }
            else
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (!(LookForQueen(index, col, board)))
                    {
                        board[index, col] = true;
                        FillBoard(board, queens, (index + 1));
                        board[index, col] = false;
                    }
                }
            }
        }
        static bool LookForQueen(int row, int col, bool[,] board)
        {
            int i, j;
            for (i = 0; i < 8; i++)
            {
                if (board[row, i] == true) return true;
            }
            for (i = 0; i < 8; i++)
            {
                if (board[i, col] == true) return true;
            }
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == true) return true;
            }
            for (i = row, j = col; i <= 7 && j <= 7; i++, j++)
            {
                if (board[i, j] == true) return true;
            }
            for (i = row, j = col; j >= 0 && i <= 7; i++, j--)
            {
                if (board[i, j] == true) return true;
            }
            for (i = row, j = col; j <= 7 && i >= 0; i--, j++)
            {
                if (board[i, j] == true) return true;
            }
            return false;
        }
        static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                StringBuilder line = new StringBuilder();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col])
                    {
                        line.Append("*");
                    }
                    else
                    {
                        line.Append("-");
                    }
                }
                Console.WriteLine(line);
            }
            Console.WriteLine("-BORDER-");
        }
    }
}

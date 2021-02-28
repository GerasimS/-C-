using System;

namespace Sudoku
{
    class Sudoku
    {
        public static void Main(String[] args)
        {

            int[,] board = new int[,] {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };
            string input;

            while (true)
            {
                Console.WriteLine("Enter the unsolved sudoku:");
                input = Console.ReadLine().Trim().Replace(" ", "");

                if (input.Length > 81)
                {
                    input = input.Remove(81);
                    break;
                }
                else if (input.Length < 81)
                {
                    Console.WriteLine("You have not entered enough symbols!");
                }
                else break;
            }


            int count = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = input[count++] - 48;
                }
            }

            int N = board.GetLength(0);

            if (solveSudoku(board, N))
            {
                print(board, N);
            }
            else
            {
                Console.Write("No solution");
            }
        }

        public static bool isSafe(int[,] board,
                              int row, int col,
                              int num)
        {

            for (int c = 0; c < board.GetLength(0); c++)
            {
                if (board[row, c] == num)
                {
                    return false;
                }
            }

            for (int r = 0; r < board.GetLength(0); r++)
            {
                if (board[r, col] == num)
                {
                    return false;
                }
            }

            int sqrt = (int)Math.Sqrt(board.GetLength(0));
            int boxRowStart = row - row % sqrt;
            int boxColStart = col - col % sqrt;

            for (int r = boxRowStart;
                 r < boxRowStart + sqrt; r++)
            {
                for (int c = boxColStart;
                     c < boxColStart + sqrt; c++)
                {
                    if (board[r, c] == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool solveSudoku(int[,] board,
                                               int n)
        {
            int row = -1;
            int col = -1;
            bool isEmpty = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i, j] == 0)
                    {
                        row = i;
                        col = j;

                        isEmpty = false;
                        break;
                    }
                }
                if (!isEmpty)
                {
                    break;
                }
            }

            if (isEmpty)
            {
                return true;
            }

            
            for (int num = 1; num <= n; num++)
            {
                if (isSafe(board, row, col, num))
                {
                    board[row, col] = num;
                    if (solveSudoku(board, n))
                    {
                        return true;
                    }
                    else
                    {
                        board[row, col] = 0;
                    }
                }
            }
            return false;
        }

        public static void print(int[,] board, int N)
        {

            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    Console.Write(board[r, c]);
                    Console.Write(" ");
                }
                Console.Write("\n");

                if ((r + 1) % (int)Math.Sqrt(N) == 0)
                {
                    Console.Write("");
                }
            }
        }
    }
}

/*
Diagonal Difference
Write a program that finds the difference between the sums of the square matrix diagonals (absolute value).
Input
 On the first line, you are given the integer N – the size of the square matrix
 The next N lines holds the values for every row – N numbers separated by a space
Output
 Print the absolute difference between the sums of the primary and the secondary diagonal
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int primary = 0;
            int secondary = 0;
            int indexPrimary = 0;
            int indexSecondary = matrix.GetLength(1) - 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == indexPrimary && row == indexPrimary)
                    {
                        primary += matrix[row, col];
                        indexPrimary++;
                    }

                    if (col == indexSecondary)
                    {
                        secondary += matrix[row, col];
                        indexSecondary--;
                    }
                }
            }

            int diff = Math.Abs(primary - secondary);
            Console.WriteLine(diff);

        }
    }
}

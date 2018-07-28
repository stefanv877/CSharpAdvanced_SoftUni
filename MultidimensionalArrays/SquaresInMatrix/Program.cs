/*
2x2 Squares in Matrix
Find the count of 2 x 2 squares of equal chars in a matrix.
Input
 On the first line, you are given the integers rows and cols – the matrix’s dimensions
 Matrix characters come at the next rows lines (space separated)
Output
 Print the number of all the squares matrixes you have found
*/


using System;
using System.Linq;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int result = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char current = matrix[row, col];

                    if (current == matrix[row, col + 1] && current == matrix[row + 1, col] && current == matrix[row + 1, col + 1])
                    {
                        result++;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}

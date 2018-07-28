/*
Rubik’s Matrix
Rubik’s cube – everyone’s favorite head-scratcher. Writing a program to solve it will be quite a difficult task for an
exam, though. Instead, we have a Rubik’s matrix prepared for you. You will be given a pair of dimensions: R and C.
To prepare the matrix, fill each row with increasing integers, starting from one. For example, 2 x 4 matrix must look
like this:
1 2 3 4
5 6 7 8
Next, you will receive series of commands, indicating which row or column you must move, in which direction, and
how many times. For example, 1 up 1 means: column 1, direction: up, 1 move. After executing it, the matrix should
look like:
1 6 3 4
5 2 7 8
Directions left and right means you must move the corresponding row, while up and down are related to the
columns. After shuffling the Rubik’s matrix, you have to rearrange it (meaning that the values in each cell should be
in increasing order, such as the ones in the original matrix). The rearranging process should start at top-left and end
at bottom-right. Find the position of the value you need, and print the swap command on the console, in the
format described below.
Input
 On the first line, you are given the integers R and C, separated by a space
 On the second line, you are given an integer N, indicating the number of commands to follow
 On the next N lines, you are given commands in format {row/col} {direction} {moves}
Output
 On R * C number of lines, print the swap commands needed to rearrange the matrix, either:
o “Swap ({row}, {col}) with ({row}, {col})” or
o “No swap required”

Constraints
 R, C, N are integers in range [1 … 100]
 {row} and {col} will always be inside the matrix
 {moves} is in range [0 … 2 31 -1]
 Allowed time and memory: 0.25s / 16 MB
*/


using System;
using System.Collections.Generic;
using System.Linq;

namespace RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine()
                                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();

            int[,] rubikCubeMatrix = new int[matrixDimensions[0], matrixDimensions[1]];

            int cellNumber = 1;

            for (int row = 0; row < rubikCubeMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < rubikCubeMatrix.GetLength(1); col++)
                {
                    rubikCubeMatrix[row, col] = cellNumber;
                    cellNumber++;
                }
            }

            int numberOfCommands = int.Parse(Console.ReadLine());

            while (numberOfCommands != 0)
            {
                string[] inputCommands = Console.ReadLine()
                                           .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                           .ToArray();

                int rowOrColOfMatrix = int.Parse(inputCommands[0]);
                string command = inputCommands[1];
                int moves = int.Parse(inputCommands[2]);

                rubikCubeMatrix = FourDirections(rubikCubeMatrix, rowOrColOfMatrix, moves, command);

                numberOfCommands--;
            }

            cellNumber = 1;

            for (int row = 0; row < rubikCubeMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < rubikCubeMatrix.GetLength(1); col++)
                {
                    if (rubikCubeMatrix[row, col] == cellNumber)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        int currentNumber = rubikCubeMatrix[row, col];
                        int switchNumberRow = 0;
                        int switchNumberCol = 0;

                        for (int checkerRow = 0; checkerRow < rubikCubeMatrix.GetLength(0); checkerRow++)
                        {
                            for (int checkerCol = 0; checkerCol < rubikCubeMatrix.GetLength(1); checkerCol++)
                            {
                                if (rubikCubeMatrix[checkerRow, checkerCol] == cellNumber)
                                {
                                    rubikCubeMatrix[checkerRow, checkerCol] = currentNumber;
                                    switchNumberRow = checkerRow;
                                    switchNumberCol = checkerCol;
                                    break;
                                }
                            }
                        }

                        rubikCubeMatrix[row, col] = cellNumber;

                        Console.WriteLine($"Swap ({row}, {col}) with ({switchNumberRow}, {switchNumberCol})");
                    }
                    cellNumber++;
                }
            }
        }

        public static int[,] FourDirections(int[,] currentMatrix, int index, int move, string command)
        {
            Queue<int> matrixRowOrCol = new Queue<int>();
            if (command == "right" || command == "down")
            {
                for (int row = currentMatrix.GetLength(0) - 1; row >= 0; row--)
                {
                    for (int col = currentMatrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (row == index && command == "right")
                        {
                            matrixRowOrCol.Enqueue(currentMatrix[row, col]);
                        }
                        else if (col == index && command == "down")
                        {
                            matrixRowOrCol.Enqueue(currentMatrix[row, col]);
                        }
                    }
                }

                if (command == "right")
                {
                    int moves = move % currentMatrix.GetLength(0);
                    while (moves != 0)
                    {
                        matrixRowOrCol.Enqueue(matrixRowOrCol.Dequeue());
                        moves--;
                    }
                }
                else if (command == "down")
                {
                    int moves = move % currentMatrix.GetLength(1);
                    while (moves != 0)
                    {
                        matrixRowOrCol.Enqueue(matrixRowOrCol.Dequeue());
                        moves--;
                    }
                }

                for (int row = currentMatrix.GetLength(0) - 1; row >= 0; row--)
                {
                    for (int col = currentMatrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (row == index && command == "right")
                        {
                            currentMatrix[row, col] = matrixRowOrCol.Dequeue();
                        }
                        else if (col == index && command == "down")
                        {
                            currentMatrix[row, col] = matrixRowOrCol.Dequeue();
                        }
                    }
                }
            }
            else if (command == "left" || command == "up")
            {
                for (int row = 0; row < currentMatrix.GetLength(0); row++)
                {
                    for (int col = 0; col < currentMatrix.GetLength(1); col++)
                    {
                        if (row == index && command == "left")
                        {
                            matrixRowOrCol.Enqueue(currentMatrix[row, col]);
                        }
                        else if (col == index && command == "up")
                        {
                            matrixRowOrCol.Enqueue(currentMatrix[row, col]);
                        }
                    }
                }

                if (command == "left")
                {
                    int moves = move % currentMatrix.GetLength(0);
                    while (moves != 0)
                    {
                        matrixRowOrCol.Enqueue(matrixRowOrCol.Dequeue());
                        moves--;
                    }
                }
                else if (command == "up")
                {
                    int moves = move % currentMatrix.GetLength(1);
                    while (moves != 0)
                    {
                        matrixRowOrCol.Enqueue(matrixRowOrCol.Dequeue());
                        moves--;
                    }
                }

                for (int row = 0; row < currentMatrix.GetLength(0); row++)
                {
                    for (int col = 0; col < currentMatrix.GetLength(1); col++)
                    {
                        if (row == index && command == "left")
                        {
                            currentMatrix[row, col] = matrixRowOrCol.Dequeue();
                        }
                        else if (col == index && command == "up")
                        {
                            currentMatrix[row, col] = matrixRowOrCol.Dequeue();
                        }
                    }
                }
            }

            return currentMatrix;
        }
    }
}

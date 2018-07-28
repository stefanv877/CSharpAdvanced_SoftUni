/*
Dangerous Floor
You have just entered the door at the final address. In the end of the room there is a safe which holds the treasure you are searching for. The floor between you and the safe though is dangerous! If you do a wrong move it will collapse and you will never reach the treasure …or anything ...ever. Luckily you have gathered all the pieces of instructions left from this uncle of yours at each address you have visited before.
Imagine the floor in the form of a chess board. On different squares of this “board” are placed some chess pieces. If you follow all the instructions correctly (where possible) you will be able to pass safely on the other side.
The board is 8x8 squares. There are 6 kinds of pieces:
•	King - moves exactly one square horizontally, vertically, or diagonally.
•	Rook- moves any number of vacant squares in a horizontal or vertical direction.
•	Bishop - moves any number of vacant squares in any diagonal direction.
•	Queen - moves any number of vacant squares in a horizontal, vertical, or diagonal direction.
•	Pawn – moves straight forward one square to the top.
Yeah, we know, that there are some more moves and figures, but for now these are enough. You can check the visual representation of the moves here. 
Input
On the first 8 rows, you will receive а board with some pieces placed on it. Empty cells will be marked with "x" and all squares will be separated by comma.
{x,x,Q,x,R,x,x,P}
{x,B,x,x,x,K,x,P}
There are 7 symbols all in all:
•	K – King
•	R – Rook 
•	B – Bishop 
•	Q – Queen 
•	P – Pawn 
•	x – Empty cell
On the next lines, you will receive moves that need to be checked and if they are valid you should move the piece to its new position. There are 3 kinds of problems that may occur and you need to be looking for. The check must happen in the very same order as shown below:
1.	There is no such a piece on starting square.
2.	Piece makes invalid move (look above).
3.	Piece gets out of board.
So, if you find that there is no such a piece, you don't need to check for the other problems. If you find any problem then you must cancel the move and the board stays the same for the next move.
{Q01-12}
The first symbol is the type of piece you need to move. Then you will read two digits which sate the position on which the piece should be currently (row, col). The next two digits are the final position (row, col) where you should try to move the piece to.
Read moves till you find the keyword "END".
Output
You should print lines on the console only when the move is not possible. You can have three different types of output, depending on what kind of problem you hit. 
1.	There is no such a piece!
2.	Invalid move!
3.	Move go out of board!
You can print only one message per invalid input move, so check for the problems in the order shown above. The check must happen in the very same order.
Constraints
•	Pieces will never go to a cell with another piece 
•	Moves count will be in the range [0…1000]
•	Time limit: 0.3 sec. Memory limit: 16 MB.
*/


using System;
using System.Linq;

namespace DangerousFloor
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[8][];

            for (int counter = 0; counter < 8; counter++)
            {
                board[counter] = Console.ReadLine()
                    .Split(',')
                    .Select(char.Parse)
                    .ToArray();
            }

            string input;

            char piece;
            int currentRow = 0;
            int currentColumn = 0;
            int targetRow = 0;
            int targetColumn = 0;


            while ((input = Console.ReadLine()) != "END")
            {
                piece = input[0];
                currentRow = int.Parse(input[1].ToString());
                currentColumn = int.Parse(input[2].ToString());
                targetRow = int.Parse(input[4].ToString());
                targetColumn = int.Parse(input[5].ToString());

                if (PieceIsOnTheBoard(piece, currentRow, currentColumn, board))
                {
                    if (MoveIsValid(piece, currentRow, currentColumn, targetRow, targetColumn))
                    {
                        if (IsInBoard(targetRow, targetColumn))
                        {
                            board[currentRow][currentColumn] = 'x';
                            board[targetRow][targetColumn] = piece;
                        }
                        else
                        {
                            Console.WriteLine("Move go out of board!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
                else
                {
                    Console.WriteLine("There is no such a piece!");
                }
            }
        }

        private static bool IsInBoard(int targetRow, int targetColumn)
        {
            if (targetRow >= 0 && targetRow < 8 && targetColumn >= 0 && targetColumn < 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool MoveIsValid(char piece, int currentRow, int currentColumn, int targetRow, int targetColumn)
        {
            switch (piece)
            {
                case 'R':
                    if (currentRow != targetRow && currentColumn == targetColumn || currentRow == targetRow && currentColumn != targetColumn)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case 'B':
                    if (currentRow != targetRow && currentColumn != targetColumn && Math.Abs(currentRow - targetRow) == Math.Abs(currentColumn - targetColumn))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case 'Q':
                    if ((currentRow != targetRow && currentColumn == targetColumn || currentRow == targetRow && currentColumn != targetColumn) 
                        || (currentRow != targetRow && currentColumn != targetColumn) && (Math.Abs(currentRow - targetRow) == Math.Abs(currentColumn - targetColumn)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case 'K':
                    if (((currentRow - 1 == targetRow && currentColumn == targetColumn) || (currentColumn - 1 == targetColumn && currentRow == targetRow) 
                        || (currentRow + 1 == targetRow && currentColumn == targetColumn) || (currentColumn + 1 == targetColumn && currentRow == targetRow))
                        || (Math.Abs(currentRow - targetRow) == 1 && Math.Abs(currentColumn - targetColumn) == 1))
                    {
                        return true;
                    }
                    else
	                {
                        return false;
                    }

                case 'P':
                    if (currentRow - 1 == targetRow)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                default:
                    return false;
            }
        }

        private static bool PieceIsOnTheBoard(char piece, int currentRow, int currentColumn, char[][] board)
        {
            if (board[currentRow][currentColumn] == piece)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
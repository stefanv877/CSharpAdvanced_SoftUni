/*
Reverse Numbers with a Stack
Write a program that reads N integers from the console and reverses them using a stack. Use the Stack&lt;int&gt;
class. Just put the input numbers in the stack and pop them.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var stack = new Stack<int>(input);

            while (stack.Count > 0)
            {
                Console.Write($"{stack.Pop()} ");
            }
        }
    }
}
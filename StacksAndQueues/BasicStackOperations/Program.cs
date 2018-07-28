/*
Basic Stack Operations
Play around with a stack. You will be given an integer N representing the number of elements to push onto the
stack, an integer S representing the number of elements to pop from the stack and finally an integer X, an element
that you should look for in the stack. If it’s found, print “true” on the console. If it isn’t, print the smallest element
currently present in the stack.
Input Format:
 On the first line you will be given N, S and X, separated by a single space
 On the next line you will be given N number of integers
Output Format:
 On a single line print either true if X is present in the stack, otherwise print the smallest element in the
stack. If the stack is empty, print 0
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Split(' ');
            int numberOfElementsToPush = int.Parse(command[0]);
            int numberOfElementsToPop = int.Parse(command[1]);
            int elementToLook = int.Parse(command[2]);
            var input = Console.ReadLine().Split(' ');
            

            var stack = new Stack<int>();

            for (int i = 0; i < numberOfElementsToPush; i++)
            {
                stack.Push(int.Parse(input[i]));
            }

            for (int i = 0; i < numberOfElementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(elementToLook))
            {
                Console.WriteLine("true");
            }
            else
            {
                try
                {
                    Console.WriteLine(stack.Min());
                }
                catch (Exception)
                {
                    Console.WriteLine(0);
                }
            }



        }
    }
}

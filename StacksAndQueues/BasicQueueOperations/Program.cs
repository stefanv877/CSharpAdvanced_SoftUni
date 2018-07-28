/*
Basic Queue Operations
Play around with a queue. You will be given an integer N representing the number of elements to enqueue (add), an
integer S representing the number of elements to dequeue (remove) from the queue and finally an integer X, an
element that you should look for in the queue. If it is, print true on the console. If it’s not print the smallest element
currently present in the queue. If there are no elements in the sequence, print 0 on the console.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var numToAdd = commands[0];
            var numToRemove = commands[1];
            var numToFind = commands[2];
            var queue = new Queue<int>();

            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int count = 0; count < numToAdd; count++)
            {
                queue.Enqueue(input[count]);
            }

            for (int count = 0; count < numToRemove; count++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(numToFind))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}

/*
Calculate Sequence with Queue
We are given the following sequence of numbers:
 S 1 = N
 S 2 = S 1 + 1
 S 3 = 2*S 1 + 1
 S 4 = S 1 + 2
 S 5 = S 2 + 1
 S 6 = 2*S 2 + 1
 S 7 = S 2 + 2
 S 8 = S 3 + 1
 …
Using the Queue&lt;T&gt; class, write a program to print its first 50 members for given N.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            List<long> result = new List<long>();
            queue.Enqueue(n);
            result.Add(n);

            while (result.Count < 50)
            {
                long currentN = queue.Dequeue();
                long firstN = currentN + 1;
                long secondN = (currentN * 2) + 1;
                long thirdN = currentN + 2;

                queue.Enqueue(firstN);
                queue.Enqueue(secondN);
                queue.Enqueue(thirdN);

                result.Add(firstN);
                result.Add(secondN);
                result.Add(thirdN);
            }

            for (int i = 0; i < 50; i++)
            {
                Console.Write($"{result[i]} ");
            }
        }
    }
}

/*
Problem 6. Truck Tour
Suppose there is a circle. There areN petrol pumps on that circle. Petrol pumps are numbered 0 to (N−1) (both
inclusive). You have two pieces of information corresponding to each of the petrol pump: (1) the amount of petrol
that particular petrol pump will give, and (2) the distance from that petrol pump to the next petrol pump.
Initially, you have a tank of infinite capacity carrying no petrol. You can start the tour at any of the petrol pumps.
Calculate the first point from where the truck will be able to complete the circle. Consider that the truck will stop at
each of the petrol pumps. The truck will move one kilometer for each liter of the petrol.
Input Format:
 The first line will contain the value ofN
 The nextN lines will contain a pair of integers each, i.e. the amount of petrol that petrol pump will give and
the distance between that petrol pump and the next petrol pump
Output Format:
 An integer which will be the smallest index of the petrol pump from which we can start the tour
Constraints:
 1 ≤ N ≤ 1000001
 1 ≤ Amount of petrol, Distance ≤ 1000000000
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                pumps.Enqueue(Console.ReadLine()
                              .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray());
            }

            var truckFuel = 0;
            var startIndex = 0;
            var track = pumps.Count;

            for (int i = 0; i <= track && startIndex < pumps.Count; i++)
            {
                int[] currentPump = pumps.Dequeue();
                pumps.Enqueue(currentPump);
                truckFuel += currentPump[0] - currentPump[1];

                if (truckFuel < 0)
                {
                    startIndex = i + 1;
                    track += pumps.Count;
                    truckFuel = 0;
                }
            }

            Console.WriteLine(startIndex);
        }
    }
}

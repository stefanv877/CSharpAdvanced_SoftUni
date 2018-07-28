/*
Balanced Parentheses
Given a sequence consisting of parentheses, determine whether the expression is balanced. A sequence of
parentheses is balanced if every open parenthesis can be paired uniquely with a closed parenthesis that occurs after
the former. Also, the interval between them must be balanced. You will be given three types of parentheses: (, {,
and [.
{[()]} - This is a balanced parenthesis.
{[(])} - This is not a balanced parenthesis.
Input Format:
 Each input consists of a single line, the sequence of parentheses.
Constraints:
 1 ≤ len s ≤ 1000, where len s is the length of the sequence.
 Each character of the sequence will be one of {, }, (, ), [, ].
Output Format:
 For each test case, print on a new line &quot;YES&quot; if the parentheses are balanced.
Otherwise, print &quot;NO&quot;. Do not print the quotes.
*/


using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }

            char[] opening = new[] { '(', '[', '{' };
            char[] closing = new[] { ')', ']', '}' };

            var stack = new Stack<char>();

            foreach (var element in input)
            {
                if (opening.Contains(element))
                {
                    stack.Push(element);
                }
                else if (closing.Contains(element))
                {
                    var lastElement = stack.Pop();
                    int openinigIndex = Array.IndexOf(opening, lastElement);
                    int closingIndex = Array.IndexOf(closing, element);

                    if (openinigIndex != closingIndex)
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(0);
                    }
                }
            }

            if (stack.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }

        }
    }
}
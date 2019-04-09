using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] {15, 10, 3, 7};
            var number = 17;

            var twoPasses = TwoPasses(numbers, number);
            var onePass = Program.onePass(numbers, number);

            Console.WriteLine("Two passes: " + twoPasses);
            Console.WriteLine("One pass: " + onePass);
        }

        private static bool TwoPasses(IEnumerable<int> numbers, int number)
        {
            var result = false;

            foreach (var firstNumber in numbers)
            {
                if (numbers.Select(secondNumber => firstNumber + secondNumber).Any(sum => sum == number))
                {
                    result = true;
                }
            }

            return result;
        }

        private static bool onePass(IEnumerable<int> numbers, int number)
        {
            // Sort the numbers DESC
            var sortedNumbers = numbers.OrderBy(i => i);

            var leftElement = 0;
            var rightElement = sortedNumbers.Count() - 1;

            while (leftElement < rightElement)
            {
                var firstNumber = sortedNumbers.Skip(leftElement).Take(1).First();
                var secondNumber = sortedNumbers.Skip(rightElement).Take(1).First();
                var sum = firstNumber + secondNumber;

                if (sum == number)
                {
                    return true;
                }

                if (sum < number)
                {
                    leftElement++;
                }
                else
                {
                    rightElement--;
                }
            }


            return false;
        }
    }
}
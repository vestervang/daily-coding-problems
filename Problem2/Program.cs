using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] {10, 3, 5, 6, 2};

            var products = findProduct(numbers);

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        private static IEnumerable<int> findProduct(IEnumerable<int> numbers)
        {
            var enumerable = numbers as int[] ?? numbers.ToArray();
            var result = new int[enumerable.Length];

            for (var i = 0; i < enumerable.Length; i++)
            {
                var product = enumerable.Where((t, j) => i != j).Aggregate(1, (current, t) => current * t);

                result[i] = product;
            }

            return result;
        }
    }
}
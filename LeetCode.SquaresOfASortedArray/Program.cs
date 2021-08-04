using System;
using System.Linq;

namespace LeetCode.SquaresOfASortedArray
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { -4, -1, 0, 3, 10 };

            foreach (int number in SortedSquares_ExampleOne(numbers))
            {
                Console.WriteLine(number);
            }

            Console.WriteLine(new string('-', 50));

            foreach (int number in SortedSquares_ExampleTwo(numbers))
            {
                Console.WriteLine(number);
            }
        }

        public static int[] SortedSquares_ExampleOne(int[] numbers)
        {
            return numbers.Select(x => (int) Math.Pow(Math.Abs(x), 2)).OrderBy(x => x).ToArray();
        }

        public static int[] SortedSquares_ExampleTwo(int[] numbers)
        {
            var finalSpan = new Span<int>(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                finalSpan[i] = (int) Math.Pow(Math.Abs(numbers[i]), 2);
            }

            finalSpan.Sort();

            return finalSpan.ToArray();
        }
    }
}

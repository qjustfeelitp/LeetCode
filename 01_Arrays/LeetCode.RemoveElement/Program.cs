using System;
using System.Linq;

namespace LeetCode.RemoveElement
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int[]     numbers = { 0, 1, 2, 2, 3, 0, 4, 2 };
            const int value   = 2;

            int result = RemoveElement(numbers, value);

            Console.WriteLine(result);
            Console.WriteLine(new string('-', 50));

            foreach (int number in numbers)
            {
                Console.Write(number);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }

        public static int RemoveElement(int[] numbers, int val)
        {
            int numberOfDeletions = numbers.Count(x => x == val);

            Array.Sort(numbers, (i, i1) =>
            {
                if (i == val)
                {
                    return 1;
                }

                if (i1 == val)
                {
                    return -1;
                }

                return default;
            });

            return numbers.Length - numberOfDeletions;
        }
    }
}

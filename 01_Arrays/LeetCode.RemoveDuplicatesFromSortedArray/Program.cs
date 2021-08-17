using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.RemoveDuplicatesFromSortedArray
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int   result  = RemoveDuplicates(numbers);

            Console.WriteLine(result);
            Console.WriteLine(new string('-', 50));

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }

        public static int RemoveDuplicates(int[] numbers)
        {
            int[] fromHashSet = new HashSet<int>(numbers).ToArray();

            Array.Copy(fromHashSet, numbers, fromHashSet.Length);

            return fromHashSet.Length;
        }
    }
}

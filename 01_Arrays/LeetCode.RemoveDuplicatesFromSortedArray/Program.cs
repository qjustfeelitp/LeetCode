using System;

namespace LeetCode.RemoveDuplicatesFromSortedArray
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int[] nums   = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int   result = RemoveDuplicates(nums);

            Console.WriteLine(result);
            Console.WriteLine(new string('-', 50));

            foreach (int number in nums)
            {
                Console.Write(number);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Hello World!");
        }

        public static int RemoveDuplicates(int[] nums)
        {
            return default;
        }
    }
}

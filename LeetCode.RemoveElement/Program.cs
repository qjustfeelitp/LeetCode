using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.RemoveElement
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = { 0, 1, 2, 2, 3, 0, 4, 2 };
            int   val  = 2;

            int result = RemoveElement(nums, val);

            Console.WriteLine(result);
            Console.WriteLine(new string('-', 50));

            foreach (int number in nums)
            {
                Console.Write(number);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }

        public static int RemoveElement(int[] nums, int val)
        {
            int numberOfDeletions = nums.Count(x => x == val);

            Array.Sort(nums, Comparer<int>.Create((i, i1) =>
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
            }));

            Array.Resize(ref nums, nums.Length - numberOfDeletions);

            return nums.Length;
        }
    }
}

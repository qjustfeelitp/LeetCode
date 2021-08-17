using System;

namespace LeetCode.MergeSortedArray
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int[] nums1 = { 1, 2, 3, 0, 0, 0 },
                  nums2 = { 2, 5, 6 };
            int m = 3,
                n = 3;

            Merge_ExampleOne(nums1, m, nums2, n);

            foreach (int number in nums1)
            {
                Console.Write(number);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));

            int[] secondNums = { 1, 2, 3, 0, 0, 0 };

            Merge_ExampleTwo(secondNums, m, nums2, n);

            foreach (int number in secondNums)
            {
                Console.Write(number);
            }
        }

        public static void Merge_ExampleOne(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = 0,
                     j = m;
                i < n;
                i++, j++)
            {
                nums1[j] = nums2[i];
            }

            Array.Sort(nums1);
        }

        public static void Merge_ExampleTwo(int[] nums1, int m, int[] nums2, int n)
        {
            Array.Copy(nums2, 0, nums1, m, n);
            Array.Sort(nums1);
        }
    }
}

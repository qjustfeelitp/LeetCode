using System;

namespace LeetCode.MergeSortedArray
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int[] firstNumbers  = { 1, 2, 3, 0, 0, 0 },
                  secondNumbers = { 2, 5, 6 };

            const int m = 3;
            const int n = 3;

            Merge_ExampleOne(firstNumbers, m, secondNumbers, n);

            foreach (int number in firstNumbers)
            {
                Console.Write(number);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));

            int[] newFirstNumbers = { 1, 2, 3, 0, 0, 0 };

            Merge_ExampleTwo(newFirstNumbers, m, secondNumbers, n);

            foreach (int number in newFirstNumbers)
            {
                Console.Write(number);
            }
        }

        public static void Merge_ExampleOne(int[] firstNumbers, int m, int[] secondNumbers, int n)
        {
            for (int i = 0,
                     j = m;
                i < n;
                i++, j++)
            {
                firstNumbers[j] = secondNumbers[i];
            }

            Array.Sort(firstNumbers);
        }

        public static void Merge_ExampleTwo(int[] firstNumbers, int m, int[] secondNumbers, int n)
        {
            Array.Copy(secondNumbers, 0, firstNumbers, m, n);
            Array.Sort(firstNumbers);
        }
    }
}

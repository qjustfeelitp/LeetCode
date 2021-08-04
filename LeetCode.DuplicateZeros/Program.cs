using System;
using System.Linq;

namespace LeetCode.DuplicateZeros
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 1, 0, 2, 3, 0, 4, 5, 0 };

            DuplicateZeros_ExampleOne(numbers);

            foreach (int number in numbers)
            {
                Console.Write(number);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));

            int[] secondNumbers = { 1, 0, 2, 3, 0, 4, 5, 0 };

            DuplicateZeros_ExampleTwo(secondNumbers);

            foreach (int number in secondNumbers)
            {
                Console.Write(number);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));

            int[] thirdNumbers = { 1, 0, 2, 3, 0, 4, 5, 0 };

            DuplicateZeros_ExampleThree(thirdNumbers);

            foreach (int number in thirdNumbers)
            {
                Console.Write(number);
            }
        }

        public static void DuplicateZeros_ExampleOne(int[] arr)
        {
            int[] filteredIndices = arr.Select((number, index) => new { num = number, index })
                                       .Where(x => x.num == 0)
                                       .Select(x => x.index)
                                       .OrderByDescending(x => x)
                                       .ToArray();

            if (filteredIndices.Length == 0)
            {
                return;
            }

            foreach (int index in filteredIndices)
            {
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if ((i >= index) && (i != (arr.Length - 1)))
                    {
                        arr[i + 1] = arr[i];
                    }
                }

                arr[index] = 0;
            }
        }

        public static void DuplicateZeros_ExampleTwo(int[] arr)
        {
            for (int outer = arr.Length - 1; outer >= 0; outer--)
            {
                if ((arr[outer] != 0) || (outer == (arr.Length - 1)))
                {
                    continue;
                }

                for (int inner = arr.Length - 1; inner >= 0; inner--)
                {
                    if ((inner >= outer) && (inner != (arr.Length - 1)))
                    {
                        arr[inner + 1] = arr[inner];
                    }
                }
            }
        }

        public static void DuplicateZeros_ExampleThree(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    continue;
                }

                for (int j = arr.Length - 1; j > i; j--)
                {
                    arr[j] = arr[j - 1];
                }

                i++;
            }
        }
    }
}

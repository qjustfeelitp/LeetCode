using System;
using System.Collections.Generic;
using System.Linq;

using BenchmarkDotNet.Attributes;
#if !DEBUG
using BenchmarkDotNet.Running;

#endif

namespace LeetCode.DuplicateZeros
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Runner.RunAll();

#if !DEBUG
            BenchmarkRunner.Run<Runner>();
#endif
        }
    }

    [MemoryDiagnoser]
    public class Runner
    {
        private readonly int[] benchmarkNumbers = { 1, 0, 2, 3, 0, 4, 5, 0 };

        public static void RunAll()
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

            Console.WriteLine();
        }

        [Benchmark]
        public void Run_ExampleOne()
        {
            DuplicateZeros_ExampleOne(this.benchmarkNumbers);
        }

        private static void DuplicateZeros_ExampleOne(IList<int> arr)
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
                for (int i = arr.Count - 1; i >= 0; i--)
                {
                    if ((i >= index) && (i != (arr.Count - 1)))
                    {
                        arr[i + 1] = arr[i];
                    }
                }

                arr[index] = 0;
            }
        }

        [Benchmark]
        public void Run_ExampleTwo()
        {
            DuplicateZeros_ExampleTwo(this.benchmarkNumbers);
        }

        private static void DuplicateZeros_ExampleTwo(IList<int> arr)
        {
            for (int outer = arr.Count - 1; outer >= 0; outer--)
            {
                if ((arr[outer] != 0) || (outer == (arr.Count - 1)))
                {
                    continue;
                }

                for (int inner = arr.Count - 1; inner >= 0; inner--)
                {
                    if ((inner >= outer) && (inner != (arr.Count - 1)))
                    {
                        arr[inner + 1] = arr[inner];
                    }
                }
            }
        }

        [Benchmark]
        public void Run_ExampleThree()
        {
            DuplicateZeros_ExampleThree(this.benchmarkNumbers);
        }

        private static void DuplicateZeros_ExampleThree(IList<int> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] != 0)
                {
                    continue;
                }

                for (int j = arr.Count - 1; j > i; j--)
                {
                    arr[j] = arr[j - 1];
                }

                i++;
            }
        }
    }
}

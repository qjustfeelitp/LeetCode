using System;
using System.Collections.Generic;
using System.Linq;

using BenchmarkDotNet.Attributes;
#if !DEBUG
using BenchmarkDotNet.Running;

#endif

namespace LeetCode.RemoveDuplicatesFromSortedArray
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
        private readonly int[] benchmarkNumbers = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

        public static void RunAll()
        {
            RunExample(RemoveDuplicates_ExampleOne);
            RunExample(RemoveDuplicates_ExampleTwo);
        }

        private static void RunExample(Func<int[], int> removeDuplicatesFunc)
        {
            int[] numbers = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int   result  = removeDuplicatesFunc(numbers);

            Console.WriteLine(result);
            Console.WriteLine(new string('-', 50));

            foreach (int number in numbers)
            {
                Console.Write(number + ", ");
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }

        [Benchmark]
        public int Run_ExampleOne()
        {
            return RemoveDuplicates_ExampleOne(this.benchmarkNumbers.ToArray());
        }

        private static int RemoveDuplicates_ExampleOne(int[] numbers)
        {
            int[] fromHashSet = new HashSet<int>(numbers).ToArray();

            Array.Copy(fromHashSet, numbers, fromHashSet.Length);

            return fromHashSet.Length;
        }

        [Benchmark]
        public int Run_ExampleTwo()
        {
            return RemoveDuplicates_ExampleTwo(this.benchmarkNumbers.ToArray());
        }

        private static int RemoveDuplicates_ExampleTwo(int[] numbers)
        {
            int size = numbers.Length;
            if (size == 0)
            {
                return 0;
            }

            int i = 0;
            for (int j = 1; j < size; j++)
            {
                if (numbers[j] == numbers[i])
                {
                    continue;
                }

                i++;
                numbers[i] = numbers[j];
            }

            return i + 1;
        }
    }
}

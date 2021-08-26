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

        [Benchmark]
        public int Run_RemoveDuplicates()
        {
            return RemoveDuplicates(this.benchmarkNumbers);
        }

        private static int RemoveDuplicates(int[] numbers)
        {
            int[] fromHashSet = new HashSet<int>(numbers).ToArray();

            Array.Copy(fromHashSet, numbers, fromHashSet.Length);

            return fromHashSet.Length;
        }
    }
}

using System;
using System.Linq;

using BenchmarkDotNet.Attributes;
#if !DEBUG
using BenchmarkDotNet.Running;

#endif

namespace LeetCode.RemoveElement
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
        private readonly int[] benchmarkNumbers = { 0, 1, 2, 2, 3, 0, 4, 2 };
        private const int Value = 2;

        public static void RunAll()
        {
            int[]     numbers = { 0, 1, 2, 2, 3, 0, 4, 2 };

            int result = RemoveElement(numbers, Value);

            Console.WriteLine(result);
            Console.WriteLine(new string('-', 50));

            foreach (int number in numbers)
            {
                Console.Write(number);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }

        [Benchmark]
        public int Run_RemoveDuplicates()
        {
            return RemoveElement(this.benchmarkNumbers, Value);
        }

        private static int RemoveElement(int[] numbers, int val)
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

using System;
using System.Collections.Generic;
using System.Linq;

using BenchmarkDotNet.Attributes;
#if !DEBUG
using BenchmarkDotNet.Running;

#endif

namespace LeetCode.SquaresOfASortedArray
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
        private readonly int[] benchmarkNumbers = { -4, -1, 0, 3, 10 };

        public static void RunAll()
        {
            int[] numbers = { -4, -1, 0, 3, 10 };

            foreach (int number in SortedSquares_ExampleOne(numbers))
            {
                Console.WriteLine(number);
            }

            Console.WriteLine(new string('-', 50));

            foreach (int number in SortedSquares_ExampleTwo(numbers))
            {
                Console.WriteLine(number);
            }
        }

        [Benchmark]
        public int[] Run_ExampleOne()
        {
            return SortedSquares_ExampleOne(this.benchmarkNumbers.ToArray());
        }

        private static int[] SortedSquares_ExampleOne(IEnumerable<int> numbers)
        {
            return numbers.Select(x => (int) Math.Pow(Math.Abs(x), 2)).OrderBy(x => x).ToArray();
        }

        [Benchmark]
        public int[] Run_ExampleTwo()
        {
            return SortedSquares_ExampleTwo(this.benchmarkNumbers.ToArray());
        }

        private static int[] SortedSquares_ExampleTwo(int[] numbers)
        {
            var finalSpan = numbers.AsSpan();

            for (int i = 0; i < numbers.Length; i++)
            {
                finalSpan[i] = (int) Math.Pow(Math.Abs(numbers[i]), 2);
            }

            finalSpan.Sort();

            return finalSpan.ToArray();
        }
    }
}

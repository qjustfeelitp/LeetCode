using System;
using System.Collections.Generic;
using System.Linq;

using BenchmarkDotNet.Attributes;
#if !DEBUG
using BenchmarkDotNet.Running;

#endif

namespace LeetCode.FindEvenNumbersWithEvenNumberOfDigits
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
        private readonly int[] benchmarkNumbers = { 12, 345, 2, 6, 7896 };

        public static void RunAll()
        {
            int[] numbers = { 12, 345, 2, 6, 7896 };
            int   result1 = FindNumbers_ExampleOne(numbers);
            int   result2 = FindNumbers_ExampleTwo(numbers);

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }

        [Benchmark]
        public int Run_ExampleOne()
        {
            return FindNumbers_ExampleOne(this.benchmarkNumbers);
        }

        private static int FindNumbers_ExampleOne(IEnumerable<int> numbers)
        {
            return numbers.Select(x => x.ToString()).Count(x => (x.Length % 2) == 0);
        }

        [Benchmark]
        public int Run_ExampleTwo()
        {
            return FindNumbers_ExampleTwo(this.benchmarkNumbers);
        }

        private static int FindNumbers_ExampleTwo(int[] numbers)
        {
            var asSpan = numbers.AsSpan();
            int count  = 0;

            foreach (int number in asSpan)
            {
                var numberAsSpanOfChars = new Span<char>(number.ToString().ToCharArray());
                if ((numberAsSpanOfChars.Length % 2) == 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}

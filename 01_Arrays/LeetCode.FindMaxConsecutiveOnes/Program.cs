using System;
using System.Collections.Generic;
using System.Linq;

using BenchmarkDotNet.Attributes;
#if !DEBUG
using BenchmarkDotNet.Running;

#endif

namespace LeetCode.FindMaxConsecutiveOnes
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
        private readonly int[] benchmarkNumbers = { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1 };

        public static void RunAll()
        {
            int[] numbers = { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1 };
            int   result1 = FindMaxConsecutiveOnes_ExampleOne(numbers);
            int   result2 = FindMaxConsecutiveOnes_ExampleTwo(numbers);

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }

        [Benchmark]
        public int Run_ExampleOne()
        {
            return FindMaxConsecutiveOnes_ExampleOne(this.benchmarkNumbers);
        }

        private static int FindMaxConsecutiveOnes_ExampleOne(IEnumerable<int> numbers)
        {
            var projectedValues = numbers.Select((number, index) => new { number, index })
                                         .Where(x => x.number == 1)
                                         .ToArray();

            switch (projectedValues.Length)
            {
                case 0:
                    return 0;

                case 1:
                    return 1;
            }

            var list = new List<int>();
            int a    = 1;

            for (int i = 0,
                     j = 1;
                j < projectedValues.Length;
                i++, j++)
            {
                if ((projectedValues[i].index + 1) == projectedValues[j].index)
                {
                    a++;
                }
                else
                {
                    a = 1;
                }

                list.Add(a);
            }

            return list.Max();
        }

        [Benchmark]
        public int Run_ExampleTwo()
        {
            return FindMaxConsecutiveOnes_ExampleTwo(this.benchmarkNumbers);
        }

        private static int FindMaxConsecutiveOnes_ExampleTwo(IEnumerable<int> numbers)
        {
            int count  = 0;
            int result = 0;

            foreach (int number in numbers)
            {
                if (number == 0)
                {
                    count = 0;
                }
                else
                {
                    count++;
                    result = Math.Max(result, count);
                }
            }

            return result;
        }
    }
}

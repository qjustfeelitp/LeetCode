using System;
using System.Collections.Immutable;
using System.Linq;

using BenchmarkDotNet.Attributes;
#if !DEBUG
using BenchmarkDotNet.Running;

#endif

namespace LeetCode.ThirdMax
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
        private readonly int[] benchmarkNumbers = { 2, 2, 3, 1 };

        public static void RunAll()
        {
            RunExample(ThirdMax_ExampleOne);
            RunExample(ThirdMax_ExampleTwo);
            RunExample(ThirdMax_ExampleThree);
        }

        private static void RunExample(Func<int[], int> thirdMaxFunc)
        {
            int[] numbers = { 1, 2, 2, 5, 3, 5 };

            int result = thirdMaxFunc(numbers);

            Console.WriteLine(result);
            Console.WriteLine(new string('-', 50));
        }

        [Benchmark]
        public int Run_ExampleOne()
        {
            return ThirdMax_ExampleOne(this.benchmarkNumbers.ToArray());
        }

        private static int ThirdMax_ExampleOne(int[] numbers)
        {
            if (numbers.Length < 3)
            {
                return numbers.Max();
            }

            var hashSet = numbers.ToImmutableSortedSet();

            return hashSet.Count < 3
                ? hashSet.Max
                : hashSet[^3];
        }

        [Benchmark]
        public int Run_ExampleTwo()
        {
            return ThirdMax_ExampleTwo(this.benchmarkNumbers.ToArray());
        }

        private static int ThirdMax_ExampleTwo(int[] numbers)
        {
            if (numbers.Length < 3)
            {
                return numbers.Max();
            }

            Array.Sort(numbers);

            int[] distinctNumbers = numbers.Distinct().ToArray();

            return distinctNumbers.Length < 3
                ? distinctNumbers.Max()
                : distinctNumbers[^3];
        }

        [Benchmark]
        public int Run_ExampleThree()
        {
            return ThirdMax_ExampleThree(this.benchmarkNumbers.ToArray());
        }

        private static int ThirdMax_ExampleThree(int[] numbers)
        {
            int? max       = null;
            int? secondMax = null;
            int? thirdMax  = null;

            foreach (int number in numbers)
            {
                if ((max == number) || (secondMax == number) || (thirdMax == number))
                {
                    continue;
                }

                if (!max.HasValue || (max < number))
                {
                    thirdMax  = secondMax;
                    secondMax = max;
                    max       = number;
                }
                else if (!secondMax.HasValue || (secondMax < number))
                {
                    thirdMax  = secondMax;
                    secondMax = number;
                }
                else if (!thirdMax.HasValue || (thirdMax < number))
                {
                    thirdMax = number;
                }
            }

            thirdMax ??= max;

            return thirdMax!.Value;
        }
    }
}

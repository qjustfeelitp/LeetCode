using System;
using System.Linq;

using BenchmarkDotNet.Attributes;
#if !DEBUG
using BenchmarkDotNet.Running;

#endif

namespace LeetCode.HeightChecker
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
        private readonly int[] benchmarkNumbers = { 1, 1, 4, 2, 1, 3 };

        public static void RunAll()
        {
            RunExample(HeightChecker_ExampleOne);
            RunExample(HeightChecker_ExampleTwo);
            RunExample(HeightChecker_ExampleThree);
            RunExample(HeightChecker_ExampleFour);
        }

        private static void RunExample(Func<int[], int> heightCheckerFunc)
        {
            int[] numbers = { 1, 1, 4, 2, 1, 3 };

            int result = heightCheckerFunc(numbers);

            Console.WriteLine(result);
            Console.WriteLine(new string('-', 50));
        }

        [Benchmark]
        public int Run_ExampleOne()
        {
            return HeightChecker_ExampleOne(this.benchmarkNumbers.ToArray());
        }

        private static int HeightChecker_ExampleOne(int[] heights)
        {
            int[] original = heights.ToArray();

            Array.Sort(heights);

            int numberOfNotCorrespondingValues = default;

            for (int i = 0; i < heights.Length; i++)
            {
                if (heights[i] != original[i])
                {
                    numberOfNotCorrespondingValues++;
                }
            }

            return numberOfNotCorrespondingValues;
        }

        [Benchmark]
        public int Run_ExampleTwo()
        {
            return HeightChecker_ExampleTwo(this.benchmarkNumbers.ToArray());
        }

        private static int HeightChecker_ExampleTwo(int[] heights)
        {
            int[] original = heights.ToArray();

            Array.Sort(heights);

            return heights.Where((t, i) => t != original[i]).Count();
        }

        [Benchmark]
        public int Run_ExampleThree()
        {
            return HeightChecker_ExampleThree(this.benchmarkNumbers.ToArray());
        }

        private static int HeightChecker_ExampleThree(int[] heights)
        {
            var original = heights.AsSpan();
            var expected = heights.ToArray().AsSpan();

            expected.Sort();

            int numberOfNotCorrespondingValues = default;

            for (int i = 0; i < expected.Length; i++)
            {
                if (original[i] != expected[i])
                {
                    numberOfNotCorrespondingValues++;
                }
            }

            return numberOfNotCorrespondingValues;
        }

        [Benchmark]
        public int Run_ExampleFour()
        {
            return HeightChecker_ExampleFour(this.benchmarkNumbers.ToArray());
        }

        private static int HeightChecker_ExampleFour(int[] heights)
        {
            return heights.OrderBy(x => x)
                          .Where((t, i) => t != heights[i])
                          .Count();
        }
    }
}

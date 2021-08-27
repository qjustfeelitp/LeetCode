using System;

using BenchmarkDotNet.Attributes;
#if !DEBUG
using BenchmarkDotNet.Running;

#endif

namespace LeetCode.ReplaceElementsWithGreatestElementOnRightSide
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
        private readonly int[] benchmarkNumbers = { 17, 18, 5, 4, 6, 1 };

        public static void RunAll()
        {
            RunExample(ReplaceElements_ExampleOne);
            RunExample(ReplaceElements_ExampleTwo);
            RunExample(ReplaceElements_ExampleThree);
            RunExample(ReplaceElements_ExampleFour);
        }

        private static void RunExample(Func<int[], int[]> getArrayFunc)
        {
            int[] numbers = { 17, 18, 5, 4, 6, 1 };

            foreach (int number in getArrayFunc(numbers))
            {
                Console.Write(number + ", ");
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }

        [Benchmark]
        public int[] Run_ExampleOne()
        {
            return ReplaceElements_ExampleOne(this.benchmarkNumbers);
        }

        private static int[] ReplaceElements_ExampleOne(int[] arr)
        {
            int currentMax = default;
            var finalSpan  = arr.AsSpan();
            int size       = finalSpan.Length;

            for (int i = size - 1; i >= 0; i--)
            {
                if (i == (size - 1))
                {
                    currentMax   = Math.Max(currentMax, finalSpan[i]);
                    finalSpan[i] = -1;
                    continue;
                }

                int currentValue = finalSpan[i];
                finalSpan[i] = currentMax;
                currentMax   = Math.Max(currentMax, currentValue);
            }

            return finalSpan.ToArray();
        }

        [Benchmark]
        public int[] Run_ExampleTwo()
        {
            return ReplaceElements_ExampleTwo(this.benchmarkNumbers);
        }

        private static int[] ReplaceElements_ExampleTwo(int[] arr)
        {
            int currentMax = default;
            int size       = arr.Length;

            for (int i = size - 1; i >= 0; i--)
            {
                if (i == (size - 1))
                {
                    currentMax = Math.Max(currentMax, arr[i]);
                    arr[i]     = -1;
                    continue;
                }

                int currentValue = arr[i];
                arr[i]     = currentMax;
                currentMax = Math.Max(currentMax, currentValue);
            }

            return arr;
        }

        [Benchmark]
        public int[] Run_ExampleThree()
        {
            return ReplaceElements_ExampleThree(this.benchmarkNumbers);
        }

        private static int[] ReplaceElements_ExampleThree(int[] arr)
        {
            int size = arr.Length;

            int currentMax = arr[size - 1];

            arr[size - 1] = -1;

            for (int i = size - 2; i >= 0; i--)
            {
                int currentValue = arr[i];

                arr[i] = currentMax;

                currentMax = Math.Max(currentMax, currentValue);
            }

            return arr;
        }

        [Benchmark]
        public int[] Run_ExampleFour()
        {
            return ReplaceElements_ExampleFour(this.benchmarkNumbers);
        }

        private static int[] ReplaceElements_ExampleFour(int[] arr)
        {
            var finalSpan = arr.AsSpan();
            int size      = finalSpan.Length;

            int currentMax = finalSpan[size - 1];

            finalSpan[size - 1] = -1;

            for (int i = size - 2; i >= 0; i--)
            {
                int currentValue = finalSpan[i];

                finalSpan[i] = currentMax;

                currentMax = Math.Max(currentMax, currentValue);
            }

            return finalSpan.ToArray();
        }
    }
}

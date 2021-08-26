using System;
using System.Collections.Generic;
using System.Linq;

using BenchmarkDotNet.Attributes;
#if !DEBUG
using BenchmarkDotNet.Running;

#endif

namespace LeetCode.CheckIfNAndItsDoubleExist
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
        private readonly int[] benchmarkNumbers = { -2, 0, 10, -19, 4, 6, -8 };

        public static void RunAll()
        {
            int[] numbers = { -2, 0, 10, -19, 4, 6, -8 };

            Console.WriteLine(CheckIfExist_ExampleOne(numbers));
            Console.WriteLine(new string('-', 50));

            Console.WriteLine(CheckIfExist_ExampleTwo(numbers));
            Console.WriteLine(new string('-', 50));

            Console.WriteLine(CheckIfExist_ExampleThree(numbers));
        }

        [Benchmark]
        public bool Run_ExampleOne()
        {
            return CheckIfExist_ExampleOne(this.benchmarkNumbers);
        }

        private static bool CheckIfExist_ExampleOne(IReadOnlyList<int> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < arr.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    int a = arr[i] * 2;

                    if (a == arr[j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        [Benchmark]
        public bool Run_ExampleTwo()
        {
            return CheckIfExist_ExampleTwo(this.benchmarkNumbers);
        }

        private static bool CheckIfExist_ExampleTwo(int[] arr)
        {
            return arr.Where((t1, i) => (from t in arr.Where((_, j) => i != j)
                                         let a = t1 * 2
                                         where a == t
                                         select t).Any())
                      .Any();
        }

        [Benchmark]
        public bool Run_ExampleThree()
        {
            return CheckIfExist_ExampleThree(this.benchmarkNumbers);
        }

        private static bool CheckIfExist_ExampleThree(int[] arr)
        {
            var asSpan = arr.AsSpan();

            asSpan.Sort();

            for (int i = 0; i < asSpan.Length; i++)
            {
                int binarySearchIndex = asSpan.BinarySearch(asSpan[i] * 2);
                if ((binarySearchIndex >= 0) && (binarySearchIndex != i))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

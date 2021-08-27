using System;
using System.Collections.Generic;
using System.Linq;

using BenchmarkDotNet.Attributes;
#if !DEBUG
using BenchmarkDotNet.Running;

#endif

namespace LeetCode.MergeSortedArray
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
        private readonly int[] benchmarkFirstNumbers = { 1, 2, 3, 0, 0, 0 };
        private readonly int[] benchmarkSecondNumbers = { 2, 5, 6 };

        private const int M = 3;
        private const int N = 3;

        public static void RunAll()
        {
            int[] firstNumbers  = { 1, 2, 3, 0, 0, 0 },
                  secondNumbers = { 2, 5, 6 };

            const int m = 3;
            const int n = 3;

            Merge_ExampleOne(firstNumbers, m, secondNumbers, n);

            foreach (int number in firstNumbers)
            {
                Console.Write(number);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));

            int[] newFirstNumbers = { 1, 2, 3, 0, 0, 0 };

            Merge_ExampleTwo(newFirstNumbers, m, secondNumbers, n);

            foreach (int number in newFirstNumbers)
            {
                Console.Write(number);
            }

            Console.WriteLine();
        }

        [Benchmark]
        public void Run_ExampleOne()
        {
            Merge_ExampleOne(this.benchmarkFirstNumbers.ToArray(), M, this.benchmarkSecondNumbers.ToArray(), N);
        }

        private static void Merge_ExampleOne(int[] firstNumbers, int m, IReadOnlyList<int> secondNumbers, int n)
        {
            for (int i = 0,
                     j = m;
                i < n;
                i++, j++)
            {
                firstNumbers[j] = secondNumbers[i];
            }

            Array.Sort(firstNumbers);
        }

        [Benchmark]
        public void Run_ExampleTwo()
        {
            Merge_ExampleTwo(this.benchmarkFirstNumbers.ToArray(), M, this.benchmarkSecondNumbers.ToArray(), N);
        }

        private static void Merge_ExampleTwo(int[] firstNumbers, int m, int[] secondNumbers, int n)
        {
            Array.Copy(secondNumbers, 0, firstNumbers, m, n);
            Array.Sort(firstNumbers);
        }
    }
}

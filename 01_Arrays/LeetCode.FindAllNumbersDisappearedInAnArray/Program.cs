using System;
using System.Collections.Generic;
using System.Linq;

using BenchmarkDotNet.Attributes;
#if !DEBUG
using BenchmarkDotNet.Running;

#endif

namespace LeetCode.FindAllNumbersDisappearedInAnArray
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
        private readonly int[] benchmarkNumbers = { 4, 3, 2, 7, 8, 2, 3, 1 };

        public static void RunAll()
        {
            RunExample(FindDisappearedNumbers_ExampleOne);
            RunExample(FindDisappearedNumbers_ExampleTwo);
        }

        private static void RunExample(Func<int[], IList<int>> findDisappearedNumbersFunc)
        {
            int[] numbers = { 4, 3, 2, 7, 8, 2, 3, 1 };

            foreach (int number in findDisappearedNumbersFunc(numbers))
            {
                Console.Write(number + ", ");
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }

        [Benchmark]
        public IList<int> Run_ExampleOne()
        {
            return FindDisappearedNumbers_ExampleOne(this.benchmarkNumbers.ToArray());
        }

        private static IList<int> FindDisappearedNumbers_ExampleOne(int[] numbers)
        {
            var disappearedNumberList = Enumerable.Range(1, numbers.Length).ToList();

            foreach (int number in numbers.ToHashSet())
            {
                disappearedNumberList.RemoveAll(i => i == number);
            }

            return disappearedNumberList;
        }

        [Benchmark]
        public IList<int> Run_ExampleTwo()
        {
            return FindDisappearedNumbers_ExampleTwo(this.benchmarkNumbers.ToArray());
        }

        private static IList<int> FindDisappearedNumbers_ExampleTwo(int[] numbers)
        {
            var hashset = new HashSet<int>(numbers);

            var result = new List<int>();

            for (int i = 1; i <= numbers.Length; i++)
            {
                if (!hashset.Contains(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}

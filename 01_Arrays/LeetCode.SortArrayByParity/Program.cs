using System;
using System.Linq;

using BenchmarkDotNet.Attributes;
#if !DEBUG
using BenchmarkDotNet.Running;

#endif

namespace LeetCode.SortArrayByParity
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
        private readonly int[] benchmarkNumbers = { 3, 1, 2, 4 };

        public static void RunAll()
        {
            RunExample(SortArrayByParity_ExampleOne);
            RunExample(SortArrayByParity_ExampleTwo);
            RunExample(SortArrayByParity_ExampleThree);
        }

        private static void RunExample(Func<int[], int[]> moveZeroesFunc)
        {
            int[] numbers = { 3, 1, 2, 4 };

            int[] resultNumbers = moveZeroesFunc(numbers);

            foreach (int number in resultNumbers)
            {
                Console.Write(number + ", ");
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }

        [Benchmark]
        public int[] Run_ExampleOne()
        {
            return SortArrayByParity_ExampleOne(this.benchmarkNumbers.ToArray());
        }

        private static int[] SortArrayByParity_ExampleOne(int[] numbers)
        {
            int slowPointer = 0;

            for (int fastPointer = 0; fastPointer < numbers.Length; fastPointer++)
            {
                if ((numbers[fastPointer] % 2) != 0)
                {
                    continue;
                }

                (numbers[slowPointer], numbers[fastPointer]) = (numbers[fastPointer], numbers[slowPointer]);
                slowPointer++;
            }

            return numbers;
        }

        [Benchmark]
        public int[] Run_ExampleTwo()
        {
            return SortArrayByParity_ExampleTwo(this.benchmarkNumbers.ToArray());
        }

        private static int[] SortArrayByParity_ExampleTwo(int[] numbers)
        {
            Array.Sort(numbers, (value1, value2) =>
            {
                bool even1 = (value1 % 2) == 0;
                bool even2 = (value2 % 2) == 0;

                return even1 switch
                {
                    true when !even2 => -1,
                    false when even2 => 1,
                    true             => -value1.CompareTo(value2),
                    _                => value1.CompareTo(value2)
                };
            });

            return numbers;
        }

        [Benchmark]
        public int[] Run_ExampleThree()
        {
            return SortArrayByParity_ExampleThree(this.benchmarkNumbers.ToArray());
        }

        private static int[] SortArrayByParity_ExampleThree(int[] numbers)
        {
            return numbers.OrderByDescending(x => (x % 2) == 0).ToArray();
        }
    }
}

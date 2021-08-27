﻿using System;
using System.Collections.Generic;
using System.Linq;

using BenchmarkDotNet.Attributes;
#if !DEBUG
using BenchmarkDotNet.Running;

#endif

namespace LeetCode.MoveZeroes
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
        private readonly int[] benchmarkNumbers =
        {
            -959151711, 623836953, 209446690, -1950418142, 1339915067, -733626417, 481171539, -2125997010, -1225423476, 1462109565, 147434687, -1800073781, -1431212205, -450443973, 50097298,
            753533734, -747189404, -2070885638, 0, -1484353894, -340296594, -2133744570, 619639811, -1626162038, 669689561, 0, 112220218, 502447212, -787793179, 0, -726846372, -1611013491, 204107194,
            1605165582, -566891128, 2082852116, 0, 532995238, -1502590712, 0, 2136989777, -2031153343, 371398938, -1907397429, 342796391, 609166045, -2007448660, -1096076344, -323570318, 0,
            -2082980371, 2129956379, -243553361, -1549960929, 1502383415, 0, -1394618779, 694799815, 78595689, -1439173023, -1416578800, 685225786, -333502212, -1181308536, -380569313, 772035354, 0,
            -915266376, 663709718, 1443496021, -777017729, -883300731, -387828385, 1907473488, -725483724, -972961871, -1255712537, 383120918, 1383877998, 1722751914, 0, -1156050682, 1952527902,
            -560244497, 1304305692, 1173974542, -1313227247, -201476579, -298899493, -1828496581, -1724396350, 1933643204, 1531804925, 1728655262, -955565449, 0, -69843702, -461760848, 268336768,
            1446130876
        };

        public static void RunAll()
        {
            RunExample(MoveZeroes_ExampleOne);
            RunExample(MoveZeroes_ExampleTwo);
        }

        private static void RunExample(Action<int[]> moveZeroesFunc)
        {
            int[] numbers = { 0, 1, 0, 3, 12 };

            moveZeroesFunc(numbers);

            foreach (int number in numbers)
            {
                Console.Write(number + ", ");
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }

        [Benchmark]
        public void Run_ExampleOne()
        {
            MoveZeroes_ExampleOne(this.benchmarkNumbers.ToArray());
        }

        private static void MoveZeroes_ExampleOne(IList<int> numbers)
        {
            for (int lastNonZeroFoundAt = 0,
                     current = 0;
                current < numbers.Count;
                current++)
            {
                if (numbers[current] == 0)
                {
                    continue;
                }

                (numbers[lastNonZeroFoundAt], numbers[current]) = (numbers[current], numbers[lastNonZeroFoundAt]);
                lastNonZeroFoundAt++;
            }
        }

        [Benchmark]
        public void Run_ExampleTwo()
        {
            MoveZeroes_ExampleTwo(this.benchmarkNumbers.ToArray());
        }

        private static void MoveZeroes_ExampleTwo(IList<int> numbers)
        {
            int slowPointer = 0;

            for (int fastPointer = 0; fastPointer < numbers.Count; fastPointer++)
            {
                if (numbers[fastPointer] == 0)
                {
                    continue;
                }

                (numbers[slowPointer], numbers[fastPointer]) = (numbers[fastPointer], numbers[slowPointer]);
                slowPointer++;
            }
        }
    }
}

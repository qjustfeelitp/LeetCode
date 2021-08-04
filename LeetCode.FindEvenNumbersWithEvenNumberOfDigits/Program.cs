using System;
using System.Linq;

namespace LeetCode.FindEvenNumbersWithEvenNumberOfDigits
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 12, 345, 2, 6, 7896 };
            int   result1 = FindNumbers_ExampleOne(numbers);
            int   result2 = FindNumbers_ExampleTwo(numbers);

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }

        public static int FindNumbers_ExampleOne(int[] numbers)
        {
            return numbers.Select(x => x.ToString()).Count(x => (x.Length % 2) == 0);
        }

        public static int FindNumbers_ExampleTwo(int[] numbers)
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

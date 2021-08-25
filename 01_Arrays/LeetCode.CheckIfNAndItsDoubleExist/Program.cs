using System;
using System.Linq;

namespace LeetCode.CheckIfNAndItsDoubleExist
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { -2, 0, 10, -19, 4, 6, -8 };

            Console.WriteLine(CheckIfExist_ExampleOne(numbers));
            Console.WriteLine(new string('-', 50));

            Console.WriteLine(CheckIfExist_ExampleTwo(numbers));
            Console.WriteLine(new string('-', 50));

            Console.WriteLine(CheckIfExist_ExampleThree(numbers));
        }

        public static bool CheckIfExist_ExampleOne(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
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

        public static bool CheckIfExist_ExampleTwo(int[] arr)
        {
            return arr.Where((t1, i) => (from t in arr.Where((_, j) => i != j)
                                         let a = t1 * 2
                                         where a == t
                                         select t).Any())
                      .Any();
        }

        public static bool CheckIfExist_ExampleThree(int[] arr)
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

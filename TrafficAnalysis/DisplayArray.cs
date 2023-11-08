using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficAnalysis
{
    class DisplayArray
    {
        public static void All(string arrayName, int[] array)
        {
            Console.WriteLine($"\n\nAll elements in {arrayName}:");

            foreach (int line in array)
            {
                Console.Write($"{line} ");
            }
        }

        public static void TenthElement(string arrayName, int[] array)
        {
            Console.WriteLine($"\n\nEvery 10th element in {arrayName}:");

            for (int i = 0; i < array.Length; i++)
            {
                if ((i + 1) % 10 == 0)     // if remainer of (i + 1) / 10 is 0, then we know the line we're on is a multiple of 10)
                {
                    Console.Write($"{array[i]} ");
                }
            }
        }

        public static void FiftiethElement(string arrayName, int[] array)
        {
            Console.WriteLine($"\n\nEvery 50th element in {arrayName}:");

            for (int i = 0; i < array.Length; i++)
            {
                if ((i + 1) % 50 == 0)     // if remainer of (i + 1) / 50 is 0, then we know the line we're on is a multiple of 50)
                {
                    Console.Write($"{array[i]} ");
                }
            }
        }
    }
}

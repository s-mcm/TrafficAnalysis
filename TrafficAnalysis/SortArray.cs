using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficAnalysis
{
    class SortArray
    {
        /* 
         * Sorts array using QuickSort algorithm. Sorts according to ascending order and returns the sorted array.
        */
        public static int iteration = 0;

        public static int[] QuicksortAscending(int[] numbers, int left, int right)
        {
            int x = left;
            int y = right;

            int pivot = numbers[(left + right) / 2];        // calcuates halfway point to begin shuffling numbers within the array
            iteration++;

            while (x <= y)      // runs when first item in array is less than or equal to last item in array
            {
                while (numbers[x] < pivot)      // sort for ascending
                {
                    x++;
                    iteration++;
                }

                while (numbers[y] > pivot)      // sort for ascending
                {
                    y--;
                    iteration++;
                }

                if (x <= y)
                {
                    int tmp = numbers[x];       // swaps items in array around to corret places 
                    numbers[x] = numbers[y];
                    numbers[y] = tmp;

                    x++;
                    y--;
                    iteration++;
                }
            }

            if (left < y)
            {
                QuicksortAscending(numbers, left, y);
            }

            if (x < right)
            {
                QuicksortAscending(numbers, x, right);
            }

            return numbers;     // returns sorted array
        }

        /* 
         * Sorts array using QuickSort algorithm. Sorts according to descending order and returns the sorted array.
        */
        public static int[] QuicksortDescending(int[] numbers, int left, int right)
        {
            int x = left;
            int y = right;

            int pivot = numbers[(left + right) / 2];

            while (x <= y)
            {
                while (numbers[x] > pivot)      // sort for descending
                {
                    x++;
                }

                while (numbers[y] < pivot)      // sort for descending
                {
                    y--;
                }

                if (x <= y)
                {
                    int tmp = numbers[x];
                    numbers[x] = numbers[y];
                    numbers[y] = tmp;

                    x++;
                    y--;
                }
            }

            if (left < y)
            {
                QuicksortDescending(numbers, left, y);
            }

            if (x < right)
            {
                QuicksortDescending(numbers, x, right);
            }

            return numbers;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficAnalysis
{
    class SearchArray
    {
        public static int iteration = 0;

        public static void BinarySearch(int[] array, int userValue)
        {
            int lowerIndex = 0;
            int higherIndex = array.Length;
            int arrayIndex;
            List<int> foundIndexValues = new List<int>();
            int offset = 0;

            while (true)
            {
                arrayIndex = (lowerIndex + higherIndex) / 2;

                iteration++;
                Console.WriteLine($"iteration ran {iteration}");

                if (array[arrayIndex] == userValue)       // if the user value is equal to the found value
                {
                    Console.WriteLine($"Correct value found: Value: {array[arrayIndex]} Index: {arrayIndex}");
                    break;
                }
                else if (array[arrayIndex] < userValue)     // if the user value is higher than found value
                {
                    lowerIndex = arrayIndex + 1;
                }
                else if (array[arrayIndex] > userValue)      // if the user value is lower than found value
                {
                    higherIndex = arrayIndex;
                }
                
                if (lowerIndex == higherIndex)      // if the ranges are the same then the user value does not exist
                {
                    Console.WriteLine("Given value did not exist. Finding the closest values:");
                    break;
                }
            }

            while (true)        // finds the lowest index with the correct user value
            {
                if (array[arrayIndex] != array[arrayIndex - offset - 1])        // if index below the current index also contains the correct user value
                {
                    // set arrayIndex to include offset. This allows us to store the lowest index of the correct user input
                    arrayIndex = arrayIndex - offset;
                    offset = 1;     // reset offset value
                    foundIndexValues.Add(arrayIndex);       // adds lowest index value to list (the one we just calculated)
                    break;
                }
                else
                {
                    // Increment the offset to allow for a search of the previous index value
                    offset += 1;
                }
                iteration++;
            }

            while (true)        // checks if there are any of the same user values with higher index numbers and adds them to the list
            {
                if (array[arrayIndex] != array[arrayIndex + offset])        // if current value is not equal to the next value 
                {
                    break;
                }
                else
                {
                    foundIndexValues.Add(arrayIndex + offset);
                    offset++;
                }
                iteration++;
            }

            Console.WriteLine($"\n\nGiven value {array[arrayIndex]} was found at:");
            for (int i = 0; i < foundIndexValues.Count; i++)
            {
                Console.WriteLine($"Index {foundIndexValues[i]}");
            }
        }
    }
}

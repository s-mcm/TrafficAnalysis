using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TrafficAnalysis
{
    class Menu
    {
        public void CallMenu()
        {
            int low = 1;
            int high = 6;
            int userInput = 0;
            bool continueLoop = true;

            while (continueLoop)
            {
                Console.WriteLine($"Which road would you like to display?" +
                    $"\n1 = Road 1" +
                    $"\n2 = Road 2" +
                    $"\n3 = Road 3" +
                    $"\n4 = Road 1 (small, 256) merged with Road 3 (small, 256)" +
                    $"\n5 = Merge all road files (small and large)" +
                    $"\n6 = Exit program" +
                    $"\nEnter between {low} and {high - 1}, or press {high} to exit:");
                userInput = ValidateInput(low, high);

                if (userInput < high - 2)       // if less than high - 1 then user does not want to exit program or use the merged functions
                {
                    WhatSizeRoad(userInput);
                }
                else if (userInput == high - 2 || userInput == high - 1)
                {
                    switch (userInput)
                    {
                        case 4:
                            int[] road1 = FileReader.ReadFileInt($"Road_1_256.txt");
                            int[] road3 = FileReader.ReadFileInt($"Road_3_256.txt");
                            int[] combined = new int[road1.Length + road3.Length];
                            combined = road1.Concat(road3).ToArray();
                            WhatShouldDisplay(combined);
                            break;
                        case 5:
                            int[] road1Small = FileReader.ReadFileInt($"Road_1_256.txt");
                            int[] road2Small = FileReader.ReadFileInt($"Road_1_256.txt");
                            int[] road3Small = FileReader.ReadFileInt($"Road_3_256.txt");
                            int[] road1Lrage = FileReader.ReadFileInt($"Road_1_2048.txt");
                            int[] road2Lrage = FileReader.ReadFileInt($"Road_1_2048.txt");
                            int[] road3Lrage = FileReader.ReadFileInt($"Road_3_2048.txt");
                            int[] allCombined = new int[road1Small.Length + road2Small.Length + road3Small.Length + road1Lrage.Length + road2Lrage.Length + road3Lrage.Length];
                            allCombined = road1Small.Concat(road2Small).Concat(road3Small).Concat(road1Lrage).Concat(road2Lrage).Concat(road3Lrage).ToArray();
                            WhatShouldDisplay(allCombined);
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }
                }
                else
                {
                    continueLoop = false;       // change to false to close the loop the menu is contained in
                }

                Console.WriteLine($"\n\nPress any key to return to contuine");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void WhatSizeRoad(int roadNumber)
        {
            Console.WriteLine($"\n\nWhat size road?" +
                $"\n1 = small (256)" +
                $"\n2 = large (2048)");
            int userInput = ValidateInput(1, 2);

            switch (userInput)
            {
                case 1:
                    int[] roadSmall = FileReader.ReadFileInt($"Road_{roadNumber}_256.txt");
                    WhatShouldDisplay(roadSmall);
                    break;
                case 2:
                    int[] roadLarge = FileReader.ReadFileInt($"Road_{roadNumber}_2048.txt");
                    WhatShouldDisplay(roadLarge);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        private void WhatShouldDisplay(int[] array)
        {
            Console.WriteLine($"\n\nWhat information would you like to see about the road?" +
                $"\n1 = Display in ascending order" +
                $"\n2 = Display in descending order" +
                $"\n3 = Display every 10th value within the road" +
                $"\n4 = Display every 50th value within the road" +
                $"\n5 = Search road for given value");
            int userInput = ValidateInput(1, 5);

            switch (userInput)
            {
                case 1:
                    array = SortArray.QuicksortAscending(array, 0, array.Length - 1);
                    Console.WriteLine($"Quicksort algorithm ran {SortArray.iteration} times!");
                    SortArray.iteration = 0; // reset iteration
                    DisplayArray.All("current road (ascending)", array);
                    break;
                case 2:
                    array = SortArray.QuicksortDescending(array, 0, array.Length - 1);
                    Console.WriteLine($"Quicksort algorithm ran {SortArray.iteration} times!");
                    SortArray.iteration = 0; // reset iteration
                    DisplayArray.All("current road (descending)", array);
                    break;
                case 3:
                    array = SortArray.QuicksortAscending(array, 0, array.Length - 1);
                    Console.WriteLine($"Quicksort algorithm ran {SortArray.iteration} times!");
                    SortArray.iteration = 0; // reset iteration
                    DisplayArray.TenthElement("current road (every 10th element)", array);
                    break;
                case 4:
                    array = SortArray.QuicksortAscending(array, 0, array.Length - 1);
                    Console.WriteLine($"Quicksort algorithm ran {SortArray.iteration} times!");
                    SortArray.iteration = 0; // reset iteration
                    DisplayArray.FiftiethElement("current road (every 50th element)", array);
                    break;
                case 5:
                    Console.WriteLine("\n\nEnter a value to beign search: ");
                    int input = ValidateInput(1, 999);
                    array = SortArray.QuicksortAscending(array, 0, array.Length - 1);
                    Console.WriteLine($"Quicksort algorithm ran {SortArray.iteration} times!");
                    SortArray.iteration = 0; // reset iteration
                    SearchArray.BinarySearch(array, input);
                    Console.WriteLine($"Binary Search algorithm ran {SearchArray.iteration} times!");
                    SearchArray.iteration = 0; // reset iteration
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        private int ValidateInput(int lowestOption, int highestOption)
        {
            int input = 0;

            // while loop used for error checking
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out input) && input >= lowestOption && input <= highestOption)        // returns true if the input was valid
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Error. Please enter a number between {lowestOption} and {highestOption}: ");
                }
            }

            return input;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class SortingProgram
    {
        public void DoSorting()
        {
            int lastStep = 0;
            do
            {
                // Numbers list
                List<int> numbers;
                int numCount = 0;

                // Keep asking for input
                while (true)
                {
                    //Console.Clear();
                    // Random or userinput for the numbers
                    Console.WriteLine("Do you want to generate random numbers or enter them manually?");
                    Console.WriteLine("1. Generate randomly");
                    Console.WriteLine("2. Enter manually");
                    Console.Write("Input: ");

                    // Check if input is number
                    int.TryParse(Console.ReadLine(), out int input);

                    // Randomly generated
                    if (input == 1)
                    {
                        while (true)
                        {
                            //Console.Clear();
                            Console.WriteLine("How many numbers do you want to generate?");
                            Console.Write("Input: ");
                            bool validInput = int.TryParse(Console.ReadLine(), out numCount);
                            // Break if input is valid
                            if (validInput) { break; }
                            Console.WriteLine("Invalid input. Re-enter the input.");
                        }

                        // Zufällige Zahlen generieren
                        Random rnd = new();
                        numbers = new List<int>();
                        for (int i = 0; i < numCount; i++)
                        {
                            numbers.Add(rnd.Next(1, 10001));
                        }
                        break;
                    }
                    // Custom user numbers
                    else if (input == 2)
                    {
                        while (true)
                        {
                            //Console.Clear();
                            Console.WriteLine("Enter your desired numbers seperated by spaces: ");
                            string inputNumbers = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(inputNumbers))
                            {
                                Console.WriteLine("No numbers provided. Re-enter your numbers seperated by spaces.");
                            }
                            else
                            {
                                numbers = new List<int>();
                                foreach (string str in inputNumbers.Split(' '))
                                {
                                    if (int.TryParse(str, out int num))
                                    {
                                        numbers.Add(num);
                                    }
                                    else
                                    {
                                        Console.WriteLine("One or more elements are not valid numbers. Please only input nubers seperated by spaces.");
                                        break;
                                    }
                                }

                                // Break out of loop if all numbers are valid
                                if (numbers.Count == inputNumbers.Split(' ').Length) { break; }
                            }
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Re-enter the input.");
                        //numbers = new List<int>();
                    }
                }

                Console.Clear();

                // Display current unsorted numbers
                Console.WriteLine("Numbers to sort: ");
                numbers.ForEach(x => Console.Write(x + " "));

                // Do the sorting
                List<int> sortedNumbers;

                while (true)
                {
                    // Choose the sorting-algorithm
                    Console.WriteLine("\nChoose a sorting-algorithm: ");
                    Console.WriteLine("1. Bubble Sort");
                    Console.WriteLine("2. Selection Sort");
                    Console.WriteLine("3. Insertion Sort");
                    Console.WriteLine("4. Quick Sort");
                    Console.WriteLine("5. Merge Sort");
                    Console.Write("Input: ");

                    int.TryParse(Console.ReadLine(), out int sortAlgorithm);

                    // Handle userinput
                    if (sortAlgorithm == 1)
                    {
                        sortedNumbers = Sorter.BubbleSort(numbers);
                        break;
                    } 
                    else if (sortAlgorithm == 2)
                    {
                        sortedNumbers = Sorter.SelectionSort(numbers);
                        break;
                    }
                    else if (sortAlgorithm == 3)
                    {
                        sortedNumbers = Sorter.InsertionSort(numbers);
                        break;
                    }
                    else if (sortAlgorithm == 4)
                    {
                        sortedNumbers = Sorter.QuickSort(numbers);
                        break;
                    }
                    else if (sortAlgorithm == 5)
                    {
                        sortedNumbers = Sorter.MergeSort(numbers);
                        break;
                    }
                    else
                    {
                        // Give user error to retry
                        Console.WriteLine("Invalid input. Re-enter the input.");
                    }
                }


                while (true)
                {
                    // Choose sorting method to be displayed
                    Console.WriteLine("Choose a sorting method: ");
                    Console.WriteLine("1. Ascending");
                    Console.WriteLine("2. Descending");
                    Console.WriteLine("3. ZigZag-sorted");
                    Console.Write("Input: ");

                    int.TryParse(Console.ReadLine(), out int outputStyle);

                    if (outputStyle == 1)
                    {
                        // Ascending
                        Console.Clear();
                        Console.WriteLine("Sorted numbers (ascending): ");
                        foreach (int num in sortedNumbers)
                        {
                            Console.Write(num + " ");
                        }
                        break;
                    }
                    else if (outputStyle == 2)
                    {
                        // Descending
                        Console.Clear();
                        Console.WriteLine("Sorted numbers (descending): ");
                        for (int i = sortedNumbers.Count - 1; i >= 0; i--)
                        {
                            Console.Write(sortedNumbers[i] + " ");
                        }
                        break;
                    }
                    else if (outputStyle == 3) 
                    {
                        // Zickzack
                        Console.Clear();
                        Console.WriteLine("Sorted numbers (zigzag): ");
                        sortedNumbers = Sorter.ZickzackSort(numbers);
                        foreach (int num in sortedNumbers)
                        {
                            Console.Write(num + " ");
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Re-enter the input.");
                    }
                }

                // After sorting
                do
                {
                    Console.WriteLine("\n\nSorting finished. Choose your next step: ");
                    Console.WriteLine("1. Restart process of sorting");
                    Console.WriteLine("2. Exit program");
                    Console.Write("Input: ");

                    int.TryParse(Console.ReadLine(), out lastStep);

                    // Continue if user wants; break out of loop
                    if (lastStep == 1)
                    {
                        break;
                    } 
                    // Exit program if user wants
                    else if (lastStep == 2)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Re-enter the input.");
                    }

                } while (true);
                // Clear console for next sorting
                Console.Clear();
            } while (lastStep != 2);
        }
    }
}

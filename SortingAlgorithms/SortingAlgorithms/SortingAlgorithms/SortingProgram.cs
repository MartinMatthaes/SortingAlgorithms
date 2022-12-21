using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class SortingProgram
    {
        public void DoSorting()
        {
            // Zufällige Zahlen generieren oder manuell eingeben
            Console.WriteLine("Do you want to generate random numbers or enter them manually?");
            Console.WriteLine("1. Generate randomly");
            Console.WriteLine("2. Enter manually");
            Console.Write("Input: ");
            int.TryParse(Console.ReadLine(), out int input);

            List<int> numbers;
            if (input == 1)
            {
                // Anzahl der zu generierenden Zahlen abfragen
                Console.WriteLine("How many numbers do you want to generate?");
                Console.Write("Input: ");
                bool validInput = int.TryParse(Console.ReadLine(), out int numCount);

                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Exiting program.");
                    Environment.Exit(0);
                }
                // Zufällige Zahlen generieren
                Random rnd = new();
                numbers = new List<int>();
                for (int i = 0; i < numCount; i++)
                {
                    numbers.Add(rnd.Next(1, 10001));
                }
            }
            else if (input == 2)
            {
                // Zahlen manuell eingeben
                Console.WriteLine("Enter your desired numbers seperated by spaces: ");
                string inputNumbers = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputNumbers))
                {
                    // Keine Zahlen eingegeben
                    Console.WriteLine("No numbers provided. Exiting program.");
                    Environment.Exit(0);
                    numbers = new List<int>();
                }
                else
                {
                    // Zahlen eingegeben
                    numbers = new List<int>();
                    foreach (string str in inputNumbers.Split(' '))
                    {
                        // Versuche, jedes Element in einen int umzuwandeln
                        if (int.TryParse(str, out int num))
                        {
                            // Umwandlung erfolgreich
                            numbers.Add(num);
                        }
                        else
                        {
                            // Umwandlung nicht erfolgreich
                            Console.WriteLine("One or more elements are not valid numbers. Please only input nubers seperated by spaces.");
                            Environment.Exit(0);
                            numbers = new List<int>();
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Exiting program.");
                Environment.Exit(0);
                numbers = new List<int>();
            }

            // Sortieralgorithmus auswählen
            Console.WriteLine("Choose a sorting-algorithm: ");
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Selection Sort");
            Console.WriteLine("3. Insertion Sort");
            Console.Write("Input: ");
            int sortAlgorithm = int.Parse(Console.ReadLine());

            // Sortierung ausführen
            List<int> sortedNumbers;
            switch (sortAlgorithm)
            {
                case 1:
                    sortedNumbers = Sorter.BubbleSort(numbers);
                    break;
                case 2:
                    sortedNumbers = Sorter.SelectionSort(numbers);
                    break;
                case 3:
                    sortedNumbers = Sorter.InsertionSort(numbers);
                    break;
                default:
                    Console.WriteLine("Invalid input. Exiting program.");
                    Environment.Exit(0);
                    sortedNumbers = new List<int>();
                    break;
            }

            // Ausgabeart auswählen
            Console.WriteLine("Choose a sorting method: ");
            Console.WriteLine("1. Ascending");
            Console.WriteLine("2. Descending");
            Console.WriteLine("3. ZigZag-sorted");
            Console.Write("Input: ");
            int outputStyle = int.Parse(Console.ReadLine());

            // Ausgabe
            switch (outputStyle)
            {
                case 1:
                    // Aufsteigend sortiert
                    Console.WriteLine("Sorted numbers (ascending): ");
                    foreach (int num in sortedNumbers)
                    {
                        Console.Write(num + " ");
                    }
                    break;
                case 2:
                    // Absteigend sortiert
                    Console.WriteLine("Sorted numbers (descending): ");
                    for (int i = sortedNumbers.Count - 1; i >= 0; i--)
                    {
                        Console.Write(sortedNumbers[i] + " ");
                    }
                    break;
                case 3:
                    // Zickzack-Sortierung
                    Console.WriteLine("Sorted numbers (zigzag): ");
                    sortedNumbers = Sorter.ZickzackSort(numbers);
                    foreach (int num in sortedNumbers)
                    {
                        Console.Write(num + " ");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input. Exiting program.");
                    Environment.Exit(0);
                    numbers = new List<int>();
                    break;
            }
        }
    }
}

using SortingAlgorithms;

namespace NumberSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sorter"; // Set the console title
            Console.CursorVisible = false; // Hide the cursor for better UI
            SortingProgram SorterProgram = new(); // Create new SortingProgram class
            SorterProgram.DoSorting();// Run the main game logic
        }
    }
}

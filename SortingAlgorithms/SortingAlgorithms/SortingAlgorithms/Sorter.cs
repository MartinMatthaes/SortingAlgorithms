public class Sorter
{
    // BubbleSort
    public static List<int> BubbleSort(List<int> numbers)
    {
        // Loop through numbers
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            // Loop through unsorted portion of numbers
            for (int j = 0; j < numbers.Count - i - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    int temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                }
            }
        }
        // Return new list
        return numbers;
    }

    // InsertionSort
    public static List<int> InsertionSort(List<int> numbers)
    {
        // Loop through unsorted numbers
        for (int i = 1; i < numbers.Count; i++)
        {
            int key = numbers[i];
            int j = i - 1;
            // Loop through sorted numbers and compare them
            while (j >= 0 && numbers[j] > key)
            {
                numbers[j + 1] = numbers[j];
                j--;
            }
            numbers[j + 1] = key;
        }
        // Return new list
        return numbers;
    }

    // SelectionSort
    public static List<int> SelectionSort(List<int> numbers)
    {
        // Loop through numbers
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            int minIndex = i;
            // Loop through sublist of numbers and finds the minimum value
            for (int j = i + 1; j < numbers.Count; j++)
            {
                if (numbers[j] < numbers[minIndex])
                {
                    minIndex = j;
                }
            }
            // Minimum value is swapped with the value at the current outer loop
            int temp = numbers[minIndex];
            numbers[minIndex] = numbers[i];
            numbers[i] = temp;
        }
        // Return new list
        return numbers;
    }

    // QuickSort
    public static List<int> QuickSort(List<int> numbers)
    {
        // If numbers is 1 or less return
        if (numbers.Count <= 1)
        {
            return numbers;
        }

        // Pivot is in the middle of the numbers
        int pivot = numbers[numbers.Count / 2];
        // https://learn.microsoft.com/de-de/dotnet/api/system.linq.enumerable.where?view=net-7.0
        // Make 2 new lists. 1. Smaller numbers than the pivot; 2. Greater numbers than the pivot
        List<int> left = numbers.Where(num => num < pivot).ToList();
        List<int> right = numbers.Where(num => num > pivot).ToList();

        // Repeat 
        left = QuickSort(left);
        right = QuickSort(right);

        left.Add(pivot);
        left.AddRange(right);
        return left;
    }

    // MergeSort
    public static List<int> MergeSort(List<int> numbers)
    {
        // If numbers is 1 or less return
        if (numbers.Count <= 1)
        {
            return numbers;
        }

        // Split the list into two equal parts
        int middle = numbers.Count / 2;
        List<int> left = numbers.GetRange(0, middle);
        List<int> right = numbers.GetRange(middle, numbers.Count - middle);

        // Repeat
        left = MergeSort(left);
        right = MergeSort(right);
        // After sort return new list using Merge() function
        return Merge(left, right);
    }

    private static List<int> Merge(List<int> left, List<int> right)
    {
        List<int> result = new List<int>();

        // Merge the lists until one of them is empty
        while (left.Count > 0 || right.Count > 0)
        {
            if (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            else if (left.Count > 0)
            {
                result.AddRange(left);
                break;
            }
            else
            {
                result.AddRange(right);
                break;
            }
        }
        // Return new list
        return result;
    }


    // ZickZack output
    public static List<int> ZickzackSort(List<int> numbers)
    {
        numbers.Sort();

        List<int> sortedNumbers = new List<int>();

        // Loop through numbers as long as there are any in the list
        while (numbers.Count > 0)
        {
            // If only one number left
            if (numbers.Count == 1)
            {
                sortedNumbers.Add(numbers[0]);
                numbers.RemoveAt(0);
            } 
            // Else add both numbers
            else
            {
                sortedNumbers.Add(numbers[numbers.Count - 1]);
                sortedNumbers.Add(numbers[0]);
                // Remove last element
                numbers.RemoveAt(numbers.Count - 1);
                // Remove first element
                numbers.RemoveAt(0);
            }
        }
        // Return new list
        return sortedNumbers;
    }
}

public class Sorter
{
    // BubbleSort
    public static List<int> BubbleSort(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count - 1; i++)
        {
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
        return numbers;
    }

    // InsertionSort
    public static List<int> InsertionSort(List<int> numbers)
    {
        for (int i = 1; i < numbers.Count; i++)
        {
            int key = numbers[i];
            int j = i - 1;
            while (j >= 0 && numbers[j] > key)
            {
                numbers[j + 1] = numbers[j];
                j--;
            }
            numbers[j + 1] = key;
        }
        return numbers;
    }

    // SelectionSort
    public static List<int> SelectionSort(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < numbers.Count; j++)
            {
                if (numbers[j] < numbers[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = numbers[minIndex];
            numbers[minIndex] = numbers[i];
            numbers[i] = temp;
        }
        return numbers;
    }

    // QuickSort
    public static List<int> QuickSort(List<int> numbers)
    {
        if (numbers.Count <= 1)
        {
            return numbers;
        }

        // Pivot Element auswählen und Liste in Elemente größer als das Pivot und Elemente kleiner als das Pivot teilen
        int pivot = numbers[numbers.Count / 2];
        List<int> left = numbers.Where(num => num < pivot).ToList();
        List<int> right = numbers.Where(num => num > pivot).ToList();

        // Rekursiv sortieren
        left = QuickSort(left);
        right = QuickSort(right);

        // Sortierte Listen zusammenführen
        left.Add(pivot);
        left.AddRange(right);
        return left;
    }

    // MergeSort
    public static List<int> MergeSort(List<int> numbers)
    {
        if (numbers.Count <= 1)
        {
            return numbers;
        }

        // Split the list into two equal parts
        int middle = numbers.Count / 2;
        List<int> left = numbers.GetRange(0, middle);
        List<int> right = numbers.GetRange(middle, numbers.Count - middle);

        // Recursively sort both halves
        left = MergeSort(left);
        right = MergeSort(right);

        // Merge the sorted halves
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
                // Add the smaller element to the result
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
                // Only the left list has elements, add them all
                result.AddRange(left);
                break;
            }
            else
            {
                // Only the right list has elements, add them all
                result.AddRange(right);
                break;
            }
        }

        return result;
    }


    // ZickZack output
    public static List<int> ZickzackSort(List<int> numbers)
    {
        // Liste sortieren
        numbers.Sort();

        // Sortierte Liste erstellen
        List<int> sortedNumbers = new List<int>();

        // Schleife über die Liste
        while (numbers.Count > 0)
        {
            // Erstes und letztes Element hinzufügen
            sortedNumbers.Add(numbers[0]);
            sortedNumbers.Add(numbers[numbers.Count - 1]);

            // Erstes und letztes Element entfernen
            numbers.RemoveAt(0);
            numbers.RemoveAt(numbers.Count - 1);
        }

        return sortedNumbers;
    }
}

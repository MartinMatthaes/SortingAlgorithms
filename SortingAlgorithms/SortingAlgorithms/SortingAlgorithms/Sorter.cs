public class Sorter
{
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


    public static List<int> MergeSort(List<int> numbers)
    {
        if (numbers.Count <= 1)
        {
            return numbers;
        }

        // Liste in zwei Hälften teilen
        int middle = numbers.Count / 2;
        List<int> left = numbers.Take(middle).ToList();
        List<int> right = numbers.Skip(middle).ToList();

        // Rekursiv sortieren
        left = MergeSort(left);
        right = MergeSort(right);

        // Hälften zusammenführen und sortieren
        return Merge(left, right);
    }

    public static List<int> Merge(List<int> left, List<int> right)
    {
        List<int> result = new List<int>();
        while (left.Count > 0 || right.Count > 0)
        {
            if (left.Count > 0 && right.Count > 0)
            {
                // Beide Listen haben Elemente, vergleiche die kleinsten Elemente
                if (left.First() <= right.First())
                {
                    result.Add(left.First());
                    left.RemoveAt(0);
                }
                else
                {
                    // Nur eine Liste hat noch Elemente, füge alle Elemente hinzu
                    result.AddRange(left);
                    result.AddRange(right);
                    break;
                }
            }
            return result;
        }
    }
}

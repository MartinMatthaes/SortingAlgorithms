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
}

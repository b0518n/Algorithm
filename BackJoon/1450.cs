StreamWriter sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int c = input[1];
int[] weights = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] left = CombinationCalculator.GetCombination(weights, 0, weights.Length / 2, c);
int[] right = CombinationCalculator.GetCombination(weights, (weights.Length / 2) + 1, weights.Length - 1, c);

int count = 0;
int value = 0;
for (int i = 0; i < right.Length; i++)
{
    value = c - right[i];
    for (int j = 0; j < left.Length; j++)
    {
        if (left[j] <= value)
        {
            count++;
        }
    }
}

sw.WriteLine(count);
sw.Flush();
sw.Close();

public class CombinationCalculator
{
    public static int[] GetCombination(int[] elements, int startIndex, int endIndex, int maxValue)
    {
        List<int> result = new List<int>();
        int current = 0;
        for (int i = 0; i <= endIndex - startIndex + 1; i++)
        {
            GetCombination(elements, i, startIndex, endIndex, current, result, maxValue);
        }
        return result.ToArray();
    }

    public static void GetCombination(int[] elements, int k, int startIndex, int endIndex, int current, List<int> result, int maxValue)
    {
        if (current > maxValue)
        {
            return;
        }

        if (k == 0)
        {
            if (current <= maxValue)
            {
                result.Add(current);
            }
            return;
        }

        for (int i = startIndex; i <= endIndex; i++)
        {
            current += elements[i];
            GetCombination(elements, k - 1, i + 1, endIndex, current, result, maxValue);
            current -= elements[i];
        }
    }
}
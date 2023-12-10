int n = int.Parse(Console.ReadLine());
int k = int.Parse(Console.ReadLine());

int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
HashSet<int> set = arr.ToHashSet();
arr = set.ToArray();

Array.Sort(arr);
List<int> distances = new List<int>();
int value = 0;
for (int i = 1; i < arr.Length; i++)
{
    value = arr[i] - arr[i - 1];
    distances.Add(value);
}

distances.Sort();
distances.Reverse();
int result = 0;

for (int i = 0; i < distances.Count; i++)
{
    if (i < k - 1)
    {
        distances[i] = 0;
    }

    result += distances[i];
}

Console.WriteLine(result);
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];

input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
List<int> list = new List<int>();
for (int i = 1; i < n; i++)
{
    list.Add(input[i] - input[i - 1]);
}

list.Sort();
long result = 0;

for (int i = 0; i < n - k; i++)
{
    result += list[i];
}

Console.WriteLine(result);
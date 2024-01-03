int n = int.Parse(Console.ReadLine());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Array.Sort(input);
Array.Reverse(input);

int max = -1;
int result = 1;

for (int i = 0; i < n; i++)
{
    if (i == 0)
    {
        max = input[i];
        result++;
    }
    else
    {
        max--;
        max = Math.Max(max, input[i]);
        result++;
    }
}

result += max;
Console.WriteLine(result);
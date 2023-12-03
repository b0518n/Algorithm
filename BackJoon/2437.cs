int n = int.Parse(Console.ReadLine());
int[] weights = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Array.Sort(weights);
int result = 1;

for (int i = 0; i < weights.Length; i++)
{
    if (result < weights[i])
    {
        break;
    }
    else
    {
        result += weights[i];
    }
}

Console.WriteLine(result);
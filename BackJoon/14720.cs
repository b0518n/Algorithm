int n = int.Parse(Console.ReadLine());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

int value = 0;
int result = 0;

for (int i = 0; i < n; i++)
{
    if (input[i] == value)
    {
        if (value == 2)
        {
            value = 0;
        }
        else
        {
            value++;
        }

        result++;
    }
}

Console.WriteLine(result);
StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

int n = int.Parse(Console.ReadLine());
int[] input = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);

int value = input[0];
for (int i = 1; i < n; i++)
{
    sw.WriteLine(value / G(value, input[i]) + "/" + input[i] / G(value, input[i]));
}

sw.Close();

void int G(int a, int b)
{
    int minValue = 0;
    int maxValue = 0;

    if (a == b)
    {
        return a;
    }
    else
    {
        if (a > b)
        {
            maxValue = a;
            minValue = b;
            return G(a - b, b);
        }
        else
        {
            maxValue = b;
            minValue = a;
            return G(a, b - a);
        }
    }
}
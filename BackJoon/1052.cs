int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];

int result = 0;

string binaryString = string.Empty;
int count = 0;

while (true)
{
    count = 0;
    binaryString = Convert.ToString(n, 2);

    for (int i = 0; i < binaryString.Length; i++)
    {
        if (binaryString[i] == '1')
        {
            count++;
        }
    }

    if (count <= k)
    {
        break;
    }
    else
    {
        n++;
        result++;
    }
}

Console.WriteLine(result);
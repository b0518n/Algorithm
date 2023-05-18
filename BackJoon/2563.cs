Array[] arr = new Array[100];
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = new int[100];
}

int n = int.Parse(Console.ReadLine());
int[] input = null;
for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = input[1] - 1; j < input[1] - 1 + 10; j++)
    {
        for (int k = input[0] - 1; k < input[0] - 1 + 10; k++)
        {
            arr[j].SetValue(1, k);
        }
    }
}

int result = 0;

for (int i = 0; i < 100; i++)
{
    for (int j = 0; j < 100; j++)
    {
        result += (int)arr[i].GetValue(j);
    }
}

Console.WriteLine(result);
string input = Console.ReadLine();
int[] arr = new int[input.Length];

int value = 0;
bool isExistZero = false;

for (int i = 0; i < input.Length; i++)
{
    arr[i] = int.Parse(input[i].ToString());
    value += arr[i];
    if (arr[i] == 0)
    {
        isExistZero = true;
    }
}

if (!isExistZero)
{
    Console.WriteLine(-1);
}
else
{
    if (value % 3 != 0)
    {
        Console.WriteLine(-1);
    }
    else
    {
        Array.Sort(arr);
        Array.Reverse(arr);
        Console.WriteLine(string.Join("", arr));
    }
}

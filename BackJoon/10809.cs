string str = Console.ReadLine();
int[] arr = new int[26];
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = -1;
}

for (int i = 0; i < str.Length; i++)
{
    if (arr[str[i] - 97] == -1)
    {
        arr[str[i] - 97] = i;
    }
}

for (int i = 0; i < 26; i++)
{
    Console.Write(arr[i] + " ");
}
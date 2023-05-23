string str = Console.ReadLine();
char[] arr = str.ToArray();
Array.Sort(arr);
Array.Reverse(arr);
str = string.Empty;
for (int i = 0; i < arr.Length; i++)
{
    str += arr[i];
}

Console.WriteLine(str);
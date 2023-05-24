StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
Dictionary<string, int> dic = new Dictionary<string, int>();
string[] input = null;

for (int i = 0; i < n; i++)
{
    input = Console.ReadLine().Split();
    if (input[1] == "enter")
    {
        dic[input[0]] = 1;
    }
    else
    {
        dic.Remove(input[0]);
    }
}

string[] arr = new string[dic.Count];
int index = 0;
foreach (string str in dic.Keys)
{
    arr[index] = str;
    index++;
}

Array.Sort(arr);
Array.Reverse(arr);

for (int j = 0; j < arr.Length; j++)
{
    sw.WriteLine(arr[j]);
}

sw.Close();
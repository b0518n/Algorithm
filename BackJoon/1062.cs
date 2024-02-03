StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];
string str = null;
Dictionary<string, int> dictionary = new Dictionary<string, int>();
List<string> list = new List<string>();
int result = 0;

for (int i = 0; i < n; i++)
{
    str = sr.ReadLine();
    list.Add(str);
}

dictionary.Add("a", 1);
dictionary.Add("n", 1);
dictionary.Add("t", 1);
dictionary.Add("i", 1);
dictionary.Add("c", 1);

string[] arr = new string[21] { "b", "d", "e", "f", "g", "h", "j", "k", "l", "m", "o", "p", "q", "r", "s", "u", "v", "w", "x", "y", "z" };
BackTracking(0);
Console.WriteLine(result);

void BackTracking(int index)
{
    if (dictionary.Count == k)
    {
        result = Math.Max(result, ReadWord());
        return;
    }

    for (int i = index; i < 21; i++)
    {
        if (!dictionary.ContainsKey(arr[i]))
        {
            dictionary.Add(arr[i], 1);
            BackTracking(i + 1);
            dictionary.Remove(arr[i]);
        }
    }
}

int ReadWord()
{
    bool isRead = true;
    int cnt = 0;

    for (int i = 0; i < n; i++)
    {
        isRead = true;
        for (int j = 4; j < list[i].Length - 4; j++)
        {
            if (!dictionary.ContainsKey(list[i][j].ToString()))
            {
                isRead = false;
                break;
            }
        }

        if (isRead)
        {
            cnt++;
        }
    }

    return cnt;
}
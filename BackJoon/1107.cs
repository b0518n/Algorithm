int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());
int[] brokenButtons = null;
if (m != 0)
{
    brokenButtons = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
}

int number = 100;
int min = Math.Abs(number - n);
int length = n.ToString().Length;

Dictionary<int, int> buttons = new Dictionary<int, int>();
for (int i = 0; i < 10; i++)
{
    buttons.Add(i, 1);
}

for (int i = 0; i < m; i++)
{
    if (buttons.ContainsKey(brokenButtons[i]))
    {
        buttons.Remove(brokenButtons[i]);
    }
}

List<int> buttonList = buttons.Keys.ToList();
if (number == n)
{
    Console.WriteLine(0);
}
else
{
    Recursion(0, string.Empty);
    Console.WriteLine(min);
}

void Recursion(int index, string str)
{
    int _length = str.Length;

    if (length - 1 <= _length && length + 1 >= _length && _length != 0)
    {
        min = Math.Min(min, Math.Abs(int.Parse(str) - n) + _length);

        if (length + 1 == _length)
        {
            return;
        }
    }

    for (int i = 0; i < 10 - m; i++)
    {
        str += buttonList[i].ToString();
        Recursion(i, str);
        str = str.Substring(0, str.Length - 1);
    }
}
using System.Text;

StringBuilder sb = new StringBuilder();
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int b = input[1];

int mok = 0;
int nmg = 0;
List<char> list = new List<char>();

while (true)
{
    if (n == 0)
    {
        break;
    }

    mok = n / b;
    nmg = n % b;

    if (nmg >= 10)
    {
        list.Add((char)(nmg - 10 + 65));
    }
    else
    {
        list.Add((char)(nmg + 48));
    }

    n = mok;
}

for (int i = 0; i < list.Count; i++)
{
    sb.Append(list[i]);
}

Console.WriteLine(sb.ToString());
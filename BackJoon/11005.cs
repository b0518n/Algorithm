using System.Text;

StringBuilder sb = new StringBuilder();
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int b = input[1];

int mok = 0;
int nmg = 0;
List<char> list = new List<char>();
int index = 0;
int value = 0;

while (true)
{
    value = n / (int)Math.Pow(b, index);

    if (value != 0)
    {
        index++;
    }
    else
    {
        index--;
        break;
    }
}

while (true)
{
    if (index == -1)
    {
        break;
    }

    mok = n / (int)Math.Pow(b, index);
    nmg = n % (int)Math.Pow(b, index);
    n = nmg;
    if (mok < 10)
    {
        list.Add((char)(mok + 49 - 1));
    }
    else if (mok >= 10)
    {
        list.Add((char)(mok + 65 - 10));
    }
    index--;
}


for (int i = 0; i < list.Count; i++)
{
    sb.Append(list[i]);
}

Console.WriteLine(sb.ToString());
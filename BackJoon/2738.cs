using System.Text;

StringBuilder sb = new StringBuilder();
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

Array[] a = new Array[n];
Array[] b = new Array[n];

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    a[i] = input;
}

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    b[i] = input;
}

Array[] c = (Array[])a.Clone();
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        c[i].SetValue((int)c[i].GetValue(j) + (int)b[i].GetValue(j), j);
        if (j == m - 1)
        {
            sb.Append(c[i].GetValue(j));
        }
        else
        {
            sb.Append(c[i].GetValue(j) + " ");
        }
    }

    if (i != n - 1)
    {
        sb.AppendLine();
    }
}

Console.WriteLine(sb.ToString());
using System.Text;

StringBuilder sb = new StringBuilder();
int[] arr = null;
int a = 0;
int b = 0;
int c = 0;

while (true)
{
    arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    a = arr[0];
    b = arr[1];
    c = arr[2];

    if (a == 0 && b == 0 && c == 0)
    {
        break;
    }

    if (IsTriangle(a, b, c) == false)
    {
        sb.AppendLine("Invalid");
    }
    else
    {
        if (a == b && b == c)
        {
            sb.AppendLine("Equilateral");
        }
        else if (a != b && b != c && a != c)
        {
            sb.AppendLine("Scalene");
        }
        else
        {
            sb.AppendLine("Isosceles");
        }
    }
}

Console.WriteLine(sb.ToString());

bool IsTriangle(int x, int y, int z)
{
    List<int> list = new List<int>();
    list.Add(x);
    list.Add(y);
    list.Add(z);
    list.Sort();

    if (list[2] < list[0] + list[1])
    {
        return true;
    }
    else
    {
        return false;
    }
}
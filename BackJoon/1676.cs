using System.Numerics;
StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

BigInteger[] arr = new BigInteger[501];

for (int i = 0; i < arr.Length; i++)
{
    if (i < 2)
    {
        arr[i] = 1;
    }
    else
    {
        arr[i] = arr[i - 1] * i;
    }
}

int n = int.Parse(Console.ReadLine());
string str = arr[n].ToString();
int index = str.Length - 1;
int count = 0;

while (true)
{
    if (str[index].ToString() != "0")
    {
        sw.Write(count);
        break;
    }
    else
    {
        index -= 1;
        count += 1;
    }
}
sw.Close();

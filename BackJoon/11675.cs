StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] a = new int[8]; // x
int[] b = new int[8]; // x << 1
int[] c = new int[8]; // x ^ ( x << 1 )

int n = 0;
int index = 0;
int[] result = new int[n];

Input();
for (int i = 0; i < n; i++)
{
    ValuetoArr(result[i]);
    SearchValue();
}

Print();

void Input()
{
    n = int.Parse(sr.ReadLine());
    result = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
}
void ValuetoArr(int value)
{
    for (int i = 7; i >= 0; i--)
    {
        if ((value & (1 << 7 - i)) != 0)
        {
            c[i] = 1;
        }
        else
        {
            c[i] = 0;
        }
    }
}
void SearchValue()
{
    b[7] = 0;

    for (int i = 7; i >= 0; i--)
    {
        if (c[i] == 0)
        {
            a[i] = b[i];
        }
        else
        {
            if (b[i] == 1)
            {
                a[i] = 0;
            }
            else
            {
                a[i] = 1;
            }
        }

        if (i != 0)
        {
            b[i - 1] = a[i];
        }
    }

    int value = 0;

    for (int i = 7; i >= 0; i--)
    {
        if (a[i] == 1)
        {
            value += Pow(2, 7 - i);
        }
    }

    result[index] = value;
    index++;
}
int Pow(int n, int r)
{
    int retValue = 1;

    for (int i = 0; i < r; i++)
    {
        retValue *= 2;
    }

    return retValue;
}
void Print()
{
    sw.WriteLine(string.Join(" ", result));
    sw.Flush();
    sw.Close();
}
int n = int.Parse(Console.ReadLine());

int mok = n / 5;
int result = -1;

for (int i = mok; i>=0;i++)
{
    if ((n - (mok * 5)) % 3 == 0)
    {
        result = mok + (n - (mok * 5)) / 3;
        break;
    }
    else
    {
        continue;
    }
}

Console.WriteLine(result);
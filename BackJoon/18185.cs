StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
int[] factoryArr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

int result = 0;

for (int i = 0; i < n - 2; i++)
{
    if (factoryArr[i] == 0)
        continue;

    if (factoryArr[i + 1] == 0)
    {
        BuyCase1_Func(i);
        continue;
    }

    if (factoryArr[i + 2] == 0)
    {
        BuyCase2_Func(i);
        BuyCase1_Func(i);
        continue;
    }

    if (factoryArr[i + 1] > factoryArr[i + 2])
    {
        int _cnt = Math.Min(factoryArr[i], factoryArr[i + 1] - factoryArr[i + 2]);
        result += _cnt * 5;
        factoryArr[i] -= _cnt;
        factoryArr[i + 1] -= _cnt;

        BuyCase3_Func(i);
        BuyCase2_Func(i);
        BuyCase1_Func(i);
    }
    else
    {
        BuyCase3_Func(i);
        BuyCase2_Func(i);
        BuyCase1_Func(i);
    }
}

if (factoryArr[n - 1] == 0)
{
    BuyCase1_Func(n - 2);
}
else
{
    BuyCase2_Func(n - 2);
    BuyCase1_Func(n - 2);
}

BuyCase1_Func(n - 1);

sw.WriteLine(result);
sw.Flush();
sw.Close();

void BuyCase1_Func(int _index)
{
    int _cnt = factoryArr[_index];
    result += _cnt * 3;

    factoryArr[_index] -= _cnt;
}
void BuyCase2_Func(int _index)
{
    int _cnt = Math.Min(factoryArr[_index], factoryArr[_index + 1]);
    result += _cnt * 5;

    factoryArr[_index] -= _cnt;
    factoryArr[_index + 1] -= _cnt;
}
void BuyCase3_Func(int _index)
{
    int _cnt = Math.Min(factoryArr[_index], Math.Min(factoryArr[_index + 1], factoryArr[_index + 2]));
    result += _cnt * 7;

    factoryArr[_index] -= _cnt;
    factoryArr[_index + 1] -= _cnt;
    factoryArr[_index + 2] -= _cnt;
}
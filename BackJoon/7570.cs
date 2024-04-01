StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int[] dp = new int[n + 1];
Dictionary<int, int> dic = new Dictionary<int, int>();
int result = 0;

GetMinMove();
Print();

void GetMinMove()
{
    int retValue = 0;

    for (int i = 0; i < n; i++)
    {
        dic.Add(arr[i], i);
    }

    for (int i = 2; i < n + 1; i++)
    {
        if (dic[i] > dic[i - 1])
        {
            dp[i] = dp[i - 1] + 1;
        }

        if (retValue == 0)
        {
            retValue = dp[i];
        }
        else
        {
            retValue = Math.Max(retValue, dp[i]);
        }
    }

    retValue++;
    result = n - retValue;
}
void Print()
{
    sw.WriteLine(result);
    sw.Flush();
    sw.Close();
}
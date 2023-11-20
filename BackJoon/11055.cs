int n = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
List<int> temp = arr.ToList();
temp.Insert(0, 0);
arr = temp.ToArray();
int[] dp = new int[1001];
int result = 0;

for (int i = 1; i < n + 1; i++)
{
    for (int j = 0; j < i; j++)
    {
        if (arr[i] > arr[j])
        {
            dp[i] = Math.Max(dp[i], dp[j] + arr[i]);
            result = Math.Max(result, dp[i]);
        }
    }
}

Console.WriteLine(result);
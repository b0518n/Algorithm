// 풀이 1
int[] dp = new int[9];
int input = 0;
for (int i = 0; i < 9; i++)
{
    input = int.Parse(Console.ReadLine());
    dp[i] = input;
}

Stack<int> stack = new Stack<int>();
StringBuilder sb = new StringBuilder();
Recursion(-1, 0, 0);
Console.WriteLine(sb.ToString());

void Recursion(int index, int count, int sum)
{
    if (count == 7)
    {
        if (sum == 100)
        {
            sb.AppendLine(string.Join("\n", stack.Reverse()));
        }

        return;
    }

    for (int i = index + 1; i < 9; i++)
    {
        stack.Push(dp[i]);
        sum += dp[i];
        Recursion(i, count + 1, sum);
        sum -= dp[i];
        stack.Pop();
    }
}

// 풀이 2
int[] dp = new int[9];
int input = 0;
int sum = 0;

for (int i = 0; i < 9; i++)
{
    input = int.Parse(Console.ReadLine());
    dp[i] = input;
    sum += input;
}

int value = sum - 100;

for (int i = 0; i < 9; i++)
{
    for (int j = i + 1; j < 9; j++)
    {
        if (dp[i] + dp[j] == value)
        {
            for (int k = 0; k < 9; k++)
            {
                if (k == i || k == j)
                {
                    continue;
                }

                Console.WriteLine(dp[k]);
            }
        }
    }
}
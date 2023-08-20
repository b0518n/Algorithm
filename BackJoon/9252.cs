string str1 = Console.ReadLine();
string str2 = Console.ReadLine();

int length1 = str1.Length;
int length2 = str2.Length;

int[,] dp = new int[length1 + 1, length2 + 1];

for (int i = 1; i < length1 + 1; i++)
{
    for (int j = 1; j < length2 + 1; j++)
    {
        if (str1[i - 1] == str2[j - 1])
        {
            dp[i, j] = dp[i - 1, j - 1] + 1;
        }
        else
        {
            dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
        }
    }
}

Stack<string> stack = new Stack<string>();
int y = length1;
int x = length2;

while (y > 0 && x > 0)
{
    if (dp[y, x] == dp[y - 1, x - 1])
    {
        y -= 1;
        x -= 1;
    }
    else if (dp[y, x] == dp[y, x - 1])
    {
        x -= 1;
    }
    else if (dp[y, x] == dp[y - 1, x])
    {
        y -= 1;
    }
    else
    {
        stack.Push(str1[y - 1].ToString());
        y -= 1;
        x -= 1;
    }
}

if (stack.Count == 0)
{
    Console.WriteLine(0);
}
else
{
    Console.WriteLine(stack.Count);
    while (stack.Count > 0)
    {
        Console.Write(stack.Pop());
    }
}
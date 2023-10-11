int cost = 1000 - int.Parse(Console.ReadLine());
int[] coins = new int[6] { 500, 100, 50, 10, 5, 1 };
int result = 0;

for (int i = 0; i < 6; i++)
{
    if (cost / coins[i] == 0)
    {
        continue;
    }

    result += cost / coins[i];
    cost = cost % coins[i];
}

Console.WriteLine(result);
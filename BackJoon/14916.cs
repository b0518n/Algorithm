int n = int.Parse(Console.ReadLine());
int[] coins = new int[2] { 5, 2 };

int mok = n / coins[0];
int nmg = n % coins[0];
int result = -1;
int value = 0;
int count = 0;

for (int i = mok; i >= 0; i--)
{
    count = i;
    value = n - (i * coins[0]);

    if (value % coins[1] == 0)
    {
        result = count + (value / coins[1]);
        break;
    }
}

Console.WriteLine(result);
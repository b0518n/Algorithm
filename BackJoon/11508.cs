int n = int.Parse(Console.ReadLine());
int input = -1;
List<int> prices = new List<int>();

for (int i = 0; i < n; i++)
{
    prices.Add(int.Parse(Console.ReadLine()));
}

prices.Sort((x, y) => { return x.CompareTo(y); });
int cnt = 0;
int result = 0;

while (prices.Count > 0)
{
    if (cnt == 2)
    {
        prices.RemoveAt(prices.Count - 1);
        cnt = 0;
    }
    else
    {
        result += prices[prices.Count - 1];
        prices.RemoveAt(prices.Count - 1);
        cnt++;
    }
}

Console.WriteLine(result);
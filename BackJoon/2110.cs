StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int c = input[1];

int[] houses = new int[n];
int tmp = 0;

for (int i = 0; i < n; i++)
{
    tmp = int.Parse(sr.ReadLine());
    houses[i] = tmp;
}

Array.Sort(houses);

int start = 1;
int end = houses[houses.Length - 1];
int result = 0;

while (start <= end)
{
    int mid = (start + end) / 2;
    int temp = houses[0];
    int count = 1;

    foreach (int i in houses)
    {
        if (i >= temp + mid)
        {
            count++;
            temp = i;
        }
    }

    if (count >= c)
    {
        start = mid + 1;
        result = mid;
    }
    else
    {
        end = mid - 1;
    }
}

sw.WriteLine(result);
sw.Flush();
sw.Close();
sr.Close();
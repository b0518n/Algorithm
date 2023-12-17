int n = int.Parse(Console.ReadLine());
string str = Console.ReadLine();
int result = 1;

for (int i = 0; i < n; i++)
{
    if (str[i] == 'S')
    {
        result++;
    }
    else
    {
        i++;
        result++;
    }
}

result = Math.Min(result, n);
Console.WriteLine(result);
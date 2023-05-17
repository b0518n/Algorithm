int n = int.Parse(Console.ReadLine());
string str = Console.ReadLine();
int result = 0;
for (int i = 0; i < n; i++)
{
    result += int.Parse(str[i].ToString());
}

Console.WriteLine(result);
int n = int.Parse(Console.ReadLine());
int nmg = n % 2;
string result = string.Empty;

if (nmg == 0)
{
    result = "CY";
}
else
{
    result = "SK";
}

Console.WriteLine(result);
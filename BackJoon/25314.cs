int n = int.Parse(Console.ReadLine());
int count = n / 4;
string result = string.Empty;

for (int i = 0; i < count; i++)
{
    if (i == 0)
    {
        result += "long";
    }
    else
    {
        result += " long";
    }
}

result += " int";

Console.WriteLine(result);
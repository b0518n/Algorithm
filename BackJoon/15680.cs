int n = int.Parse(Console.ReadLine());
Console.WriteLine(GetNameOrSlogan(n));

string GetNameOrSlogan(int n)
{
    string result = string.Empty;

    if (n == 0)
    {
        result = "YONSEI";
    }
    else
    {
        result = "Leading the Way to the Future";
    }

    return result;
}
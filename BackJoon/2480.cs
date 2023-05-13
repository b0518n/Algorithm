int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int a = input[0];
int b = input[1];
int c = input[2];
int result = 0;

if (a == b && b == c) // 같은 눈 3개
{
    result = 10000 + (a * 1000);
}
else if ((a == b && a != c) || (a == c && b != c)) // 같은 눈 2개
{
    result = 1000 + (a * 100);
}
else if ((b == c && a != b)) // 같은 눈 2개
{
    result = 1000 + (b * 100);
}
else // 모두 다른 눈
{
    if (a > b && a > c) // a가 가장 큰 수
    {
        result = a * 100;
    }
    else if (b > a && b > c) // b가 가장 큰 수
    {
        result = b * 100;
    }
    else if (c > a && c > b) // c가 가장 큰 수
    {
        result = c * 100;
    }
}

Console.WriteLine(result);
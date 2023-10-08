BigInteger a = BigInteger.Parse(Console.ReadLine());
BigInteger b = BigInteger.Parse(Console.ReadLine());

BigInteger klaudia = 0;
BigInteger natalia = 0;

if (a % 2 == 0) // b가 홀수 인경우는 x
{
    klaudia = (a / 2) + (b / 2);
    natalia = (a / 2) - (b / 2);
}
else
{
    klaudia = ((a + 1) / 2) + ((b - 1) / 2);
    natalia = ((a + 1) / 2) - 1 - ((b - 1) / 2);
}

Console.WriteLine(klaudia);
Console.WriteLine(natalia);
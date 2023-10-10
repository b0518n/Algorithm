int n = int.Parse(Console.ReadLine());
int result = (n / 100) * 78;
int _result = (((n / 100) * 20) / 100) * 78 + (n / 100) * 80;
Console.WriteLine($"{result} {_result}");
int x = int.Parse(Console.ReadLine()); // 영수증 총 금액
int n = int.Parse(Console.ReadLine());
int[] input = null;
int a = 0; // 물건의 가격
int b = 0; // 물건의 개수
int result = 0;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];
    result += (a * b);
}

if (result == x)
{
    Console.WriteLine("Yes");
}
else
{
    Console.WriteLine("No");
}
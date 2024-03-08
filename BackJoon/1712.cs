string[] str = Console.ReadLine().Split(" ");
int a = int.Parse(str[0]);
int b = int.Parse(str[1]);
int c = int.Parse(str[2]);

int retValue = 0;

if (c - b <= 0)
{
    Console.WriteLine("-1");
}
else
{
    retValue = (a / (c - b)) + 1;
    Console.WriteLine(retValue);
}
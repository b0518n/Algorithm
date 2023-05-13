int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int a = input[0];
int b = input[1];

if (a > b)
{
    Console.WriteLine(">");
}
else if (a < b)
{
    Console.WriteLine("<");
}
else
{
    Console.WriteLine("==");
}
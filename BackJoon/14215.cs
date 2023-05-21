int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int a = input[0];
int b = input[1];
int c = input[2];

List<int> list = new List<int> { a, b, c };
list.Sort();

if (list[2] < list[0] + list[1])
{
    Console.WriteLine(list[0] + list[1] + list[2]);
}
else
{
    Console.WriteLine(list[0] + list[1] + list[0] + list[1] - 1);
}
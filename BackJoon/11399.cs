int n = int.Parse(Console.ReadLine());
int[] times = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int value = 0;
int tmp = 0;

Array.Sort(times);

for (int i = 0; i < times.Length; i++)
{
    value += (tmp + times[i]);
    tmp += times[i];
}

Console.WriteLine(value);
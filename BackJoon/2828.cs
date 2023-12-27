int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int j = int.Parse(Console.ReadLine());
int start = 1;
int end = start + (m - 1);

int index = -1;
int result = 0;

for (int i = 0; i < j; i++)
{
    index = int.Parse(Console.ReadLine());
    if (index >= start && index <= end)
    {
        continue;
    }
    else if (index < start)
    {
        result += start - index;
        end -= (start - index);
        start -= (start - index);
    }
    else if (index > end)
    {
        result += (index - end);
        start += (index - end);
        end += (index - end);
    }
}

Console.WriteLine(result);
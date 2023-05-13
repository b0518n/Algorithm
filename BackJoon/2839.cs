int n = int.Parse(Console.ReadLine());
int[] counts = new int[6000];

counts[3] = 1;
counts[5] = 1;

for (int i = 3; i < 5001; i++)
{
    if (counts[i] != 0)
    {
        if (counts[i + 3] == 0)
        {
            counts[i + 3] = counts[i] + 1;
        }
        else
        {
            if (counts[i + 3] > counts[i] + 1)
            {
                counts[i + 3] = counts[i] + 1;
            }
        }

        if (counts[i + 5] == 0)
        {
            counts[i + 5] = counts[i] + 1;
        }
        else
        {
            if (counts[i + 5] > counts[i] + 1)
            {
                counts[i + 5] = counts[i] + 1;
            }
        }
    }
}

Console.WriteLine(counts[n] == 0 ? -1 : counts[n]);
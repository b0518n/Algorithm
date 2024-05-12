StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int t = int.Parse(sr.ReadLine());

int[] input = null;

int sizeA = 0;
int sizeB = 0;

int[] creatureA = null;
int[] creatureB = null;

int result = 0;

for (int i = 0; i < t; i++)
{
    result = 0;
    Input();
    for (int j = 0; j < sizeA; j++)
    {
        BinarySearch(creatureA[j]);
    }

    sw.WriteLine(result);
}

sw.Flush();
sw.Close();

void Input()
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    sizeA = input[0];
    sizeB = input[1];
    creatureA = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    creatureB = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    Array.Sort(creatureB);
}
void BinarySearch(int size)
{
    int left = 0;
    int right = sizeB - 1;
    int middle = 0;

    while (left <= right)
    {
        middle = (left + right) / 2;
        if (size <= creatureB[middle])
        {
            right = middle - 1;
        }
        else
        {
            left = middle + 1;
        }
    }

    result += left;
}
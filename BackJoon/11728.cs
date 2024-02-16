StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[] arrA = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int[] arrB = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

Array.Sort(arrA);
Array.Sort(arrB);

List<int> container = new List<int>();

int indexA = 0;
int indexB = 0;

while (indexA <= n - 1 || indexB <= m - 1)
{
    if (indexA <= n - 1 && indexB <= m - 1 && arrA[indexA] > arrB[indexB])
    {
        container.Add(arrB[indexB]);
        indexB++;
    }
    else if (indexA <= n - 1 && indexB <= m - 1 && arrA[indexA] <= arrB[indexB])
    {
        container.Add(arrA[indexA]);
        indexA++;
    }
    else if (indexA > n - 1)
    {
        container.Add(arrB[indexB]);
        indexB++;
    }
    else if (indexB > m - 1)
    {
        container.Add(arrA[indexA]);
        indexA++;
    }
}

sw.WriteLine(string.Join(" ", container));
sw.Flush();
sw.Close();
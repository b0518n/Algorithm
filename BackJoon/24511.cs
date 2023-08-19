int n = int.Parse(Console.ReadLine()); // 자료구조의 개수
int[] sequenceA = Array.ConvertAll(Console.ReadLine().Split(), int.Parse); // 0 : 큐, 1 : 스택
int[] sequenceB = Array.ConvertAll(Console.ReadLine().Split(), int.Parse); // 원소
int m = int.Parse(Console.ReadLine());
int[] sequenceC = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

int[] arr = new int[m];
int count = 0;

for (int j = sequenceB.Length - 1; j >= 0; j--)
{
    if (count >= m)
    {
        break;
    }

    if (sequenceA[j] == 0)
    {
        arr[count] = sequenceB[j];
        count++;
    }
}

int index = 0;

for (; count < m; count++)
{
    arr[count] = sequenceC[index];
    index++;
}

Console.WriteLine(string.Join(" ", arr));
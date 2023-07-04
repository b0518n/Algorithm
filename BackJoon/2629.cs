StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine()); // 추의 개수 
int[] weights = Array.ConvertAll(Console.ReadLine().Split(), int.Parse); // 추의 무게를 담은 배열, 가벼운 순서대로 정렬되어 있음.
int m = int.Parse(Console.ReadLine()); // 확인할 구슬의 개수
int[] marbles = Array.ConvertAll(Console.ReadLine().Split(), int.Parse); // 확인할 구슬을 담은 배열
                                                                         // index > n 일경우 return하는 방식으로 끝내고 있는데, 이럴경우 weights의 index를 벗어나서 out of range 에러가 발생 그 문제를 해결하기 위해,
                                                                         // 맨 뒤에 0를 1개 넣음으로써 해결.
List<int> temp = weights.ToList();
temp.Add(0);
weights = temp.ToArray();

bool[,] arr = new bool[31, 40001];
Solve(0, 0);


for (int i = 0; i < marbles.Length; i++)
{
    if (i == 0)
    {
        if (arr[n, marbles[i]] == true)
        {
            sw.Write("Y");
        }
        else
        {
            sw.Write("N");
        }
    }
    else
    {
        if (arr[n, marbles[i]] == true)
        {
            sw.Write(" Y");
        }
        else
        {
            sw.Write(" N");
        }
    }
}

sw.Flush();
sw.Close();

void Solve(int index, int weight)
{
    if (index > n || arr[index, weight] == true)
    {
        return;
    }

    arr[index, weight] = true;
    Solve(index + 1, weight + weights[index]);
    Solve(index + 1, Math.Abs(weight - weights[index]));
    Solve(index + 1, weight);
    Solve(index + 1, weights[index]);
}
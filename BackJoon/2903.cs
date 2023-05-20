// 풀이
// 각 상자의 개수의 맨 왼쪽 대각선에 있는 점의 개수 = 사각형의 개수
// 남은 점은 맨 오른쪽 점과 맨 아랫쪽 점의 개수
// 정사각형을 쪼개서 개수를 늘리는 구조 이므로 사각형의 개수는 n^2의 개수로만 나옴
// 맨 오른쪽 점과 아랫쪽 점의 개수를 구할 때 오른쪽 밑 대각선의 점이 겹치므로
// n + 1 + n으로 하면 남은 부분의 점을 개수를 구할 수 있음.


int n = int.Parse(Console.ReadLine());
List<int> list = new List<int>();
list.Add(1);
for (int i = 0; i < 15; i++)
{
    list.Add(list.Last() * 4);
}

int mok = (int)Math.Sqrt(double.Parse(list[n].ToString()));
Console.WriteLine(list[n] + mok + 1 + mok);
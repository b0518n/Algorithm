int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0]; // 물이 새는 곳의 개수
int l = input[1]; // 테이프의 길이

input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
List<int> holes = new List<int>();

for (int i = 0; i < input.Length; i++)
{
    holes.Add(input[i]);
}

holes.Sort();
Dictionary<int, int> dics = new Dictionary<int, int>();
int count = 0;

for (int i = 0; i < holes.Count; i++)
{
    if (!dics.ContainsKey(holes[i]))
    {
        count++;
        dics.Add(holes[i], 1);
        for (int j = 1; j < l; j++)
        {
            dics.Add(holes[i] + j, 1);
        }
    }
    else
    {
        continue;
    }
}

Console.WriteLine(count);

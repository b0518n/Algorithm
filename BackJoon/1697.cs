StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];

int[] times = new int[100001];
BFS(times, n);
sw.WriteLine(times[k] - 1); // n의 위치를 0으로 잡지 않고 1로 잡음으로써 따로 방문체크를 하지 않아도 0 여부에 따라 방문체크를 대체하고 마지막에 k의 위치 값에서 1를 빼는 방식을 사용.
sw.Flush();
sw.Close();

void BFS(int[] times, int index)
{
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(index);
    times[index] = 1;
    int temp = 0;
    int nx = 0;

    while (queue.Count > 0)
    {
        temp = queue.Dequeue();
        nx = temp + 1;

        if (nx >= 0 && nx <= 100000)
        {
            if (times[nx] == 0) // 한 번도 방문하지 않았을 경우
            {
                times[nx] = times[temp] + 1;
                queue.Enqueue(nx);
            }
            else
            {
                if (times[nx] > times[temp] + 1) // 이미 방문한 곳의 값보다 더 적을 경우 값을 더 적은 수로 바꾸고 다시 큐에 집어넣음
                {
                    times[nx] = times[temp] + 1;
                    queue.Enqueue(nx);
                }
            }
        }

        nx = temp - 1;
        if (nx >= 0 && nx <= 100000)
        {
            if (times[nx] == 0)
            {
                times[nx] = times[temp] + 1;
                queue.Enqueue(nx);
            }
            else
            {
                if (times[nx] > times[temp] + 1)
                {
                    times[nx] = times[temp] + 1;
                    queue.Enqueue(nx);
                }
            }
        }

        nx = 2 * temp;

        if (nx >= 0 && nx <= 100000)
        {
            if (times[nx] == 0)
            {
                times[nx] = times[temp] + 1;
                queue.Enqueue(nx);
            }
            else
            {
                if (times[nx] > times[temp] + 1)
                {
                    times[nx] = times[temp] + 1;
                    queue.Enqueue(nx);
                }
            }
        }
    }
}
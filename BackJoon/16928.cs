StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0]; // 사다리 수
int m = input[1]; // 뱀의 수

int[] board = new int[101];

Dictionary<int, int> ladders = new Dictionary<int, int>();
Dictionary<int, int> snakes = new Dictionary<int, int>();

int[] dx = new int[6] { 1, 2, 3, 4, 5, 6 };

int x = 0;
int y = 0;

int u = 0;
int v = 0;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    x = input[0];
    y = input[1];
    ladders.Add(x, y);
}

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    u = input[0];
    v = input[1];
    snakes.Add(u, v);
}

BFS(board, ladders, snakes, 1);
sw.WriteLine(board[100] - 1);
sw.Flush();
sw.Close();

void BFS(int[] board, Dictionary<int, int> ladders, Dictionary<int, int> snakes, int start)
{
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(start);
    board[start] = 1;
    int tmp = 0;
    int nx = 0;
    bool flag = false;

    while (queue.Count > 0)
    {
        tmp = queue.Dequeue();
        for (int i = 0; i < 6; i++)
        {
            nx = tmp + dx[i];

            if (nx >= 0 && nx <= 100)
            {
                if (snakes.ContainsKey(nx)) // 뱀이 있는 위치일 경우
                {
                    CheckBoard(board, tmp, nx); // 뱀이나 사다리가 있는 위치는 강제로 다른 위치로 이동하므로 Queue에 넣지 않음
                    flag = CheckBoard(board, tmp, snakes[nx]); 
                    if (flag) // 해당 위치로 최초 방문이거나 더 적은 횟수로 해당 위치에 방문했을 경우
                    {
                        queue.Enqueue(snakes[nx]);
                    }
                }
                else if (ladders.ContainsKey(nx)) // 사다리가 있는 위치일 경우
                {
                    CheckBoard(board, tmp, nx); // 뱀이나 사다리가 있는 위치는 강제로 다른 위치로 이동하므로 Queue에 넣지 않음
                    flag = CheckBoard(board, tmp, ladders[nx]);
                    if (flag) // 해당 위치로 최초 방문이거나 더 적은 횟수로 해당 위치에 방문했을 경우
                    {
                        queue.Enqueue(ladders[nx]);
                    }
                }
                else // 뱀 또는 사다리가 없는 위치일 경우
                {
                    flag = CheckBoard(board, tmp, nx);
                    if (flag)
                    {
                        queue.Enqueue(nx);
                    }
                }
            }
        }
    }
}

bool CheckBoard(int[] board, int beforeIndex, int nextIndex) 
{
    if (board[nextIndex] == 0) // 방문한 적이 없는 경우
    {
        board[nextIndex] = board[beforeIndex] + 1;
        return true;
    }
    else
    {
        if (board[nextIndex] > board[beforeIndex] + 1) // 더 적은 횟수로 해당 위치에 방문했을 경우
        {
            board[nextIndex] = board[beforeIndex] + 1;
            return true;
        }
    }

    return false;
}
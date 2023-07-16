/*
DFS : 896ms

StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[,] maze = new int[n, m];
int[,] visited = new int[n, m];
string str = null;
for (int i = 0; i < n; i++)
{
    str = Console.ReadLine();
    for (int j = 0; j < m; j++)
    {
        maze[i, j] = int.Parse(str[j].ToString());
    }
}

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };

DFS(maze, 0, 0, 1);
sw.WriteLine(maze[n - 1, m - 1]);
sw.Flush();
sw.Close();

void DFS(int[,] maze, int y, int x, int count)
{
    if (y < 0 || x < 0 || y >= n || x >= m) // 미로의 범위를 벗어나는 경우
    {
        return;
    }

    if (maze[y, x] == 0) // 미로에서 이동할 수 없는 칸
    {
        return;
    }

    if (visited[y, x] == 0) // 방문하지 않았을 때는 방문 체크를 하고, 미로에 칸수를 대입
    {
        visited[y, x] = 1;
        maze[y, x] = count;
    }
    else // 방문한 곳에 다시 방문하는 경우에는 미로의 칸수보다 작을 경우 대입하고 반복문을 다시 반복, 작지 않을 경우 반복문이 의미가 없으므로 바로 return
    {
        if (maze[y, x] > count)
        {
            maze[y, x] = count;
        }
        else
        {
            return;
        }
    }

    for (int i = 0; i < 4; i++)
    {
        DFS(maze, y + dy[i], x + dx[i], count + 1);
    }
}
*/

// BFS : 68ms

StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[,] maze = new int[n, m];
string str = null;
for (int i = 0; i < n; i++)
{
    str = Console.ReadLine();
    for (int j = 0; j < m; j++)
    {
        maze[i, j] = int.Parse(str[j].ToString());
    }
}

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };
BFS(maze, 0, 0);
sw.WriteLine(maze[n - 1, m - 1]);
sw.Flush();
sw.Close();

void BFS(int[,] maze, int y, int x)
{
    Queue<int[]> queue = new Queue<int[]>();
    queue.Enqueue(new int[2] { y, x });
    int[] temp = null;

    while (queue.Count > 0)
    {
        temp = queue.Dequeue();
        for (int i = 0; i < 4; i++)
        {
            if (temp[0] + dy[i] >= 0 && temp[0] + dy[i] < n && temp[1] + dx[i] >= 0 && temp[1] + dx[i] < m)
            {
                if (maze[temp[0] + dy[i], temp[1] + dx[i]] == 1)
                {
                    maze[temp[0] + dy[i], temp[1] + dx[i]] = maze[temp[0], temp[1]] + 1;
                    queue.Enqueue(new int[2] { temp[0] + dy[i], temp[1] + dx[i] });
                }
            }
        }
    }
}
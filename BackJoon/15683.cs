using System;
using System.Collections.Generic;
using System.Linq;

int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int[,] dp = new int[n, m];
List<int[]> cctvs = new List<int[]>();
int result = 0;
int count = 0;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < m; j++)
    {
        if (input[j] == 6 || input[j] == 0)
        {
            dp[i, j] = input[j];
            if (input[j] == 0)
            {
                result++;
            }
        }
        else
        {
            cctvs.Add(new int[2] { i, j });
            dp[i, j] = input[j];
        }
    }
}

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };
Queue<int[]> q = new Queue<int[]>();

List<int> list = new List<int>();
int min = int.MaxValue;
Permutation(4, cctvs.Count);

Console.WriteLine(min);

void Permutation(int end, int length)
{
    if (list.Count == length)
    {
        count = result;

        for (int i = 0; i < list.Count; i++)
        {
            Solve(i);
        }

        min = Math.Min(min, count);
        int[] temp = null;
        while (q.Count > 0)
        {
            temp = q.Dequeue();
            dp[temp[0], temp[1]] = 0;
        }

        return;
    }
    else
    {
        for (int i = 0; i < end; i++)
        {
            if (dp[cctvs[list.Count][0], cctvs[list.Count][1]] == 2 && (i == 2 || i == 3))
            {
                continue;
            }
            else if (dp[cctvs[list.Count][0], cctvs[list.Count][1]] == 5 && i != 0)
            {
                continue;
            }

            list.Add(i);
            Permutation(end, length);
            list.RemoveAt(list.Count - 1);
        }
    }
}

void DFS(int y, int x, int direction)
{
    int ny = 0;
    int nx = 0;

    if (direction != -1)
    {
        ny = y + dy[direction];
        nx = x + dx[direction];

        if (ny < 0 || nx < 0 || ny >= n || nx >= m)
        {
            return;
        }

        if (dp[ny, nx] == 6)
        {
            return;
        }

        if (dp[ny, nx] == 0)
        {
            dp[ny, nx] = -1;
            count--;
            q.Enqueue(new int[2] { ny, nx });
        }

        DFS(ny, nx, direction);
    }
    else
    {
        for (int i = 0; i < 4; i++)
        {
            ny = y + dy[i];
            nx = x + dx[i];

            if (ny < 0 || nx < 0 || ny >= n || nx >= m)
            {
                continue;
            }

            if (dp[ny, nx] == 6)
            {
                continue;
            }

            if (dp[ny, nx] == 0)
            {
                dp[ny, nx] = -1;
                count--;
                q.Enqueue(new int[2] { ny, nx });
            }

            DFS(ny, nx, i);
        }
    }
}

void Solve(int index)
{
    int y = cctvs[index][0];
    int x = cctvs[index][1];

    if (dp[y, x] == 1)
    {
        if (list[index] == 0)
        {
            DFS(y, x, 0);
        }
        else if (list[index] == 1)
        {
            DFS(y, x, 1);
        }
        else if (list[index] == 2)
        {
            DFS(y, x, 2);
        }
        else if (list[index] == 3)
        {
            DFS(y, x, 3);
        }
    }
    else if (dp[y, x] == 2)
    {
        if (list[index] == 0)
        {
            DFS(y, x, 2);
            DFS(y, x, 3);
        }
        else if (list[index] == 1)
        {
            DFS(y, x, 0);
            DFS(y, x, 1);
        }
    }
    else if (dp[y, x] == 3)
    {
        if (list[index] == 0)
        {
            DFS(y, x, 0);
            DFS(y, x, 3);
        }
        else if (list[index] == 1)
        {
            DFS(y, x, 3);
            DFS(y, x, 1);
        }
        else if (list[index] == 2)
        {
            DFS(y, x, 1);
            DFS(y, x, 2);
        }
        else if (list[index] == 3)
        {
            DFS(y, x, 2);
            DFS(y, x, 0);
        }
    }
    else if (dp[y, x] == 4)
    {
        if (list[index] == 0)
        {
            DFS(y, x, 2);
            DFS(y, x, 0);
            DFS(y, x, 3);
        }
        else if (list[index] == 1)
        {
            DFS(y, x, 0);
            DFS(y, x, 3);
            DFS(y, x, 1);
        }
        else if (list[index] == 2)
        {
            DFS(y, x, 3);
            DFS(y, x, 1);
            DFS(y, x, 2);
        }
        else if (list[index] == 3)
        {
            DFS(y, x, 1);
            DFS(y, x, 2);
            DFS(y, x, 0);
        }
    }
    else if (dp[y, x] == 5)
    {
        DFS(y, x, -1);
    }
}

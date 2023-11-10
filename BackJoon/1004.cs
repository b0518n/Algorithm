using System.IO;
using System.Collections.Generic;
using System.Text;
using System;

StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
int t = int.Parse(Console.ReadLine());

for (int i = 0; i < t; i++)
{
    int[] arr = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);

    int x1 = arr[0];
    int y1 = arr[1];

    int x2 = arr[2];
    int y2 = arr[3];

    int count = 0;
    int retValue = 0;

    int n = int.Parse(Console.ReadLine());
    for (int j = 0; j < n; j++)
    {
        int[] _arr = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);

        int x = _arr[0];
        int y = _arr[1];
        int r = _arr[2];

        // 출발점과 도착점 모두 원 안에 존재할 경우는 행성계의 진입/이탈 할 필요가 없음 : count == 2
        // 출발점 또는 도착점 둘 중 한 점이 원 안에 존재 할 경우 진입/이탈 할 필요가 있음 : count == 1
        if (Math.Pow((x - x1), 2) + Math.Pow((y - y1), 2) < Math.Pow(r, 2))
        {
            count += 1;
        }

        if (Math.Pow((x - x2), 2) + Math.Pow((y - y2), 2) < Math.Pow(r, 2))
        {
            count += 1;
        }

        if (count == 2)
        {
            count = 0;
        }
        else if (count == 1)
        {
            retValue += 1;
            count = 0;
        }
    }
    sw.WriteLine(retValue);
}
sw.Close();
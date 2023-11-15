using System.IO;
using System.Diagnostics;
using System.Numerics;
using System;

StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

int[] input = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);

int w = input[0]; // 가로 길이
int h = input[1]; // 세로 길이
int x = input[2]; // 직사각형의 왼쪽 아래 점의 x좌표
int y = input[3]; // 직사각형의 왼쪽 아래 점의 y좌표

int p = input[4];

int radius = h / 2; // 반원들의 반지름
int count = 0; // 인원 수

int _x;
int _y;

for (int i = 0; i < p; i++)
{
    int[] tmp = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
    _x = tmp[0];
    _y = tmp[1];

    // 맨 왼쪽 반원안에 좌표가 존재할 경우
    // 조건 1. x - radius <= _x <= x and y <= _y <= y + h
    // 조건 2. math.pow((_x - x),2) + math.pow((_y - y), 2) <= math.pow((radius), 2)
    if (x - radius <= _x && _x <= x && y <= _y && _y <= y + h)
    {
        if (Math.Pow((_x - x), 2) + Math.Pow((_y - (y + radius)), 2) <= Math.Pow(radius, 2))
        {
            count += 1;
        }
    }

    // 중앙 직사각형에 좌표가 존재할 경우 (원과 직사각형의 경계를 포함하지 않음으로써 중복 방지)
    if (x < _x && _x < x + w && y <= _y && _y <= y + h)
    {
        count += 1;
    }

    // 맨 오른쪽 반원안에 좌표가 존재할 경우
    if (x + w <= _x && x <= x + w + radius && y <= _y && _y <= y + h)
    {
        if (Math.Pow((_x - (x + w)), 2) + Math.Pow((_y - (y + radius)), 2) <= Math.Pow(radius, 2))
        {
            count += 1;
        }
    }
}

sw.Write(count);
sw.Close();


﻿int n = int.Parse(Console.ReadLine());
int[] input = null;
int a = 0;
int b = 0;
for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];

    Console.WriteLine(a + b);
}
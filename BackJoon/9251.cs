﻿StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

int start = 0;
int end = 0;
int sum = 0;

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    start = input[0] - 1;
    end = input[1] - 1;

    for (int k = start; k <= end; k++)
    {
        sum += arr[k];
    }

    sw.WriteLine(sum);
    sum = 0;
}

sw.Close();
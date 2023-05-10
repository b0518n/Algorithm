using System;

int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

string[] arr = new string[n];

for (int i = 0; i < n; i++)
{
    arr[i] = Console.ReadLine();
}

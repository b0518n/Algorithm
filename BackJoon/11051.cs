using System.Numerics;
using System.IO;
using System;

StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

// int형으로 배열을 만들 경우 런타임 에러(NZEC) 발생
// 0! ~ 1000! 까지의 모든 값을 arr에 담아서 retValue값은 해당 배열의 인덱스를 이용해,
// 계산된 값을 뽑아서 계산하는 방식을 이용함.
BigInteger[] arr = new BigInteger[1001];

for (int i = 0; i < arr.Length; i++)
{
    if (i < 2)
    {
        arr[i] = 1;
    }
    else
    {
        arr[i] = (arr[i - 1] * i);
    }
}

int[] input = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
int n = input[0];
int k = input[1];
BigInteger retValue = (arr[n] / (arr[k] * arr[n - k]) % 10007);

sw.Write(retValue);
sw.Close();

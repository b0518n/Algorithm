using System.Text;

StringBuilder sb = new StringBuilder();
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int begin = 0;
int mid = 0;
int end = 0;

int[] arr = new int[n];
for (int i = 0; i < n; i++)
{
    arr[i] = i + 1;
}
int[] arr1 = (int[])arr.Clone();

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    begin = input[0];
    end = input[1];
    mid = input[2];

    if (begin == mid)
    {
        // 변화 없음
    }
    else if (end == mid)
    {
        arr[begin - 1] = arr[mid - 1];
        for (int j = begin; j <= end - 1; j++)
        {
            arr[j] = arr1[j - 1];
        }

    }
    else
    {
        int k = 0;
        for (int j = mid - 1; j <= end - 1; j++)
        {
            arr[begin - 1 + k] = arr1[j];
            k++;
        }

        int l = 0;
        for (int j = begin - 1 + k; j <= end - 1; j++)
        {
            arr[j] = arr1[begin - 1 + l];
            l++;
        }
    }

    arr1 = (int[])arr.Clone();
}

for (int k = 0; k < arr.Length; k++)
{
    sb.Append(arr[k] + " ");
}

Console.WriteLine(sb.ToString());
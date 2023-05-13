// 1. 8 x 8 보다 더 크게 주어진 정사각형을 8x8 배열로 만드는 함수를 만들고,
// 2. 만들어진 배열을 넣으면 색깔을 칠하는 함수를 만듬.
// 주의점 : 매개변수로 배열을 넣을 경우 포인터가 복사 생성되기 때문에 원본 배열에 영향을 미치는 경우가 발생 : clone함수를 이용해 배열을 복사생성하는 방식으로 해결

int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

char[,] arr = new char[n, m];
int min = 64;

for (int i = 0; i < n; i++)
{
    char[] tmp = Console.ReadLine().ToArray();
    for (int j = 0; j < tmp.Length; j++)
    {
        arr[i, j] = tmp[j];
    }
}


for (int i = 0; i <= n - 8; i++)
{
    for (int j = 0; j <= m - 8; j++)
    {
        MakeArr((char[,])arr.Clone(), i, j);
    }
}

Console.WriteLine(min);

void MakeArr(char[,] arr, int startY, int startX)
{
    char[,] newArr = new char[8, 8];

    for (int i = startY; i < startY + 8; i++)
    {
        for (int j = startX; j < startX + 8; j++)
        {
            newArr[i - startY, j - startX] = arr[i, j];
        }
    }

    CountChangeColor((char[,])newArr.Clone(), 'W');
    CountChangeColor((char[,])newArr.Clone(), 'B');
}

void CountChangeColor(char[,] arr, char color)
{
    int count = 0;

    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            if (i == 0 && j == 0)
            {
                if (arr[i, j] != color)
                {
                    if (arr[i, j] == 'W')
                    {
                        arr[i, j] = 'B';
                    }
                    else
                    {
                        arr[i, j] = 'W';
                    }

                    count++;
                }

            }
            else if (i != 0 && j == 0)
            {
                if (arr[i - 1, j] == arr[i, j])
                {
                    if (arr[i, j] == 'W')
                    {
                        arr[i, j] = 'B';
                    }
                    else
                    {
                        arr[i, j] = 'W';
                    }
                    count++;
                }
            }
            else
            {
                if (arr[i, j - 1] == arr[i, j])
                {
                    if (arr[i, j] == 'W')
                    {
                        arr[i, j] = 'B';
                    }
                    else
                    {
                        arr[i, j] = 'W';
                    }

                    count++;
                }
            }
        }
    }

    if (min > count)
    {
        min = count;
    }

}
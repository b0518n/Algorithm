/*
시간초과

StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
int[] heights = new int[n];
int input = 0;

List<int> stack = new List<int>();
long count = 0;
int index = 0;

for (int i = 0; i < n; i++)
{
    input = int.Parse(Console.ReadLine());
    heights[i] = input;

    index = stack.Count - 1;
    while (stack.Count > 0 && index >= 0 && heights[stack[index]] <= input)
    {
        count++;
        if (heights[stack[index]] < heights[i])
        {
            stack.RemoveAt(stack.Count - 1);
        }

        index--;
    }

    if (index >= 0)
    {
        count++;
    }

    stack.Add(i);
}

sw.WriteLine(count);
sw.Flush();
sw.Close();

*/

StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
int[] heights = new int[n];
int input = 0;

List<int[]> stack = new List<int[]>();
long count = 0;
int index = 0;

// 시간을 줄이기 위해 입력과 동시에 문제 해결 로직 수행.
// stack에 인덱스 대신 크기가 2인 배열 (인덱스, 개수)을 받음으로써 같은 수는 1번만 비교할 수 있도록 설계
for (int i = 0; i < n; i++)
{
    input = int.Parse(Console.ReadLine());
    heights[i] = input;

    index = stack.Count - 1;
    while (stack.Count > 0 && index >= 0 && heights[stack[index][0]] < heights[i]) // 입력된 값이 스택의 맨 위에 있는 값보다 큰 경우
    {
        count += stack[index][1];
        stack.RemoveAt(stack.Count - 1);
        index = stack.Count - 1;
    }

    if (index >= 0) // stack안에 요소가 없어서 반복문을 빠져 나온 것이 아닌, 스택 맨 위의 값이 입력 값보다 크거나 같은 경우
    {
        if (heights[stack[index][0]] == heights[i]) // 같은 경우
        {
            count += stack[index][1];
            index--;
            if (index >= 0) // 스택의 맨 위의 값보다 큰 값이 있을 경우
            {
                count++;
            }

            stack[index + 1][1]++;
        }
        else // 큰 경우
        {
            count++;
            stack.Add(new int[2] { i, 1 });
        }
    }
    else // stack 안 요소가 없어서 반복문을 빠져 나왔을 경우
    {
        stack.Add(new int[2] { i, 1 });
    }
}

sw.WriteLine(count);
sw.Flush();
sw.Close();

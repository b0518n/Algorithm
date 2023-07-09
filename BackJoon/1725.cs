StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
int[] rectangles = new int[n + 2];

for (int i = 1; i <= n; i++)
{
    rectangles[i] = int.Parse(Console.ReadLine());
}

List<int> stack = new List<int>();
long result = 0;
int h = 0;
int w = 0;

// 반복문을 통해 해당 값은 스택에서 지워지지 않음
// 입력 조건에서 높이는 1,000,000,000보다 작거나 같은 자연수 또는 0이기 때문에
// 0보다 크거나 같은 경우만 입력됨.
stack.Add(0); 

for (int i = 1; i <= n + 1; i++)
{
    // 입력된 값이 스택 안의 값보다 크거나 같을 경우 : 스택에 넣음
    // 입력된 값이 스택 안의 값보다 작을 경우 : 순차적으로 입력된 값보다 큰 숫자들을 제거하면서 넓이의 최대값을 구함.
    // 예를 들어 rectangles = {0, 1, 4, 5, 1, 0} 일 경우, (주어진 입력은 1 4 5 1 이지만,
    // 맨 앞의 0은 stack에 집어넣고 지우는 과정에서 out of index error를 방지하기 위해서 넣었음.
    // 맨 뒤의 0은 맨 끝까지의 직사각형의 최대 넓이를 구하는 과정을 수행하기 위해서 넣음
    // 0은 맨 앞에있는 0를 제외하고는 모든 입력되는 수보다 작기 때문에 스택 안의 모든 입력된 숫자를 지우면서 넓이를 구하는 과정을 수행하도록 함.
    // i = 1 : {0, 1}
    // i = 2 : {0, 1, 2}
    // i = 3 : {0, 1, 2, 3}
    // i = 4인 경우
    // rectangles[4]는 rectangles[3]보다 작으므로 h = rectangles[3], w = (4 - 1) - 2 = 1, result = 5,
    // rectangles[4]는 rectangles[2]보다 작으므로 h = rectangles[2], w = (4 - 1) - 1 = 2 result = 8,
    // rectangles[4]는 rectangles[1]과 같으므로 stack = {0, 1, 4}, result = 8,
    // i = 5인 경우
    // rectangles[5]는 rectangles[4]보다 작으므로 h = rectangles[4], w = (5 - 1) - 1 = 3, w * h = 3, result = 8,
    // rectangles[5]는 rectangles[1]보다 작으므로 h = rectangles[1], w = (5 - 1) - 0 = 4, w * h = 4, result = 8,
    // rectangles[5]는 rectangeles[0]과 같으므로 stack = {0, 0}, result = 8 으로 반복문이 종료 됨
    while (stack.Count != 0 && rectangles[stack[stack.Count - 1]] > rectangles[i])
    {
        // stack의 맨 위 값보다 작은 수가 나왔을 경우 h는 stack의 맨 위의 값 (현재 스택에서 가장 큰 값)
        h = rectangles[stack[stack.Count - 1]];
        stack.RemoveAt(stack.Count - 1);
        w = (i - 1) - stack[stack.Count - 1]; 
        result = (result < h * w ? h * w : result);
    }

    stack.Add(i);
}

sw.WriteLine(result);
sw.Flush();
sw.Close();
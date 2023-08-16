StringBuilder sb = new StringBuilder();
Stack<int> stack = new Stack<int>();
int[] input = null;

using (StreamReader sr = new StreamReader(Console.OpenStandardInput()))
{
    int n = int.Parse(sr.ReadLine());
    for (int i = 0; i < n; i++)
    {
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        switch (input[0])
        {
            case 1:
                Push(stack, input[1]);
                break;
            case 2:
                PopAndPrint(stack, sb);
                break;
            case 3:
                PrintCount(stack, sb);
                break;
            case 4:
                IsEmpty(stack, sb);
                break;
            case 5:
                PrintTop(stack, sb);
                break;
        }
    }
}

Console.WriteLine(sb.ToString());

static void Push(Stack<int> stack, int value)
{
    stack.Push(value);
}

static void PopAndPrint(Stack<int> stack, StringBuilder sb)
{
    if (stack.Count == 0)
    {
        sb.AppendLine((-1).ToString());
    }
    else
    {
        sb.AppendLine(stack.Pop().ToString());
    }
}

static void PrintCount(Stack<int> stack, StringBuilder sb)
{
    sb.AppendLine(stack.Count.ToString());
}

static void IsEmpty(Stack<int> stack, StringBuilder sb)
{
    if (stack.Count == 0)
    {
        sb.AppendLine(1.ToString());
    }
    else
    {
        sb.AppendLine(0.ToString());
    }
}

static void PrintTop(Stack<int> stack, StringBuilder sb)
{
    if (stack.Count == 0)
    {
        sb.AppendLine((-1).ToString());
    }
    else
    {
        sb.AppendLine(stack.Peek().ToString());
    }
}
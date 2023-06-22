// stack
StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string str = null;

int[] input = null;
int n = 0;
int[] arr = null;
long result = 0;

while (true)
{
    str = sr.ReadLine();
    if (str == "0")
    {
        break;
    }

    input = Array.ConvertAll(str.Split(), int.Parse);
    n = input[0];
    arr = new int[n];
    for (int i = 1; i < input.Length; i++)
    {
        arr[i - 1] = input[i];
    }

    result = GetLargestRectangleArea(arr);
    sw.WriteLine(result);
}

sw.Flush();
sw.Close();
sr.Close();

long GetLargestRectangleArea(int[] arr)
{
    List<int> stack = new List<int>();
    long max = 0;
    int i = 0;

    while (i < arr.Length)
    {
        if (stack.Count == 0 || arr[i] >= arr[stack[stack.Count - 1]])
        {
            stack.Add(i);
            i++;
        }
        else
        {
            int top = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            long value = (long)arr[top] * (i - (stack.Count == 0 ? 0 : stack[stack.Count - 1] + 1));
            max = Math.Max(max, value);
        }
    }

    while (stack.Count > 0)
    {
        int top = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);
        long value = (long)arr[top] * (arr.Length - (stack.Count == 0 ? 0 : stack[stack.Count - 1] + 1));
        max = Math.Max(max, value);
    }

    return max;
}
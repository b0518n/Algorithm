StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] nges = new int[n];
List<int> stack = new List<int>();

for (int i = 0; i < nges.Length; i++)
{
    nges[i] = -1;
}

for (int i = 0; i < input.Length; i++)
{
    while (stack.Count != 0 && input[stack[stack.Count - 1]] < input[i])
    {
        nges[stack[stack.Count - 1]] = input[i];
        stack.RemoveAt(stack.Count - 1);
    }

    stack.Add(i); // 값이 아닌 인덱스를 넣음.
}

for (int i = 0; i < nges.Length; i++)
{
    if (i == 0)
    {
        sw.Write(nges[i]);
    }
    else
    {
        sw.Write(" " + nges[i]);
    }
}

sw.Flush();
sw.Close();
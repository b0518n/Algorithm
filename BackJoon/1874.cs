StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
int input = 0;
List<int> list = new List<int>();
List<int> stack = new List<int>();
List<string> result = new List<string>();
for (int i = 0; i < n; i++)
{
    input = int.Parse(Console.ReadLine());
    list.Add(input);
}

int index = 0;

for (int i = 1; i <= n; i++)
{
    if (stack.Count == 0)
    {
        result.Add("+");
        stack.Add(i);
        continue;
    }

    if (list[index] == stack[stack.Count - 1])
    {
        result.Add("-");
        stack.RemoveAt(stack.Count - 1);
        index++;
        i--;
    }
    else
    {
        result.Add("+");
        stack.Add(i);
        continue;
    }

}

bool flag = false;

while (true)
{
    if (stack.Count == 0)
    {
        break;
    }

    if (list[index] == stack[stack.Count - 1])
    {
        result.Add("-");
        stack.RemoveAt(stack.Count - 1);
        index++;
    }
    else
    {
        flag = true;
        break;
    }
}

if (flag == true)
{
    sw.WriteLine("NO");
}
else
{
    for (int i = 0; i < result.Count; i++)
    {
        sw.WriteLine(result[i]);
    }
}

sw.Close();
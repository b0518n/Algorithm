StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
List<string> stack = new List<string>();
string str = Console.ReadLine();
string bombStr = Console.ReadLine();

Solve(str, bombStr);

if (stack.Count == 0)
{
    sw.Write("FRULA");
}
else
{
    for (int i = 0; i < stack.Count; i++)
    {
        sw.Write(stack[i]);
    }
}
sw.Flush();
sw.Close();

void Solve(string str, string bombStr) 
{
    string temp = string.Empty;

    for (int i = 0; i < str.Length; i++)
    {
        stack.Add(str[i].ToString());

        if (stack.Count >= bombStr.Length)
        {
            for (int j = stack.Count - 1 - bombStr.Length + 1; j < stack.Count; j++)
            {
                temp += stack[j];
            }

            if (temp == bombStr)
            {
                for (int j = 0; j < bombStr.Length; j++)
                {
                    stack.RemoveAt(stack.Count - 1);
                }
            }

            temp = string.Empty;
        }
    }
}
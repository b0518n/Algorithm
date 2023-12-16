int t = int.Parse(Console.ReadLine());
int n = 0;
int[] costs = null;
Stack<int> stack = null;
long result = 0;

for (int i = 0; i < t; i++)
{
    n = int.Parse(Console.ReadLine());
    costs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    stack = new Stack<int>();
    result = 0;

    for (int j = n - 1; j >= 0; j--)
    {
        if (stack.Count == 0)
        {
            stack.Push(costs[j]);
        }
        else
        {
            if (stack.Peek() > costs[j])
            {
                result += stack.Peek() - costs[j];
            }
            else if (stack.Peek() < costs[j])
            {
                stack.Pop();
                stack.Push(costs[j]);
            }
        }
    }

    Console.WriteLine(result);
}
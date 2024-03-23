StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int t = 0;
int input = 0;
int maxValue = 0;

List<int> list = new List<int>();
List<int> fibonacci = new List<int>();
fibonacci.Add(0);
fibonacci.Add(1);

Input();
Solve();

void Input()
{
    t = int.Parse(sr.ReadLine());
    for (int i = 0; i < t; i++)
    {
        input = int.Parse(sr.ReadLine());
        list.Add(input);
        maxValue = Math.Max(maxValue, input);
    }
}
void Solve()
{
    while (maxValue > fibonacci[fibonacci.Count - 1])
    {
        fibonacci.Add(fibonacci[fibonacci.Count - 1] + fibonacci[fibonacci.Count - 2]);
    }

    int value = 0;
    Stack<int> temp = new Stack<int>();

    for (int i = 0; i < t; i++)
    {
        value = list[i];

        for (int j = fibonacci.Count - 1; j > 0; j--)
        {
            if (fibonacci[j] <= value)
            {
                temp.Push(fibonacci[j]);
                value -= fibonacci[j];
            }
        }

        while (temp.Count > 1)
        {
            sw.Write(temp.Pop());
            sw.Write(" ");
        }

        sw.WriteLine(temp.Pop());
    }

    sw.Flush();
    sw.Close();
}
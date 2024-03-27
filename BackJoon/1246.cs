StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] input = null;
int n = 0;
int m = 0;
List<int> costs = new List<int>();

int value = 0;
long max = 0;

Input();
costs.Sort();
max = SetPrice();
Print();

void Input()
{
    input = sr.ReadLine().Split();
    n = int.Parse(input[0]);
    m = int.Parse(input[1]);

    for (int i = 0; i < m; i++)
    {
        costs.Add(int.Parse(sr.ReadLine()));
    }
}

long SetPrice()
{
    int index = costs.Count;
    int price = 0;
    int length = costs.Count;
    long retValue = 0;

    while (true)
    {
        index--;
        price = costs[index];

        if (length - index >= n)
        {
            if (retValue <= price * (length - index))
            {
                retValue = price * (length - index);
                value = price;
            }
            break;
        }
        else
        {
            if (retValue <= price * (length - index))
            {
                retValue = price * (length - index);
                value = price;
            }
        }

        if (index == 0)
        {
            break;
        }
    }

    return retValue;
}

void Print()
{
    sw.WriteLine($"{value} {max}");
    sw.Flush();
    sw.Close();
}
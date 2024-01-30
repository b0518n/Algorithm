StreamReader reader = new StreamReader(Console.OpenStandardInput());
StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(reader.ReadLine());
string[] arr = reader.ReadLine().Split(" ");
int[] visited = new int[10];
List<int> container = new List<int>();
string maxValue = null;
string minValue = null;

CalculateMaxValue();
CalculateMinValue();

writer.WriteLine(maxValue);
writer.WriteLine(minValue);
writer.Close();

void CalculateMaxValue()
{
    if (maxValue != null)
    {
        return;
    }

    if (container.Count == n + 1)
    {
        maxValue = string.Join("", container);
        return;
    }

    if (container.Count == 0)
    {
        for (int i = 9; i >= 0; i--)
        {
            container.Add(i);
            visited[i] = 1;
            CalculateMaxValue();
            container.RemoveAt(container.Count - 1);
            visited[i] = 0;
        }
    }
    else
    {
        for (int i = 9; i >= 0; i--)
        {
            if (arr[container.Count - 1] == "<" && container[container.Count - 1] < i && visited[i] == 0)
            {
                container.Add(i);
                visited[i] = 1;
                CalculateMaxValue();
                container.RemoveAt(container.Count - 1);
                visited[i] = 0;
            }
            else if (arr[container.Count - 1] == ">" && container[container.Count - 1] > i && visited[i] == 0)
            {
                container.Add(i);
                visited[i] = 1;
                CalculateMaxValue();
                container.RemoveAt(container.Count - 1);
                visited[i] = 0;
            }
        }
    }
}
void CalculateMinValue()
{
    if (minValue != null)
    {
        return;
    }

    if (container.Count == n + 1)
    {
        minValue = string.Join("", container);
        return;
    }

    if (container.Count == 0)
    {
        for (int i = 0; i <= 9; i++)
        {
            container.Add(i);
            visited[i] = 1;
            CalculateMinValue();
            container.RemoveAt(container.Count - 1);
            visited[i] = 0;
        }
    }
    else
    {
        for (int i = 0; i <= 9; i++)
        {
            if (arr[container.Count - 1] == "<" && container[container.Count - 1] < i && visited[i] == 0)
            {
                container.Add(i);
                visited[i] = 1;
                CalculateMinValue();
                container.RemoveAt(container.Count - 1);
                visited[i] = 0;
            }
            else if (arr[container.Count - 1] == ">" && container[container.Count - 1] > i && visited[i] == 0)
            {
                container.Add(i);
                visited[i] = 1;
                CalculateMinValue();
                container.RemoveAt(container.Count - 1);
                visited[i] = 0;
            }
        }
    }
}
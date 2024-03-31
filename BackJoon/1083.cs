StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = 0;
int[] arr = null;
int s = 0;

Input();
Sort();
Print();

void Input()
{
    n = int.Parse(sr.ReadLine());
    arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    s = int.Parse(sr.ReadLine());
}
void Sort()
{
    int index = 0;
    int max = 0;
    int distance = 0;

    while (true)
    {
        for (int i = index; i <= index + s; i++)
        {
            if (i > arr.Length - 1)
            {
                break;
            }

            if (max == 0)
            {
                max = arr[i];
                distance = i - index;
            }
            else
            {
                if (max < arr[i])
                {
                    max = arr[i];
                    distance = i - index;
                }
            }
        }

        if (distance == 0)
        {
            index++;
        }
        else
        {
            for (int i = index + distance; i > index; i--)
            {
                Swap(i, i - 1);
            }

            index++;
            s -= distance;
        }

        max = 0;
        distance = 0;

        if (s == 0 || index > arr.Length - 1)
        {
            break;
        }

    }
}
void Print()
{
    sw.WriteLine(string.Join(" ", arr));
    sw.Flush();
    sw.Close();
}
void Swap(int index1, int index2)
{
    int tValue = arr[index1];
    arr[index1] = arr[index2];
    arr[index2] = tValue;
}
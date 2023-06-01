StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
string input = null;
int[] arr = null; // 1 : 공백, 0 : "-"
while (true)
{
    input = Console.ReadLine();
    if (input == null)
    {
        break;
    }

    arr = new int[(int)Math.Pow(3, int.Parse(input))];
    Recusion(arr, 0, arr.Length - 1);

    for (int i = 0; i < arr.Length; i++)
    {
        if (i == arr.Length - 1)
        {
            if (arr[i] == 1)
            {
                sw.WriteLine(" ");
            }
            else
            {
                sw.WriteLine('-');
            }
        }
        else
        {
            if (arr[i] == 1)
            {
                sw.Write(" ");
            }
            else
            {
                sw.Write('-');
            }
        }
    }
}

sw.Close();

void Recusion(int[] arr, int start, int end)
{
    if (start == end)
    {
        return;
    }

    int interval = (end - start + 1) / 3;
    Recusion(arr, start, start + interval - 1);
    Recusion_zero(arr, start + interval, start + (2 * interval) - 1);
    Recusion(arr, start + (2 * interval), end);
}

void Recusion_zero(int[] arr, int start, int end)
{
    for (int i = start; i <= end; i++)
    {
        arr[i] = 1;
    }
}
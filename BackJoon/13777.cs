StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int input = 0;


while (true)
{
    input = int.Parse(sr.ReadLine());
    if (input == 0)
    {
        break;
    }
    else
    {
        SearchValue();
    }
}

sw.Flush();
sw.Close();

void SearchValue()
{
    int start = 1;
    int end = 50;
    int mid = 0;


    while (true)
    {
        mid = (start + end) / 2;

        if (mid == input)
        {
            sw.WriteLine(mid);
            break;
        }

        sw.Write(mid + " ");
        if (mid > input)
        {
            end = mid - 1;
        }
        else
        {
            start = mid + 1;
        }
    }
}
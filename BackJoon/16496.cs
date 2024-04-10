StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = 0;
string[] arr = null;

Input();
Array.Sort(arr, (x, y) =>
{
    int compare = 0;

    string strA = x + y;
    string strB = y + x;
    int index = 0;

    while (true)
    {
        if (index > strA.Length - 1)
        {
            compare = 0;
            break;
        }

        if (int.Parse(strA[index].ToString()) == int.Parse(strB[index].ToString()))
        {
            index++;
        }
        else if (int.Parse(strA[index].ToString()) > int.Parse(strB[index].ToString()))
        {
            compare = -1;
            break;
        }
        else
        {
            compare = 1;
            break;
        }
    }

    return compare;
});
Print();

void Input()
{
    n = int.Parse(sr.ReadLine());
    arr = sr.ReadLine().Split();
}
void Print()
{
    if (int.Parse(arr[0]) == 0)
    {
        sw.WriteLine(0);
    }
    else
    {
        sw.WriteLine(string.Join("", arr));
    }

    sw.Flush();
    sw.Close();
}
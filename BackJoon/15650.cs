StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

List<int> list = new List<int>();
PrintValue(1);

void PrintValue(int k)
{
    if (list.Count == m)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (i == list.Count - 1)
            {
                sw.WriteLine(list[i]);
            }
            else
            {
                sw.Write(list[i] + " ");
            }

        }
    }
    else
    {
        for (int i = k; i <= n; i++)
        {

            list.Add(i);
            PrintValue(i);
            list.RemoveAt(list.Count - 1);


        }
    }
}

sw.Close();
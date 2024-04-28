StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int k = input[2];

Queue<int> q = new Queue<int>();
for (int i = 0; i < m; i++)
{
    q.Enqueue(int.Parse(sr.ReadLine()));
}

Dictionary<int, int> dictionary = new Dictionary<int, int>();

int middle = 0;
int left = 0;
int right = 0;

if (k == 0)
{
    sw.WriteLine(m);
}
else
{
    int cnt = 0;
    int number = 0;

    while (true)
    {
        cnt++;
        number = q.Count;

        for (int i = 0; i < number; i++)
        {
            middle = q.Dequeue();
            left = middle - 1 < 0 ? n - 1 : middle - 1;
            right = middle + 1 > n - 1 ? 0 : middle + 1;

            if (dictionary.ContainsKey(left))
            {
                dictionary.Remove(left);
            }
            else
            {
                dictionary.Add(left, 1);
            }

            if (dictionary.ContainsKey(right))
            {
                dictionary.Remove(right);
            }
            else
            {
                dictionary.Add(right, 1);
            }
        }

        if (dictionary.Count == 0)
        {
            break;
        }
        else
        {
            foreach (int key in dictionary.Keys)
            {
                q.Enqueue(key);
            }
        }

        if (cnt == k)
        {
            break;
        }


        dictionary.Clear();
    }

    sw.WriteLine(dictionary.Count);
}

sw.Flush();
sw.Close();
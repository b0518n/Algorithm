StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
string input = sr.ReadLine();

Queue<string> q = new Queue<string>();
List<string> list = new List<string>();

for (int i = 0; i < input.Length; i++)
{
    q.Enqueue(input[i].ToString());
}

while (q.Count > 0)
{
    list.Add(string.Join("", q));
    q.Dequeue();
}

list.Sort();
for (int i = 0; i < list.Count; i++)
{
    sw.WriteLine(list[i]);
}

sw.Flush();
sw.Close();
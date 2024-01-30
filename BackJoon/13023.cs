StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0], m = input[1];
bool result = false;

Human[] relationships = new Human[n];
for (int i = 0; i < n; i++)
{
    relationships[i] = new Human(i);
}

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    relationships[input[0]].AddRelationship(input[1], relationships[input[1]]);
    relationships[input[1]].AddRelationship(input[0], relationships[input[0]]);
}

for (int i = 0; i < n; i++)
{
    result = IsContainFiveRelationship(relationships[i], 1, new int[n]);

    if (result)
    {
        break;
    }
}

if (result)
{
    sw.WriteLine(1);
}
else
{
    sw.WriteLine(0);
}

sw.Close();

bool IsContainFiveRelationship(Human human, int cnt, int[] visited)
{
    visited[human.index] = 1;
    bool result = false;

    if (cnt == 5)
    {
        return true;
    }

    foreach (int key in human.friends.Keys)
    {
        if (visited[key] == 1)
        {
            continue;
        }

        visited[key] = 1;
        result = IsContainFiveRelationship(relationships[key], cnt + 1, visited);
        visited[key] = 0;

        if (result == true)
        {
            return true;
        }
    }

    return result;
}

class Human
{
    public int index;
    public Dictionary<int, Human> friends;

    public Human(int index)
    {
        this.index = index;
        this.friends = new Dictionary<int, Human>();
    }

    public void AddRelationship(int index, Human human)
    {
        if (!friends.ContainsKey(index))
        {
            friends.Add(index, human);
        }
    }
}
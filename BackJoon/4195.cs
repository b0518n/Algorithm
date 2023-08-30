StringBuilder sb = new StringBuilder();
int t = int.Parse(Console.ReadLine());
int f = 0;

string[] input = null;
string str1 = null;
string str2 = null;

Dictionary<string, string> parent = new Dictionary<string, string>();
Dictionary<string, int> rank = new Dictionary<string, int>();
int result = 0;

for (int i = 0; i < t; i++)
{
    f = int.Parse(Console.ReadLine());
    for (int j = 0; j < f; j++)
    {
        input = Console.ReadLine().Split();
        str1 = input[0];
        str2 = input[1];

        if (!parent.ContainsKey(str1))
        {
            parent[str1] = str1;
            rank[str1] = 1;
        }

        if (!parent.ContainsKey(str2))
        {
            parent[str2] = str2;
            rank[str2] = 1;
        }

        result = merge(str1, str2, parent, rank);
        sb.AppendLine(result.ToString());
    }

    parent.Clear();
    rank.Clear();
}

Console.WriteLine(sb.ToString());

int merge(string str1, string str2, Dictionary<string, string> parent, Dictionary<string, int> rank)
{
    string parent1 = find(str1, parent);
    string parent2 = find(str2, parent);

    if (parent1 != parent2)
    {
        if (rank[parent1] > rank[parent2])
        {
            parent[parent2] = parent1;
            rank[parent1] += rank[parent2];
            return rank[parent1];
        }
        else
        {
            parent[parent1] = parent2;
            rank[parent2] += rank[parent1];
            return rank[parent2];
        }
    }

    return rank[parent1];
}

string find(string str1, Dictionary<string, string> parent)
{
    if (str1 != parent[str1])
    {
        parent[str1] = find(parent[str1], parent);
    }

    return parent[str1];
}
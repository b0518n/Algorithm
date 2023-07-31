StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
int[] input = null;

int a = 0;
int b = 0;

TreeNode root = new TreeNode(1);

int[] visited = new int[n + 1];
List<int>[] graph = new List<int>[n + 1];
for (int i = 1; i < n + 1; i++)
{
    graph[i] = new List<int>();
}

for (int i = 1; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];

    graph[a].Add(b);
    graph[b].Add(a);
}

TreeNode.AddNode(root, visited, graph, 0);

for (int i = 2; i <= n; i++)
{
    sw.WriteLine(TreeNode.parents[i]);
}

sw.Flush();
sw.Close();

class TreeNode
{
    public int number;
    public List<TreeNode> nodes;

    public static int[] parents = new int[100001];

    public TreeNode(int number)
    {
        this.number = number;
        nodes = new List<TreeNode>();
    }

    // DFS
    public static void AddNode(TreeNode node, int[] visited, List<int>[] graph, int parentsNumber)
    {
        visited[node.number] = 1; // 방문처리
        TreeNode.parents[node.number] = parentsNumber; // 부모노드를 기록
        TreeNode temp = null;

        for (int i = 0; i < graph[node.number].Count; i++)
        {
            if (visited[graph[node.number][i]] == 0)
            {
                temp = new TreeNode(graph[node.number][i]);
                node.nodes.Add(temp);
                AddNode(temp, visited, graph, node.number);
            }
        }
    }
}
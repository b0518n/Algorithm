StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = null;
int n = 0; // 정점 개수
int m = 0; // 간선 개수

int a = 0;
int b = 0;

TreeNode[] treeNodes = null;
bool[] visited = null;
int treeCount = 0;
int count = 0;
bool result = true;

while (true)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    n = input[0];
    m = input[1];

    if (n == 0 && m == 0)
    {
        break;
    }

    count++;
    treeCount = 0;
    visited = new bool[n + 1];
    treeNodes = new TreeNode[n + 1];

    for (int i = 1; i < n + 1; i++)
    {
        treeNodes[i] = new TreeNode(i);
    }

    for (int i = 0; i < m; i++)
    {
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        a = input[0];
        b = input[1];

        if (a != b)
        {
            if (!treeNodes[a].adjacentNodes.ContainsKey(b))
            {
                treeNodes[a].adjacentNodes.Add(b, treeNodes[b]);
            }

            if (!treeNodes[b].adjacentNodes.ContainsKey(a))
            {
                treeNodes[b].adjacentNodes.Add(a, treeNodes[a]);
            }
        }
    }

    for (int i = 1; i < n + 1; i++)
    {
        if (visited[i])
        {
            continue;
        }

        result = DFS(treeNodes[i], null);
        if (result)
        {
            treeCount++;
        }
    }

    if (treeCount == 0)
    {
        sw.WriteLine($"Case {count}: No trees.");
    }
    else if (treeCount == 1)
    {
        sw.WriteLine($"Case {count}: There is one tree.");
    }
    else
    {
        sw.WriteLine($"Case {count}: A forest of {treeCount} trees.");
    }
}

sw.Flush();
sw.Close();

bool DFS(TreeNode node, TreeNode previousNode)
{
    visited[node.number] = true;
    bool result = true;

    foreach (int temp in node.adjacentNodes.Keys)
    {
        if (visited[temp])
        {
            // DFS로 방문 처리를 할 때 이전 노드와 동일하지 않을 경우 트리가 아닌 것으로 판별
            if (previousNode == null || previousNode.number != temp)
            {
                result = false;
            }
        }
        else
        {
            if (result)
            {
                result = DFS(treeNodes[temp], node);
            }

            DFS(treeNodes[temp], node);
        }
    }

    return result;
}

class TreeNode
{
    public int number;
    public Dictionary<int, TreeNode> adjacentNodes;

    public TreeNode(int number)
    {
        this.number = number;
        this.adjacentNodes = new Dictionary<int, TreeNode>();
    }
}
StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
int[] input = null;
int[,] stats = new int[n, n];
Dictionary<int, int> dics = new Dictionary<int, int>();
int min = int.MaxValue;

Input();
OrganizeTeam(0, 0);
BruteForce();

sw.WriteLine(min);
sw.Flush();
sw.Close();

void Input()
{
    for (int i = 0; i < n; i++)
    {
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        for (int j = 0; j < n; j++)
        {
            stats[i, j] = input[j];
        }
    }
}

void OrganizeTeam(int now, int teamData)
{
    if (now == n)
    {
        return;
    }

    for (int i = now; i < n; i++)
    {
        if ((teamData & (1 << i)) == 0 && !dics.ContainsKey(teamData | 1 << i))
        {
            teamData |= (1 << i);
            dics.Add(teamData, 1);
            OrganizeTeam(now + 1, teamData);
            teamData &= ~(1 << i);
        }
    }
}

void CalculateScore(int startTeamData)
{
    int startTeamScore = 0;
    int linkTeamScore = 0;
    int result = 0;

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (i == j)
            {
                continue;
            }

            if ((startTeamData & (1 << i)) == (1 << i) && (startTeamData & (1 << j)) == (1 << j))
            {
                startTeamScore += stats[i, j];
            }
            else if ((startTeamData & (1 << i)) == 0 && (startTeamData & (1 << j)) == 0)
            {
                linkTeamScore += stats[i, j];
            }
        }
    }

    result = Math.Abs(startTeamScore - linkTeamScore);
    min = Math.Min(min, result);
    return;
}

void BruteForce()
{
    foreach (int key in dics.Keys)
    {
        CalculateScore(key);
    }
}
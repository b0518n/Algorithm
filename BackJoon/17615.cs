StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = 0;
string str = string.Empty;
int result = int.MaxValue;

Input();
Solve();
Print();

void Input()
{
    n = int.Parse(sr.ReadLine());
    str = sr.ReadLine();
}

void Solve()
{
    BallInfo red = new BallInfo();
    BallInfo blue = new BallInfo();

    int cnt = 0;
    int beforeBallColor = 0; // 0 : red, 1 : blue
    bool isAdjacant = false; // 왼쪽 끝부터 현재 위치의 볼의 색까지 인접한 색의 볼의 색이 모두 같은 경우 : true

    for (int i = 0; i < str.Length; i++)
    {
        if (i == 0)
        {
            if (str[i].ToString() == "R")
            {
                cnt++;
                beforeBallColor = 0;
                isAdjacant = true;
            }
            else
            {
                cnt++;
                beforeBallColor = 1;
                isAdjacant = true;
            }
        }
        else if (i == str.Length - 1)
        {
            if ((beforeBallColor == 0 && str[i].ToString() == "R") || (beforeBallColor == 1 && str[i].ToString() == "B"))
            {
                cnt++;
                if (beforeBallColor == 0)
                {
                    red.right += cnt;
                }
                else
                {
                    blue.right += cnt;
                }
            }
            else
            {
                if (beforeBallColor == 0)
                {
                    red.nmg += cnt;
                    blue.right += 1;
                }
                else
                {
                    blue.nmg += cnt;
                    red.right += 1;
                }
            }
        }
        else
        {
            if ((beforeBallColor == 0 && str[i].ToString() == "R") || (beforeBallColor == 1 && str[i].ToString() == "B"))
            {
                cnt++;
            }
            else
            {
                if (str[i].ToString() == "R")
                {
                    beforeBallColor = 0;
                    if (isAdjacant)
                    {
                        blue.left += cnt;
                    }
                    else
                    {
                        blue.nmg += cnt;
                    }

                    isAdjacant = false;
                }
                else
                {
                    beforeBallColor = 1;
                    if (isAdjacant)
                    {
                        red.left += cnt;
                    }
                    else
                    {
                        red.nmg += cnt;
                    }

                    isAdjacant = false;
                }

                cnt = 1;
            }
        }
    }

    result = Math.Min(result, red.left + red.nmg);
    result = Math.Min(result, red.right + red.nmg);
    result = Math.Min(result, blue.left + blue.nmg);
    result = Math.Min(result, blue.right + blue.nmg);
}

void Print()
{
    sw.WriteLine(result);
    sw.Flush();
    sw.Close();
}

class BallInfo
{
    public int left;
    public int right;
    public int nmg;

    public BallInfo()
    {
        this.left = 0;
        this.right = 0;
        this.nmg = 0;
    }
}
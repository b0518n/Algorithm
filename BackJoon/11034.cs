StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string input = null;
int[] temp = null;
int aPos = 0;
int bPos = 0;
int cPos = 0;

int result = 0;
int abDist = 0;
int bcDist = 0;

while (true)
{
    input = sr.ReadLine();

    if (input == null || input == string.Empty)
        break;

    result = 0;
    temp = Array.ConvertAll(input.Split(), int.Parse);
    aPos = temp[0];
    bPos = temp[1];
    cPos = temp[2];

    MaxMoveCnt();
    sw.WriteLine(result);
}

sw.Flush();
sw.Close();

void MaxMoveCnt()
{
    while (true)
    {
        abDist = bPos - aPos;
        bcDist = cPos - bPos;

        if (abDist == 1 && bcDist != 1)
        {
            result++;
            aPos = bPos;
            bPos = bPos + 1;
        }
        else if (bcDist == 1 && abDist != 1)
        {
            result++;
            cPos = bPos;
            bPos = bPos - 1;
        }
        else if (abDist == 1 && bcDist == 1)
        {
            break;
        }
        else
        {
            if (abDist >= bcDist)
            {
                result++;
                cPos = bPos;
                bPos = bPos - 1;
            }
            else
            {
                result++;
                aPos = bPos;
                bPos = bPos + 1;
            }
        }
    }
}
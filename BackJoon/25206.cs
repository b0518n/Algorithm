string[] input = null;
float result = 0;
float sum = 0;

for (int i = 0; i < 20; i++)
{
    input = Console.ReadLine().Split();
    if (input[2] == "P")
    {
        continue;
    }
    else
    {
        sum += float.Parse(input[1]);
        result += float.Parse(input[1]) * solve(input[2]);
    }
}

Console.WriteLine(string.Format("{0:F6}", result / sum));

float solve(string str)
{
    float count = 0;
    switch (str)
    {
        case "A+":
            count = 4.5f;
            break;
        case "A0":
            count = 4.0f;
            break;
        case "B+":
            count = 3.5f;
            break;
        case "B0":
            count = 3.0f;
            break;
        case "C+":
            count = 2.5f;
            break;
        case "C0":
            count = 2.0f;
            break;
        case "D+":
            count = 1.5f;
            break;
        case "D0":
            count = 1.0f;
            break;
        case "F":
            count = 0.0f;
            break;

    }

    return count;
}
string input = Console.ReadLine();
float value = GetScore(input);
string result = value.ToString("0.0");
Console.WriteLine(result);

float GetScore(string str)
{
    if (str.Length == 1)
    {
        return 0.0f;
    }

    float result = 0.0f;

    switch (str)
    {
        case "A+":
            result = 4.3f;
            break;
        case "A0":
            result = 4.0f;
            break;
        case "A-":
            result = 3.7f;
            break;
        case "B+":
            result = 3.3f;
            break;
        case "B0":
            result = 3.0f;
            break;
        case "B-":
            result = 2.7f;
            break;
        case "C+":
            result = 2.3f;
            break;
        case "C0":
            result = 2.0f;
            break;
        case "C-":
            result = 1.7f;
            break;
        case "D+":
            result = 1.3f;
            break;
        case "D0":
            result = 1.0f;
            break;
        case "D-":
            result = 0.7f;
            break;
    }

    return result;
}
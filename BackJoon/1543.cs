StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string document = sr.ReadLine();
string word = sr.ReadLine();

int documentLength = document.Length;
int wordLength = word.Length;

int result = 0;
bool isContain = true;

for (int i = 0; i < documentLength - wordLength + 1; i++)
{
    isContain = true;
    for (int j = 0; j < wordLength; j++)
    {
        if (document[i + j] != word[j])
        {
            isContain = false;
            break;
        }
    }

    if (isContain)
    {
        result++;
        i += wordLength - 1;
    }
}

sw.WriteLine(result);
sw.Flush();
sw.Close();
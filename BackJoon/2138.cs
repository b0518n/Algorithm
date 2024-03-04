StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
string temp = sr.ReadLine();

int[] initialState = new int[n];
int[] finalState = new int[n];

int index = n - 1;
while (true)
{
    if (index < 0)
    {
        break;
    }

    initialState[index] = int.Parse(temp[index].ToString());
    index--;
}

temp = sr.ReadLine();
index = n - 1;
while (true)
{
    if (index < 0)
    {
        break;
    }

    finalState[index] = int.Parse(temp[index].ToString());
    index--;
}

int result = -1;

IsChangetoFinalState(true, DeepCopy(initialState));
IsChangetoFinalState(false, initialState);

sw.WriteLine(result);
sw.Flush();
sw.Close();

bool IsChangetoFinalState(bool turnOnFirstSwitch, int[] state)
{
    int cnt = 0;

    if (turnOnFirstSwitch)
    {
        OnSwitch(ref state, 0);
        cnt++;
    }

    int index = 1;

    while (true)
    {
        if (index == state.Length)
        {
            break;
        }

        if (state[index - 1] != finalState[index - 1])
        {
            OnSwitch(ref state, index);
            cnt++;
        }

        index++;
    }

    if (state[state.Length - 1] == finalState[finalState.Length - 1])
    {
        if (result == -1)
        {
            result = cnt;
        }
        else
        {
            result = Math.Min(result, cnt);
        }

        return true;
    }
    else
    {
        return false;
    }
}

void OnSwitch(ref int[] state, int index)
{
    if (index - 1 >= 0)
    {
        if (state[index - 1] == 0)
        {
            state[index - 1] = 1;
        }
        else
        {
            state[index - 1] = 0;
        }
    }

    if (state[index] == 0)
    {
        state[index] = 1;
    }
    else
    {
        state[index] = 0;
    }

    if (index + 1 <= state.Length - 1)
    {
        if (state[index + 1] == 0)
        {
            state[index + 1] = 1;
        }
        else
        {
            state[index + 1] = 0;
        }
    }
}

int[] DeepCopy(int[] arr)
{
    int[] tempArr = new int[arr.Length];

    for (int i = 0; i < arr.Length; i++)
    {
        tempArr[i] = arr[i];
    }

    return tempArr;
}
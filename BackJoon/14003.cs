StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
int[] sequence = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
List<int> longestSequence = new List<int>();
List<int> list = new List<int>();

for (int i = 0; i < n; i++)
{
    int num = sequence[i];

    if (longestSequence.Count == 0 || longestSequence[longestSequence.Count - 1] < num)
    {
        if (longestSequence.Count == 0)
        {
            list.Add(1);
        }
        else
        {
            list.Add(longestSequence.Count + 1);
        }

        longestSequence.Add(num);
    }
    else
    {
        int index = BinarySearch(longestSequence, num);
        longestSequence[index] = num;
        list.Add(index + 1);
    }
}

int length = longestSequence.Count;
sw.WriteLine(length);
int _index = list.IndexOf(length);
Stack<int> stack = new Stack<int>();
stack.Push(sequence[_index]);

length--;

for (int i = _index - 1; i >= 0; i--)
{
    if (length == list[i])
    {
        stack.Push(sequence[i]);
        length--;
    }
}

sw.Write(stack.Pop());
while (stack.Count > 0)
{
    sw.Write(" " + stack.Pop());
}

sw.Flush();
sw.Close();
        }

        // list를 맨뒤부터 하나하나 검색할 경우 시간초과(24%)
        // 이진탐색 : O(NlogN)
        static int BinarySearch(List<int> list, int number)
{
    int left = 0;
    int right = list.Count - 1;

    while (left < right)
    {
        int mid = (left + right) / 2;

        if (list[mid] < number)
        {
            left = mid + 1;
        }
        else
        {
            right = mid;
        }
    }

    return left;
}
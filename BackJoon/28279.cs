StringBuilder sb = new StringBuilder();
int n = int.Parse(Console.ReadLine()); // 명령의 수
int[] input = null;
Deque deque = new Deque();
for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    switch (input[0])
    {
        case 1:
            deque.AddFront(input[1]);
            break;
        case 2:
            deque.AddBack(input[1]);
            break;
        case 3:
            sb.AppendLine(deque.PopFront().ToString());
            break;
        case 4:
            sb.AppendLine(deque.PopBack().ToString());
            break;
        case 5:
            sb.AppendLine(deque.GetCount().ToString());
            break;
        case 6:
            sb.AppendLine(deque.IsEmpty().ToString());
            break;
        case 7:
            sb.AppendLine(deque.GetFront().ToString());
            break;
        case 8:
            sb.AppendLine(deque.GetBack().ToString());
            break;
    }
}

Console.WriteLine(sb.ToString());

public class Deque
{
    private LinkedList<int> list = new LinkedList<int>();
    // list.count : O(n)
    private int count = 0; // O(1)

    public void AddFront(int value)
    {
        list.AddFirst(value);
        count++;
    }

    public void AddBack(int value)
    {
        list.AddLast(value);
        count++;
    }

    public int PopFront()
    {
        if (count == 0)
        {
            return -1;
        }

        int value = list.First.Value; // list.First()는 참조를 반환하기 때문에 list.First.Value를 가져오는 것이 더 빠름
        list.RemoveFirst();
        count--;
        return value;
    }

    public int PopBack()
    {
        if (count == 0)
        {
            return -1;
        }

        int value = list.Last.Value;
        list.RemoveLast();
        count--;
        return value;
    }

    public int GetCount()
    {
        return count;
    }

    public int IsEmpty()
    {
        return (count == 0 ? 1 : 0);
    }

    public int GetFront()
    {
        return (count == 0 ? -1 : list.First.Value);
    }

    public int GetBack()
    {
        return (count == 0 ? -1 : list.Last.Value);
    }
}
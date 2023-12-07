using System.Text;

StringBuilder sb = new StringBuilder();
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];

string str = Console.ReadLine();
Deque deque = new Deque(500000);

for (int i = 0; i < n; i++)
{
    if (k == 0)
    {
        deque.EnqueueRight(str[i]);
        continue;
    }

    while (true)
    {
        if (deque.Count() == 0 || k == 0)
        {
            deque.EnqueueRight(str[i]);
            break;
        }
        else
        {
            if (deque.RightPeek() < int.Parse(str[i].ToString()))
            {
                deque.DequeRight();
                k--;
            }
            else
            {
                deque.EnqueueRight(str[i]);
                break;
            }
        }
    }
}

if (k != 0)
{
    while (k > 0)
    {
        deque.DequeRight();
        k--;
    }
}

while (deque.Count() > 0)
{
    sb.Append(deque.DequeLeft().ToString());
}

Console.WriteLine(sb.ToString());

class Deque
{
    char[] arr;
    int leftPeek;
    int rightPeek;
    int capacity;
    int count;

    public Deque(int capacity)
    {
        arr = new char[capacity];
        leftPeek = 0;
        rightPeek = -1;
        this.capacity = capacity;
        count = 0;
    }

    public void EnqueueLeft(char value)
    {
        if (count == capacity)
        {
            return;
        }

        leftPeek = (leftPeek - 1 + this.capacity) % this.capacity;
        arr[leftPeek] = value;
        count++;
    }

    public void EnqueueRight(char value)
    {
        if (count == capacity)
        {
            return;
        }

        rightPeek = (rightPeek + 1) % capacity;
        arr[rightPeek] = value;
        count++;
    }

    public int LeftPeek()
    {
        return int.Parse(arr[leftPeek].ToString());
    }

    public int RightPeek()
    {
        return int.Parse(arr[rightPeek].ToString());
    }

    public int DequeLeft()
    {
        if (count == 0)
        {
            return -1;
        }

        int value = int.Parse(arr[leftPeek].ToString());
        leftPeek = (leftPeek + 1) % capacity;
        count--;

        return value;
    }

    public int DequeRight()
    {
        if (count == 0)
        {
            return -1;
        }

        int value = int.Parse(arr[rightPeek].ToString());
        rightPeek = (rightPeek - 1 + capacity) % capacity;
        count--;

        return value;
    }

    public int Count()
    {
        return count;
    }
}
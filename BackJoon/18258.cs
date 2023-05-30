// pop를 할 때 list에서 맨 앞부분을 그냥 RemoveAt으로 삭제할 경우, 시간초과 발생
// 맨 앞 인덱스를 Remove로 없앨 경우 함수 내부적으로는 맨 앞을 지우고 각각 한칸씩 앞으로 당기는 작업이 이루어짐
// 해결방안으로 지우는 대신 firstIndex를 1씩 더하는 방식으로 지우지 않고 맨 앞의 숫자를 호출할 때 index로
// firstIndex를 넣는 방식을 사용.

StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
List<int> queue = new List<int>();
string input = null;
string[] temp = null;
int firstIndex = 0;

for (int i = 0; i < n; i++)
{
    input = Console.ReadLine();
    if (input[0] == 'p') // push, pop
    {
        if (input[1] == 'u') // push
        {
            temp = input.Split();
            queue.Add(int.Parse(temp[1]));
        }
        else // pop
        {
            if (queue.Count == 0 || firstIndex > queue.Count - 1)
            {
                sw.WriteLine(-1);
            }
            else
            {
                if (firstIndex > queue.Count - 1)
                {
                    sw.WriteLine(-1);
                }
                else
                {
                    sw.WriteLine(queue[firstIndex]);
                    firstIndex++;
                }

            }
        }
    }
    else if (input[0] == 'f') // front
    {
        if (queue.Count == 0 || firstIndex > queue.Count - 1)
        {
            sw.WriteLine(-1);
        }
        else
        {
            sw.WriteLine(queue[firstIndex]);
        }
    }
    else if (input[0] == 'b') // back
    {
        if (queue.Count == 0 || firstIndex > queue.Count - 1)
        {
            sw.WriteLine(-1);
        }
        else
        {
            sw.WriteLine(queue[queue.Count - 1]);
        }
    }
    else if (input[0] == 's') // size
    {
        sw.WriteLine(queue.Count - firstIndex);
    }
    else if (input[0] == 'e') // empty
    {
        if (queue.Count == 0 || firstIndex > queue.Count - 1)
        {
            sw.WriteLine(1);
        }
        else
        {
            sw.WriteLine(0);
        }
    }
}

sw.Close();
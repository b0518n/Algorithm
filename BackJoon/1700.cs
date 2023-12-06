int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];

int[] appliances = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Dictionary<int, int> usings = new Dictionary<int, int>(); // 배열이 아닌 딕셔너리를 이용해서, 각각의 콘센트가 비어있는지 찾는 for문을 사용하지 않고 키를 통해 빠르게 찾을 수 있도록 함
int result = 0;
int _key = -1;
int index = -1;
int __key = -1; // 다시 사용하지 않는 가정용품의 key

for (int i = 0; i < k; i++)
{
    if (usings.Count < n)
    {
        if (usings.ContainsKey(appliances[i]))
        {
            continue;
        }

        usings.Add(appliances[i], 1);

    }
    else
    {
        if (usings.ContainsKey(appliances[i]))
        {
            continue;
        }

        _key = -1;
        index = -1;
        __key = -1;

        foreach (int key in usings.Keys)
        {
            for (int l = i + 1; l < k; l++)
            {
                if (appliances[l] == key)
                {
                    if (_key == -1 && index == -1)
                    {
                        _key = key;
                        index = l;
                    }
                    else
                    {
                        if (l > index)
                        {
                            _key = key;
                            index = l;
                        }
                    }

                    break;
                }
                else
                {
                    if (l == k - 1)
                    {
                        __key = key;
                    }
                }
            }
        }

        if (__key == -1)
        {
            usings.Remove(_key);
        }
        else
        {
            usings.Remove(__key);
        }

        usings.Add(appliances[i], 1);
        result++;
    }
}

Console.WriteLine(result);
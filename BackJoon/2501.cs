int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];

int result = 0;
int count = 0;
int i = 1;
bool flag = false;

while (true)
{
    if (i > n)
    {
        flag = true;
        break;
    }

    if (n % i == 0)
    {
        count++;
    }

    if (count == k)
    {
        result = i;
        break;
    }

    i++;

}

if (flag == true)
{
    Console.WriteLine(0);
}
else
{
    Console.WriteLine(result);
}
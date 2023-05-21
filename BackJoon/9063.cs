int n = int.Parse(Console.ReadLine());
int[] arr = null;
int x = 0;
int y = 0;
int minX = 0;
int minY = 0;
int maxX = 0;
int maxY = 0;
if (n == 1)
{
    Console.WriteLine(0);
}
else
{
    for (int i = 0; i < n; i++)
    {
        arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        x = arr[0];
        y = arr[1];

        if (i == 0)
        {
            minX = x;
            minY = y;
            maxX = x;
            maxY = y;
        }
        else
        {
            if (minX > x)
            {
                minX = x;
            }

            if (minY > y)
            {
                minY = y;
            }

            if (maxX < x)
            {
                maxX = x;
            }

            if (maxY < y)
            {
                maxY = y;
            }
        }
    }

    Console.WriteLine((maxX - minX) * (maxY - minY));
}
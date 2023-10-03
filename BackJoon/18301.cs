int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n1 = input[0];
int n2 = input[1];
int n12 = input[2];

int n = (input[0] + 1) * (n2 + 1);
n /= (n12 + 1);
n--;

Console.WriteLine(n);
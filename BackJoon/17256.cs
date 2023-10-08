int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int ax = input[0];
int ay = input[1];
int az = input[2];

input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int cx = input[0];
int cy = input[1];
int cz = input[2];

int bx = cx - az;
int by = cy / ay;
int bz = cz - ax;

Console.WriteLine($"{bx} {by} {bz}");
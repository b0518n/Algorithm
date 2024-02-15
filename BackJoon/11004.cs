StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];

input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
Array.Sort(input);
sw.WriteLine(input[k - 1]);
sw.Flush();
sw.Close();
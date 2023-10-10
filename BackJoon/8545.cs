string input = Console.ReadLine();
List<char> sequence = input.ToList();
sequence.Reverse();

Console.WriteLine(string.Join("", sequence));
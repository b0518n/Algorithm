StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(sr.ReadLine());
List<Student> students = new List<Student>();
string[] input = null;

for (int i = 0; i < n; i++)
{
    input = sr.ReadLine().Split();
    Student student = new Student(input[0].ToString(), int.Parse(input[1].ToString()), int.Parse(input[2].ToString()), int.Parse(input[3].ToString()));
    students.Add(student);
}

students.Sort((a, b) =>
{
    int compare = a.kScore.CompareTo(b.kScore) * -1;

    if (compare == 0)
    {
        compare = a.eScore.CompareTo(b.eScore);

        if (compare == 0)
        {
            compare = a.mScore.CompareTo(b.mScore) * -1;

            if (compare == 0)
            {
                compare = a.name.CompareTo(b.name);
            }
        }
    }

    return compare;
});

for (int i = 0; i < n; i++)
{
    sw.WriteLine(students[i].name);
}

sw.Flush();
sw.Close();

class Student
{
    public string name;
    public int kScore;
    public int eScore;
    public int mScore;

    public Student(string name, int kScore, int eScore, int mScore)
    {
        this.name = name;
        this.kScore = kScore;
        this.eScore = eScore;
        this.mScore = mScore;
    }
}
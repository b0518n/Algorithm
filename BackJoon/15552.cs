// StringBuilder의 경우 내부적으로 문자열을 변경 가능한 버퍼에 저장하며,
// 문자열을 수정할 때마다 새로운 문자열 인스턴스를 생성하는 것이 아닌 버퍼를 수정하는 방식을 이용하기 때문에
// 문자열을 처리하는 속도가 빨라짐.

using System.Text;

StringBuilder sb = new StringBuilder();
int t = int.Parse(Console.ReadLine());
int[] input = null;
int a = 0;
int b = 0;

for (int i = 0; i < t; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];
    sb.AppendLine((a + b).ToString());
}

Console.WriteLine(sb);
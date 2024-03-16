using System.IO;
using System.Collections.Generic;
using System.Text;
using System;

// https://terms.naver.com/entry.naver?docId=3567439&cid=58944&categoryId=58970 : 택시 기하학 개념 참조, 네이버 지식백과
StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

int r = int.Parse(Console.ReadLine());

double value = r * r * Math.PI;
double _value = 2 * r * r;
sw.WriteLine("{0:0.000000}", value); // 유클리드 기하학에서 원의 넓이
sw.WriteLine("{0:0.000000}", _value); // 택시 기하학에서 원의 넓이, 택시 기하학에서의 원 == 마름모 모양의 정사각형
sw.Close();


/*using System.Text;

List<int> lst = new List<int>();

var n = 10;
for (int i = 0; i < n; i++)
    lst.Add(i);

lst.Remove(lst[4]);

Console.WriteLine(lst.Contains(5));

for (int i = 0; i < lst.Count; i++)
    Console.WriteLine($"lst[{i}] = {lst[i]}");

Console.WriteLine($"Count - {lst.Count} Capacity - {lst.Capacity}");


string str = "Hello world!";

Console.WriteLine(str);

//foreach (char c in str)
//    Console.WriteLine(c);

for (int i = 0; i < str.Length; i++)
    Console.WriteLine(str[i]);

StringBuilder sb = new StringBuilder();
sb.Append(str);
for (int i = 0; i < 6; i++)
    sb.Append($"{i}");

Console.WriteLine(sb.ToString());*/



using System.Diagnostics.Tracing;

string str = Console.ReadLine();
string[] word = str.Split(' ');

str = str.ToLower();

for (int i = 0; i < word.Length; i++)
    for (int j = 0; j < word[i].Length; j++)
    {
        if (word[i][j] == word[i][0] && j != 0)
        {
            Console.WriteLine(word[i]);
            break;
        }
    }


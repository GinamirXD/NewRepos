using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

string str = Console.ReadLine();
List<string> lst = str.Split(' ').ToList();

for (int i = 0; i < lst.Count; i++)
{
    
    for (int j = i + 1; j < lst.Count; j++)
    {
        if (lst[i] == lst[j])
        {
            lst.Remove(lst[j]);
        }
    }
}

string ans = String.Join(' ',lst);

Console.WriteLine(ans);
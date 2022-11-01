using System.Diagnostics.Tracing;

var dict = new Dictionary<string, int>();

using (StreamReader reader = new StreamReader("input.txt"))
{
    var str = reader.ReadToEnd().Split(new char[] {' ', '\n', '\t'});
    foreach (var word in str)
    {
        if (!dict.ContainsKey(word))
        {
            dict.Add(word, 1);
        }
        else
        {
            dict[word] += 1;
        }
    }
    foreach(var word in dict)
    {
        Console.WriteLine(word);
    }
}


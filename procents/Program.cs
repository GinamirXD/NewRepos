static double Calculate(string userInput)
{
    string[] data = userInput.Split(' ');

    double sum = Convert.ToDouble(data[0]);
    double proc = Convert.ToDouble(data[1])/1200;
    int mounth = Convert.ToInt32(data[2]);

    return sum * Math.Pow(1 + proc, mounth);
}

string s = Console.ReadLine();
Console.WriteLine(Calculate(s));
static string GetMinX(int a, int b, int c)
{
    int D = b * b - 4 * a * c;
    var x1 = (int)(-b + Math.Sqrt(D)) / 2 * a;
    var x2 = (int)(-b - Math.Sqrt(D)) / 2 * a;
    
    if ((D < 0) || (a == 0 && b ==0))
    {
        return "Impossible";
    }
    else
    {
        if (x1 < x2)
        {
            return x1.ToString();
        }
        else
        {
            return x2.ToString();
        }
    }
}

Console.WriteLine(GetMinX(1, 2, 3));
Console.WriteLine(GetMinX(0, 3, 2));
Console.WriteLine(GetMinX(1, -2, -3));
Console.WriteLine(GetMinX(5, 2, 1));
Console.WriteLine(GetMinX(4, 3, 2));
Console.WriteLine(GetMinX(0, 4, 5));
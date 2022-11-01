static int MiddleOf(int a, int b, int c)
{
    if (((a > b) && (b > c)) || ((c > b) && (b > a))) return b;
    else if (((a < b) && (a > c)) || ((a > b) && (c > a))) return a;
    return c;

}

Console.WriteLine(MiddleOf(23, 64, 100));

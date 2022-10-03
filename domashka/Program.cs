double x = double.Parse(Console.ReadLine());
double eps = double.Parse(Console.ReadLine());
double s = 1, del = 1, fac = 2, xstep = 0, i = 3, j = 4;
int k;

xstep = x * x;

for (k = 1; del > eps; k+=1)
{
    del = xstep / fac;
    s += del;
    xstep = xstep * x * x;
    fac = fac * i * j;
    i += 2;
    j += 2;
}

Console.WriteLine(s);
Console.WriteLine(Math.Cosh(x));
Console.WriteLine(k);

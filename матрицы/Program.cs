/*int n = 6, m = 6;

int[,] matr = new int[n, m];

Random r = new Random();
//int[][] mmas = new int[n][];
//for(int i = 0; i < n; i++)
//    mmas[i] = new int[r.Next(8)];



for (int i = 0; i < n; i++)
    for (int j = 0; j < m; j++)
        matr[i, j] = r.Next(100);


for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
        Console.Write($"{matr[i, j],4}");
    Console.WriteLine();
}

for (int i = 0; i < n; i++)
{
    int max = matr[i, 0];
    for (int j = 1; j < m; j++)
        if (max < matr[i, j])
            max = matr[i, j];
    Console.WriteLine($"{i} row - max = {max}");
}
for (int j = 0; j < m; j++)
{
    int min = matr[0, j];
    for (int i = 1; i < n; i++)
        if (min > matr[i, j])
            min = matr[i, j];
    Console.WriteLine($"{j} column - min = {min}");
}


for (int i = 0; i < n; i++)
{
    for (int j = i + 1; j < m; j++)
    {
        var t = matr[i, j];
        matr[i, j] = matr[j, i];
        matr[j, i] = t;
    }
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
        Console.Write($"{matr[i, j],4}");
    Console.WriteLine();
}


//Console.WriteLine(matr.Rank);
//Console.WriteLine(matr.GetLength(0));
//Console.WriteLine(matr.GetLength(1));  */


/*int n = 5, m = 5;
int[,] matr = new int[n, m];

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (j == i)
            matr[i, j] = 1;
        else
            matr[i, j] = 0;
    }
}
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
        Console.Write($"{matr[i, j],2}");
    Console.WriteLine();
}*/

/*int[,] matr = new int[n, m];

Random r = new Random();

for (int i = 0; i < n; i++)
    for (int j = 0; j < m; j++)
        matr[i, j] = r.Next(100);

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
        Console.Write($"{matr[i, j],4}");
    Console.WriteLine();
}*/

int m = int.Parse(Console.ReadLine());
int n = int.Parse(Console.ReadLine());
int k = int.Parse(Console.ReadLine());

int[,] matrA = new int[m, n];
int[,] matrB = new int[n, k];
int[,] matrC = new int[m, k];

Random r = new Random();

for (int i = 0; i < m; i++)
    for (int j = 0; j < n; j++)
        matrA[i, j] = r.Next(100);

for (int i = 0; i < n; i++)
    for (int j = 0; j < k; j++)
        matrB[i, j] = r.Next(100);

for (int i = 0; i < m; i++)
{
    for (int j = 0; j < n; j++)
        Console.Write($"{matrA[i, j],4}");
    Console.WriteLine();
}

Console.WriteLine(" ");

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < k; j++)
        Console.Write($"{matrB[i, j],4}");
    Console.WriteLine();
}


for (int i = 0; i < m; i++)
{
    for (int j = 0; i < k; j++)
    {
        for(int s = 0; s < n; s++)
        {
            matrC = matrA[i, s] + matrB[s,j] ;
        }
    }
}

for (int i = 0; i < m; i++)
{
    for (int j = 0; j < k; j++)
        Console.Write($"{matrC[i, j],4}");
    Console.WriteLine();
}
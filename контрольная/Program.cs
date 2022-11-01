int[,] GenerateMat(int n)
{
    int[,] matr = new int[n, n];
    Random r = new Random();
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            matr[i, j] = r.Next(25);
        }
    }
    return matr;
}

void WriterMatr(int[,] matr, string file)
{
    int n = matr.GetLength(0);
    using (StreamWriter writer = new StreamWriter(file))
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                writer.Write("{0} ", matr[i, j]);
            writer.WriteLine();
        }
    }
}

int[,] ReaderMatr(string file, int n)
{
    using StreamReader reader = new StreamReader(file);
    int[,] matr = new int[n, n];
    for (int i = 0; i < n; i++)
    {
        string[] s = reader.ReadLine().Split(" ");
        for (int j = 0; j < n; j++)
        {
            matr[i, j] = int.Parse(s[j]);
        }

    }
    return matr;
}

void PrintMatr(int[,] matr)
{
    int n = matr.GetLength(0);
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Console.Write($"{matr[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[,] GenerateOddMat(int n)
{
    int t = 0;
    int[,] matr = new int[n, n];
    Random r = new Random();
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            t = r.Next(25);
            if (t%2!=0)
                matr[i, j] = t;
            else
                matr[i, j] = t+1;
        }
    }
    return matr;
}

int SumStr(int[,]matr, int StrNum)
{
    int sum = 0;
    int n = matr.GetLength(0);
    for(int j = 0; j<n; j++)
    {
        sum += matr[StrNum, j];
    }
    return sum;
}

int SumCol(int[,] matr, int ColNum)
{
    int sum = 0;
    int n = matr.GetLength(0);
    for (int i = 0; i < n; i++)
    {
        sum += matr[i, ColNum];
    }
    return sum;
}

int[,] MatrSum(int[,]matr1, int[,]matr2)
{
    int[,] matr3 = new int[matr1.GetLength(0), matr1.GetLength(0)];
    int n = matr1.GetLength(0);
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            matr3[i, j] = matr1[i, j] + matr2[i, j];
        }
    }
    return matr3;
}

int n = 4;

int[,] matr = GenerateMat(n);
WriterMatr(matr, "File.txt");
ReaderMatr("File.txt", n);
PrintMatr(matr);

int[,] oddmatr = GenerateOddMat(n);
Console.WriteLine("Нечетная матрица:");
PrintMatr(oddmatr);

int[,] sumMatr = MatrSum(matr, oddmatr);
Console.WriteLine("Сумма матриц:");
PrintMatr(sumMatr);


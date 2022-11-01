int N = 20;

int[] arr = GenerateMass(N);
PrintMass(arr);


//BubbleSortMass(arr);
//PrintMass(arr);

ChangeSort(arr);
PrintMass(arr);




int[] GenerateMass(int n)
{
    Random random = new Random();

    int[] mas = new int[N];
    for (int i = 0; i < N; i++)
    {
        mas[i] = random.Next(-100, 100);
    }
    return mas;
}

void PrintMass(int[] mas)
{
    for (int i = 0; i < mas.Length; i++)
    {
        Console.Write($"{mas[i]} ");
    }
    Console.WriteLine();
}


void BubbleSortMass(int[] mas)
{
    int n = mas.Length;
    /*for(int k = n -1; k> 1; k--)
        for (int i = 0; i<k; i++) 
            if (mas[i] > mas[i + 1])
            {
                var t = mas[i];
                mas[i] = mas[i + 1];
                mas[i + 1] = t;
            }*/
    bool fl = true;
    while (fl)
    {
        fl = false;
        for(int i = 0; i < n-1; i++)
        {
            if (mas[i] < mas[i + 1])
            {
                var t = mas[i];
                mas[i] = mas[i + 1];
                mas[i + 1] = t;
                fl = true;
            }
        }
    }

}

void ChangeSort(int[] mas)
{
    int n = mas.Length;
    for (int k = n; k > 0; k--)
    {
        var maxmas = mas[0];
        var x = 0;
        for(int i = 0; i<k; i++)
        {
            if(mas[i] > maxmas)
            {
                maxmas = mas[i];
                x = i;
            }
        }
        mas[x] = mas[k-1];
        mas[k-1] = maxmas;
    }
}

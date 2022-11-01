
using System.Globalization;

Console.WriteLine("номер 4");

int[] arr = new int[10];
Random r = new Random();

for (int i = 0; i < arr.Length; i++)
    arr[i] = r.Next(100);

for (int i = 0; i < arr.Length; i++)
{
    Console.WriteLine($"arr[{i}] = {arr[i]}");
}

bool fl = false;

for (int i = 0; i < arr.Length; i++)
{
    for (int j = 2; j <= (int)Math.Sqrt(arr[i])+1; j++)
    {
        if (arr[i] % j == 0 || arr[i] == 1 || arr[i] == 0)
            break;        
    }
    fl = true;
}

if (fl)
    Console.WriteLine("есть простые числа");
else
    Console.WriteLine("нет простых чисел");

//начало номера 5 ************************************************

Console.WriteLine("номер 5");

int[] mas = { 1, 51, 3, 7, 2, 9, 11, 5, 63, 1 };

for (int i = 0; i < mas.Length; i++)
{
    Console.WriteLine($"mas[{i}] = {mas[i]}");
}

bool flag = false;

for (int i = 0; i< mas.Length; i++)
{
    for (int j = i+1; j < mas.Length; j++)
    {
        if (mas[i] == mas[j])
        {
            Console.WriteLine("есть повторяющиеся числа");
            flag = true;
            break;
        }
        
    }
    if (flag)
    {
        break;
    }
}
if (!flag)
{
    Console.WriteLine("нет повторяющихся чисел");
}


//начало номера 6 *************************************


Console.WriteLine("номер 6");

int[] mas1 = { 1, 1, 1, 1, 2, 2, 2 };

for (int i = 0; i < mas1.Length; i++)
{
    Console.WriteLine($"mas1[{i}] = {mas1[i]}");
}

bool flag1 = false;


for (int i = 0; i < mas1.Length; i++)
{
    for (int j = 0; j < mas1.Length; j++)
    {
        int count = 1;

        if (i == j)
        {
            continue;
        }
        if (mas1[i] == mas1[j])
        {
            count += 1;
        }
        if (count == 1)
        {
            flag1 = true;
        }

    }
    if (flag1)
    {
        break;
    }
}
if (!flag1)
{
    Console.WriteLine("нет уникальных чисел");
}
else
{
    Console.WriteLine("есть уникальные числа");
}
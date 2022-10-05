/*const int n = 10;
int[] arr = new int[n];

Random r = new Random();


for (int i = 0; i < n; i++)
    arr[i] = r.Next(-100, 100);

int sum = 0, kolPol = 0;
int max = int.MinValue;



for (int i = 0; i < n; i++)
{
    Console.WriteLine($"a[{i}] = {arr[i]}");

    sum += arr[i];
    if (arr[i] > 0)
        kolPol++;
    if (arr[i] > max)
        max = arr[i];
}
Console.WriteLine($"sum = {sum}, kolPol = {kolPol}, max = {max}");


int[] mas = { 3, 5, 7, 8, 11, 65, 35, 24 };

bool fl = false;

for (int i = 0; i < mas.Length; i++)
{
    Console.WriteLine($"a[{i}] = {mas[i]}");
    if (mas[i] < 0)
        fl = true;
}

if (fl)
    Console.WriteLine("есть отрицательные числа");
else
    Console.WriteLine("нет отрицательных чисел"); */

/* int[] arr = new int[10];

Random r = new Random();

for (int i = 0; i < 10; i++)
    arr[i] = r.Next(-100, 100);

int maxotr = int.MinValue, minpol = int.MaxValue, max = int.MinValue,  maxind = 0;

for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"arr[{i}] = {arr[i]}");
    if (arr[i] < 0 && arr[i] > maxotr)
        maxotr = arr[i];
    if (arr[i] > 0 && arr[i] < minpol)
        minpol = arr[i];
    if (arr[i] > max)
    {
        max = arr[i];
        maxind = i;
    }
}
Console.WriteLine($"минимальное положительное = {minpol}");
Console.WriteLine($"максимальное отрицательное = {maxotr}");
Console.WriteLine(maxind);
*/

int[] arr = { 0, 2, 2, 1, 1, 0, 0, 0, 2, 0 };
int min = int.MaxValue, kol = 0, ind1 = 0, ind2 = 0;

for (int i = 0; i < arr.Length; i++)
{
    Console.WriteLine($"arr[{i}] = {arr[i]}");
    if (arr[i] < min)
    {
        min = arr[i];
        kol = 0;
        kol += 1;
        ind2 = i;
    }
    else if (arr[i] == min)
    {
        kol += 1;
        ind1 = ind2;
        ind2 = i;
    }
}
Console.WriteLine(kol);
Console.WriteLine(ind1);
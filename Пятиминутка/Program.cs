Random n = new Random();
int[] arr = new int[n.Next(10,20)];
int k = 0;

Random r = new Random();

for (int i = 0; i < arr.Length; i++)
{
    arr[i] = r.Next(1,100);
    Console.WriteLine(arr[i]);
}

for (int i = 0; i < arr.Length; i++)
{
    if (i==0 && arr[i] > arr[i + 1])
    {
        k += 1;
    }
    if (i>1 && i<arr.Length-1 && arr[i] > arr[i-1] && arr[i] > arr[i + 1])
    {
        k += 1;
    }
    if (i == arr.Length-1 && arr[i] > arr[i - 1])
    {
        k += 1;
    }
}

Console.WriteLine($"Ответ = {k}");
using System;

class Program
{
	static void Main(string[] args)
	{
        int N = int.Parse(Console.ReadLine());
        string[] PString = Console.ReadLine().Split(' ');
        int[] P = new int[N];
        for (int i = 0; i < N; ++i)
        {
            P[i] = int.Parse(PString[i]);
        }

        int[] Q = new int[N];
        for (int i = 0; i < N; ++i)
        {
            var p = P[i];
            Q[p-1] = i+1;
        }

        Console.WriteLine(string.Join(" ", Q));
    }
}

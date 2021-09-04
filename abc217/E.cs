using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
        var Q = int.Parse(Console.ReadLine());
        var A = new List<int>();

        for (int q = 0; q < Q; ++q)
        {
            var str2 = Console.ReadLine().Split(' ');
            var one = int.Parse(str2[0]);

            switch(one)
            {
                case 1:
                {
                    var two = int.Parse(str2[1]);
                    A.Add(two);
                    break;
                }

                case 2:
                {
                    Console.WriteLine(A[0]);
                    A.RemoveAt(0);
                    break;
                }

                case 3:
                {
                    A = A.OrderBy(value => value).ToList();
                    break;
                }
            }
        }
    }
}

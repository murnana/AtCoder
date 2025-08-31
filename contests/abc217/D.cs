using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
        var str1 = Console.ReadLine().Split(' ');
        var L = int.Parse(str1[0]);
        var Q = int.Parse(str1[1]);

        var list = new List<int[]>()
        {
            Enumerable.Range(1, L).ToArray(),
        };

        for (int q = 0; q < Q; ++q)
        {
            var str2 = Console.ReadLine().Split(' ');
            var c = int.Parse(str2[0]);
            var x = int.Parse(str2[1]);

            if(c == 1)
            {
                for (int i = 0; i < list.Count; ++i)
                {
                    var count = list[i].Length;
                    var index = Array.FindIndex(list[i], value => value == x);
                    if(0 <= index && index < count)
                    {
                        var newList1 = new List<int>(count);
                        var newList2 = new List<int>(count);
                        for (int j = 0; j <= index; ++j)
                        {
                            newList1.Add(list[i][j]);
                        }
                        for (int j = index + 1; j < count; ++j)
                        {
                            newList2.Add(list[i][j]);
                        }
                        list[i] = newList1.ToArray();
                        list.Add(newList2.ToArray());
                        break;
                    }
                }
            }
            else if(c == 2)
            {
                foreach(int[] l in list)
                {
                    if(l.Contains(x))
                    {
                        Console.WriteLine(l.Length);
                        break;
                    }
                }
            }
        }
    }
}

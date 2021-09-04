using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
        var S1 = Console.ReadLine();
        var S2 = Console.ReadLine();
        var S3 = Console.ReadLine();

        var failed = new string[]
        {
            "ABC" , "ARC" , "AGC" , "AHC"
        }.Where(value =>
        {
            if (S1 == value) return false;
            if (S2 == value) return false;
            if (S3 == value) return false;

            return true;
        }).ToArray();


        // 出力
        if(failed.Length == 0)
        {
            Console.WriteLine(string.Empty);
        }
        else
        {
            Console.WriteLine(failed[0]);
        }
	}
}

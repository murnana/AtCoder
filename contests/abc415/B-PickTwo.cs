using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

class Program
{
	static void Main(string[] args)
	{
		var S = Console.ReadLine();
		var results = S.Select((s, index) => (s, index))
						.Where(tuple => tuple.s == '#')
						.Select(tuple => tuple.index+1);
		var stringBuilder = new StringBuilder();

		var i = 0;
		foreach (var item in results)
		{
			stringBuilder.Append(item);
			++i;
			if (i % 2 > 0)
			{
				stringBuilder.Append(',');
			}
			else
			{
				stringBuilder.AppendLine();
			}
		}

		Console.WriteLine(stringBuilder.ToString());
	}
}

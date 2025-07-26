using System;

class Program
{
	static void Main(string[] args)
	{
	  var N = int.Parse(Console.ReadLine());
	  var Astring = Console.ReadLine().Split(' ');
	  var X = int.Parse(Console.ReadLine());

    var exist = false;
	  for (var i=0; i<N; ++i){
	    var A = int.Parse(Astring[i]);
	    exist = A == X;
	    if (exist) {
	      break;
	    }
	  }

		Console.WriteLine(exist ? "Yes" : "No");
	}
}

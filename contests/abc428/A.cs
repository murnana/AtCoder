using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        int S, A, B, X;
        {
            var line = Console.ReadLine().Split(separator: ' ');
            S = int.Parse(s: line[0]);
            A = int.Parse(s: line[1]);
            B = int.Parse(s: line[2]);
            X = int.Parse(s: line[3]);
        }

        var result = 0;
        while(X >= 0)
        {
            if(X <= A)
            {
                result += X * S;
                break;
            }

            X      -= A;
            result += A * S;

            X -= B;
        }

        Console.WriteLine(value: result);
    }
}

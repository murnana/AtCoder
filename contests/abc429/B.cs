using SourceExpander;

internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        byte  N;
        short M;
        {
            var line = Console.ReadLine()!.Split(separator: ' ');
            N = byte.Parse(s: line[0]);
            M = short.Parse(s: line[1]);
        }

        byte[] A;
        short  sum = 0;
        {
            var line = Console.ReadLine()!.Split(separator: ' ');
            A = new byte[N];
            for(byte i = 0 ; i < N ; i++)
            {
                var a = byte.Parse(s: line[i]);
                A[i] =  a;
                sum  += a;
            }
        }

        var isEqualM = false;
        for(byte i = 0 ; i < N ; i++)
        {
            var result = sum - A[i];
            if(result == M)
            {
                isEqualM = true;
                break;
            }
        }

        Console.Write(value: isEqualM ? @"Yes" : @"No");
    }
}

using SourceExpander;

internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        int P, Q, X, Y;
        {
            var line = Console.ReadLine()
                              .Split(separator: ' ');
            P = int.Parse(s: line[0]);
            Q = int.Parse(s: line[1]);

            line = Console.ReadLine()
                          .Split(separator: ' ');
            X = int.Parse(s: line[0]);
            Y = int.Parse(s: line[1]);
        }

        if((X < P) || ((P + 100) <= X) || (Y < Q) || ((Q + 100) <= Y))
        {
            Console.WriteLine(value: "No");
            return;
        }

        Console.WriteLine(value: "Yes");
    }
}

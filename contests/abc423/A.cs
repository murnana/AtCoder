using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        int X;
        int C;
        {
            var line = Console.ReadLine()
                              .Split(separator: ' ');
            X = int.Parse(s: line[0]);
            C = int.Parse(s: line[1]);
        }

        var removeAt = 1000 + C;
        if ((X - removeAt) < 0)
        {
            Console.WriteLine(value: "0");
        }
        else
        {
            var max = X                  / removeAt;
            Console.WriteLine(value: max * 1000);
        }
    }
}

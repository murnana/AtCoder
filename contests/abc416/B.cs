using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var S = Console.ReadLine();
        var T = S.Replace(oldChar: '.', newChar: 'o').ToCharArray();

        var len = T.Length;
        for (var i = 0; i < len; i++)
        {
            if (T[i] != 'o')
            {
                continue;
            }

            for (var j = i + 1; j < len; j++)
            {
                if (T[j] == '#')
                {
                    i = j; // j番目は検査済み
                    break;
                }

                T[j] = '.';
            }
        }

        Console.WriteLine(buffer: T);
    }
}

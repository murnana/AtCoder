using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var Q         = long.Parse(s: Console.ReadLine());
        var openCount = 0L;
        var S         = new Stack<char>();
        for(long i = 1 ; i <= Q ; i++)
        {
            var query = Console.ReadLine();
            if(query[index: 0] == '1')
            {
                var c = query[index: 2];
                S.Push(item: c);
                if(c == ')')
                {
                    openCount -= 1L;
                }
                else
                {
                    openCount += 1L;
                }
            }
            else
            {
                var last = S.Pop();

                if(last == ')')
                {
                    openCount += 1L;
                }
                else
                {
                    openCount -= 1L;
                }
            }

            Console.WriteLine(value: openCount == 0 ? @"Yes" : @"No");
        }
    }
}

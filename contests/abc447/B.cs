using System.Diagnostics;
using SourceExpander;

internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        var S = Console.ReadLine();
        Debug.WriteLine(message: $"S: {S}");

        var  counter  = new Dictionary<char, byte>(capacity: S.Length);
        byte maxCount = 0;
        foreach(var c in S)
        {
            if(!counter.TryAdd(key: c, value: 1))
            {
                counter[key: c] += 1;
            }

            maxCount = Math.Max(val1: counter[key: c], val2: maxCount);
        }

        Debug.WriteLine(message: $"maxCount: {maxCount}");

        foreach(var c in S)
        {
            var count = counter[key: c];
            Debug.WriteLine(message: $"{c}: {count}");
            if(count < maxCount)
            {
                Console.Write(value: c);
            }
        }
    }
}

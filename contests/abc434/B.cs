using System.Runtime.InteropServices;
using SourceExpander;

internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        byte N, M;
        {
            var line = Console.ReadLine().Split(separator: ' ');
            N = byte.Parse(s: line[0]);
            M = byte.Parse(s: line[1]);
        }

        var counter = new Dictionary<byte, C>(capacity: M);
        for(byte i = 0 ; i < N ; i++)
        {
            byte A, B;
            {
                var line = Console.ReadLine().Split(separator: ' ');
                A = byte.Parse(s: line[0]);
                B = byte.Parse(s: line[1]);
            }
            if(!counter.TryAdd(key: A, value: new(total: B)))
            {
                counter[key: A].Add(B: B);
            }
        }

        for(byte i = 1 ; i <= M ; i++)
        {
            Console.WriteLine(value: counter[key: i].GetResult().ToString(format: "N20"));
        }
    }

    [StructLayout(layoutKind: LayoutKind.Auto)]
    private sealed class C
    {
        private byte m_Count;
        private int  m_Total;

        public C(int total)
        {
            m_Count = 1;
            m_Total = total;
        }

        public void Add(int B)
        {
            ++m_Count;
            m_Total += B;
        }

        public decimal GetResult()
        {
            return (decimal)m_Total / (decimal)m_Count;
        }
    }
}

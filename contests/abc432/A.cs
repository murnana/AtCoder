using SourceExpander;

internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        byte[] numbers;
        {
            var line   = Console.ReadLine().Split(separator: ' ');
            var length = line.Length;
            numbers = new byte[length];
            for(var i = 0 ; i < length ; i++)
            {
                numbers[i] = byte.Parse(s: line[i]);
            }

            Array.Sort(array: numbers);
            Array.Reverse(array: numbers);

            foreach(var number in numbers)
            {
                Console.Write(value: number);
            }
        }
    }
}

using SourceExpander;

internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        List<byte> numbers;
        {
            var min    = byte.MaxValue; // 0以外の最小の値
            var line   = Console.ReadLine();
            var length = line.Length;
            numbers = new(capacity: length);
            for(var i = 0 ; i < length ; i++)
            {
                var number = byte.Parse(s: line[index: i].ToString());
                if((number != 0) && (number < min))
                {
                    min = number;
                }

                numbers.Add(item: number);
            }

            // 最小になったものを1つだけ抜きます
            numbers.Remove(item: min);

            // 最小になるように並び替えます
            numbers.Sort();

            // 先頭に0以外の最小の数を持っていきます
            Console.Write(value: min);

            // その他を並べます
            foreach(var number in numbers)
            {
                Console.Write(value: number);
            }
        }
    }
}

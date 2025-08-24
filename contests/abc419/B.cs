using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var Q   = int.Parse(s: Console.ReadLine());
        var bag = new List<int>(); // 袋
        for (var i = 0; i < Q; i++)
        {
            var queryRaw = Console.ReadLine().Split(separator: ' ');

            // 袋から取り出す
            if (queryRaw is ["2"])
            {
                // 最小値を取り出す
                bag.Sort();
                var minValue = bag[index: 0];
                bag.RemoveAt(index: 0);

                Console.WriteLine(value: minValue);
            }
            else if (queryRaw is ["1", _])
            {
                // 袋に入れる
                var value = int.Parse(s: queryRaw[1]);
                bag.Add(item: value);
            }
        }
    }
}

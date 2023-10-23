// https://atcoder.jp/contests/abc325/tasks/abc325_b

// 入力
var N      = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
var places = new Place[N];
for(var i = 0; i < N; i++)
{
    var input = Console.ReadLine()?.Split(' ').Select(int.Parse).ToArray() ?? Array.Empty<int>();

    places[i] = new Place(w: input[0], x: input[1]);
}

//-----------------------------------------------------------------------------

var maxCount = 0;
// var maxTime  = 0;
for(var i = 0; i < 24; i++)
{
    var count = places.Where(value => value.CanJoin(i))
                      .Select(value => value.W)
                      .Sum();
    if(maxCount < count)
    {
        maxCount = count;
        // maxTime  = i;
    }
}
// Debug.WriteLine($"maxCount: {maxCount}, maxTime {maxTime}");


//-----------------------------------------------------------------------------
// 出力
Console.WriteLine(maxCount);


//-----------------------------------------------------------------------------
public readonly struct Place
{
    /// <summary>
    /// 人数
    /// </summary>
    public readonly int W;

    /// <summary>
    /// 開始可能時刻
    /// </summary>
    private readonly int StartTime;

    /// <summary>
    /// 終了時刻
    /// </summary>
    private readonly int EndTime;


    public Place(in int w, in int x)
    {
        W = w;

        // 開始時刻
        StartTime = x + 9;
        if(StartTime >= 24)
        {
            StartTime -= 24;
        }

        // 終了時刻
        EndTime = x + 18;
        if(EndTime >= 24)
        {
            EndTime -= 24;
        }
    }

    public readonly bool CanJoin(int x)
    {
        return StartTime < EndTime
                   ? (StartTime <= x) && (x < EndTime)  // Start <= x <= End
                   : (x < EndTime) || (StartTime <= x); // x <= End || Start <= x
    }
}
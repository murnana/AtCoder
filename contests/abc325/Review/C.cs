// Problem https://atcoder.jp/contests/abc325/tasks/abc325_c
// Explanation https://atcoder.jp/contests/abc325/editorial/7477


// 入力
var              inputHW   = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
ref readonly var H         = ref inputHW[0];
ref readonly var W         = ref inputHW[1];
var              sensorMap = new List<bool>(H * W);
{
    for(var i = 0; i < H; i++)
    {
        sensorMap.AddRange(Console.ReadLine()!.Select(c => c == '#'));
    }
}

//-----------------------------------------------------------------------------

var sensorCount = 0;
for(var i = 0; i < (W * H); i++)
{
    if(HasSensor(
           startSensorIndex: in i,
           H: in H,
           W: in W,
           sensorMap: sensorMap!
       ))
    {
        ++sensorCount;
    }
}


//-----------------------------------------------------------------------------
// 出力
Console.WriteLine(sensorCount);


//-----------------------------------------------------------------------------

static bool HasSensor
(
    in int     startSensorIndex,
    in int     H,
    in int     W,
    List<bool> sensorMap
)
{
    // センサ-があるのか
    if(!sensorMap[startSensorIndex])
    {
        return false;
    }

    // 自分自身が探索済みなので、はずす
    sensorMap[startSensorIndex] = false;

    // W の位置
    var w = startSensorIndex % W;

    // H の位置
    var h = startSensorIndex / W;

    // 左側のセンサーを探す
    {
        var prevSensorIndex = startSensorIndex - 1;
        if(((prevSensorIndex / W) == h)
        && (prevSensorIndex > 0)
        && sensorMap[prevSensorIndex])
        {
            HasSensor(
                startSensorIndex: in prevSensorIndex,
                H: in H,
                W: in W,
                sensorMap: sensorMap
            );
        }
    }

    // 右隣のセンサーを探す
    {
        var nextSensorIndex = startSensorIndex + 1;
        if(((nextSensorIndex / W) == h)
        && (nextSensorIndex < (W * H))
        && sensorMap[nextSensorIndex])
        {
            HasSensor(
                startSensorIndex: in nextSensorIndex,
                H: in H,
                W: in W,
                sensorMap: sensorMap
            );
        }
    }

    // 左下のセンサーを探す
    {
        var leftDownSensorIndex = (startSensorIndex + W) - 1;
        if(((leftDownSensorIndex / W) == (h + 1))
        && (leftDownSensorIndex < (W * H))
        && sensorMap[leftDownSensorIndex])
        {
            HasSensor(
                startSensorIndex: in leftDownSensorIndex,
                H: in H,
                W: in W,
                sensorMap: sensorMap
            );
        }
    }

    // 下のセンサーを探す
    var downSensorIndex = startSensorIndex + W;
    if(((downSensorIndex / W) == (h + 1))
    && (downSensorIndex < (W * H))
    && sensorMap[downSensorIndex])
    {
        HasSensor(
            startSensorIndex: in downSensorIndex,
            H: in H,
            W: in W,
            sensorMap: sensorMap
        );
    }

    // 右下のセンサーを探す
    var rightDownSensorIndex = startSensorIndex + W + 1;
    if(((rightDownSensorIndex / W) == (h + 1))
    && (rightDownSensorIndex < (W * H))
    && sensorMap[rightDownSensorIndex])
    {
        HasSensor(
            startSensorIndex: in rightDownSensorIndex,
            H: in H,
            W: in W,
            sensorMap: sensorMap
        );
    }

    return true;
}

# ReadMe


A C# BitField library. 


Examples:

0. Demo (示例)
``` C#
ABT bT = new ABT() { EA = A.Eghit | A.Two, EB = B.Three, IsBitFields = true };
// 是的,支持枚举, 甚至其他unmanaged数据
// 比如自定义的struct也是支持的(但内存布局需要紧凑模式:[StructLayout(LayoutKind.Sequential, Pack = 1)])
[Flags]
enum A : byte
{
    Zero = 0,
    One = 1 << 0,
    Two = 1 << 1,
    Four = 1 << 2,
    Eghit = 1 << 3,
}
enum B : byte
{
    One = 1,
    Two = 2,
    Three = 3,
} 

struct ABT : IBitFieldable<ABT, int>
{
    private int data;
    public int Data() => data;

    public static implicit operator int(ABT self) => self.data;
    public static explicit operator ABT(int mData) => new() { data = mData };

    public bool IsBitFields
    {
        get => data.BitField<bool>(0, 1);
        set => data.Set2Bitfield(value, 0, 1);
    }
    public A EA
    {
        get => data.BitField<A>(1, 4);
        set => data.Set2Bitfield(value, 1, 4);
    }

    public B EB
    {
        get => data.BitField<B>(5, 2);
        set => data.Set2Bitfield(value, 5, 2);
    }

}
```

1. SnowFlake (分布式开发中的雪花ID算法)  
![Alt text](data:image/png;base64,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)

``` C#

class SnowFlake
{
    static private long Ts() => DateTimeOffset.Now.ToUnixTimeMilliseconds();  // - 2015; if you like
 
    public static SnowFlake NextId(int serialNum, int machineID)
        => new(sid: serialNum, mid: machineID);

    private SnowFlake(int mid, int sid)
    {
        TimeStamp = Ts();
        SerialNumber = sid;
        MachineID = mid;
    }

    // 12位序列号
    public int SerialNumber
    {
        get => m_data.BitField<int>(0, 12);
        set => m_data.Set2Bitfield(value, 0, 12);
    }

    // 41位时间戳
    public long TimeStamp
    {
        get => m_data.BitField<long>(23, 41);
        private set => m_data.Set2Bitfield(value, 23, 41);
    }
    // 10位设备id
    public int MachineID
    {
        get => m_data.BitField<int>(12, 10);
        set => m_data.Set2Bitfield(value, 12, 10);
    }

    // 内部数据用于存储实际bits
    long m_data;
}
```
2. RGBA In Graphic and Images (图形图像中的RGBA)
``` C#
struct RGB565
{
    public byte R
    {
        get => mData.BitField<byte>(0, 5);
        set => mData.Set2Bitfield(value, 0, 5);
    }
    public byte G
    {
        get => mData.BitField<byte>(5, 6);
        set => mData.Set2Bitfield(value, 5, 6);
    }
    public byte B
    {
        get => mData.BitField<byte>(11, 5);
        set => mData.Set2Bitfield(value, 11, 5);
    }
    public ushort mData;
}
struct RGBA5551
{
    public byte R
    {
        get => mData.BitField<byte>(0, 5);
        set => mData.Set2Bitfield(value, 0, 5);
    }
    public byte G
    {
        get => mData.BitField<byte>(5, 5);
        set => mData.Set2Bitfield(value, 5, 5);
    }
    public byte B
    {
        get => mData.BitField<byte>(10, 5);
        set => mData.Set2Bitfield(value, 10, 5);
    }
    public byte A
    {
        get => mData.BitField<byte>(15, 1);
        set => mData.Set2Bitfield(value, 15, 1);
    }
    public ushort mData;
}

```

3.  IPV6 Header (网络开发中的IPv6包头)
``` C#

struct IPV6Head
{
    public byte Version
    {
        get => mData.BitField<byte>(0, 4);
        set => mData.Set2Bitfield(value, 0, 4);
    }
    public byte TrafficClass
    {
        get => mData.BitField<byte>(5, 8);
        set => mData.Set2Bitfield(value, 5, 8);
    }
    public int FlowLabel
    {
        get => mData.BitField<int>(12, 20);
        set => mData.Set2Bitfield(value, 12, 20);
    }

    public int PayloadLength
    {
        get => mData.BitField<int>(32, 16);
        set => mData.Set2Bitfield(value, 32, 16);
    }
    public byte NextHeader
    {
        get => mData.BitField<byte>(48, 8);
        set => mData.Set2Bitfield(value, 48, 8);
    }
    public byte HopLimit
    {
        get => mData.BitField<byte>(56, 8);
        set => mData.Set2Bitfield(value, 56, 8);
    }
    public ulong mData;
}
```

---
At last(写在最后):   
Personally, I think this code is ready to use, but anyone using it needs to test it carefully and at their own risk.  
个人认为此代码已经可以使用, 但任何人使用它都需要自己进行谨慎测试并承担其风险.
---
  




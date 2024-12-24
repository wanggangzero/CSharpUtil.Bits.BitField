# ReadMe


A C# BitField library.   
这是一个在 C# 中的位域操作库，在没有原生语法糖加持的情况下，已经是非常舒服的写法了。

作者封装了用于实现位域的各种位移，且，或操作，使得在 C# 中也能灵活操作内存中的任意一个 bit。

位域操作可能是个比较小众的使用场景，欢迎大家互通有无。

Examples:

0x00. Demo (示例)
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


//  sizeof(ABT) = 1      
struct ABT 
{
    private byte data;
    public byte Data() => data;

    public static implicit operator byte(ABT self) => self.data;
    public static explicit operator ABT(byte mData) => new() { data = mData };

    public bool IsBitFields
    {
        get => data.BitField<bool>(0, 1);
        set => data.SetBitField(value, 0, 1);
    }
    public A EA
    {
        get => data.BitField<A>(1, 4);
        set => data.SetBitField(value, 1, 4);
    }

    public B EB
    {
        get => data.BitField<B>(5, 2);
        set => data.SetBitField(value, 5, 2);
    }

}
```

0x01. SnowFlake (分布式开发中的雪花ID算法)  
![snow flake](https://raw.githubusercontent.com/wanggangzero/CSharpUtil.Bits.BitField/main/image.png?raw=true)

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
        set => m_data.SetBitField(value, 0, 12);
    }

    // 41位时间戳
    public long TimeStamp
    {
        get => m_data.BitField<long>(23, 41);
        private set => m_data.SetBitField(value, 23, 41);
    }
    // 10位设备id
    public int MachineID
    {
        get => m_data.BitField<int>(12, 10);
        set => m_data.SetBitField(value, 12, 10);
    }

    // 内部数据用于存储实际bits
    long m_data;
}
```
0x02. RGBA In Graphic and Images (图形图像中的RGBA)
``` C#
// sizeof(RGB565) = 2, := we can control the layout same as mData
struct RGB565
{
    public byte R
    {
        get => mData.BitField<byte>(0, 5);
        set => mData.SetBitField(value, 0, 5);
    }
    public byte G
    {
        get => mData.BitField<byte>(5, 6);
        set => mData.SetBitField(value, 5, 6);
    }
    public byte B
    {
        get => mData.BitField<byte>(11, 5);
        set => mData.SetBitField(value, 11, 5);
    }
    public ushort mData;
}
// sizeof(RGB5551) = 2, := we can control the layout same as mData
struct RGBA5551
{
    public byte R
    {
        get => mData.BitField<byte>(0, 5);
        set => mData.SetBitField(value, 0, 5);
    }
    public byte G
    {
        get => mData.BitField<byte>(5, 5);
        set => mData.SetBitField(value, 5, 5);
    }
    public byte B
    {
        get => mData.BitField<byte>(10, 5);
        set => mData.SetBitField(value, 10, 5);
    }
    public byte A
    {
        get => mData.BitField<byte>(15, 1);
        set => mData.SetBitField(value, 15, 1);
    }
    public ushort mData;
}

```

0x03.  IPV6 Header (网络开发中的IPv6包头)
``` C#
//    +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
//    | 版本  | 优先权 |              流     标     签                 |
//    +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
//    |         有效载荷长度         |    下一报头   |     跳限制      |
//    +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
//    |                                                               |
//    +                                                               +
//    |                                                               |
//    +                         源    地    址                        +
//    |                              long                             |
//    +                                                               +
//    |                                                               |
//    +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
//    |                                                               |
//    +                                                               +
//    |                                                               |
//    +                        目   的   地   址                      +
//    |                              long                             |
//    +                                                               +
//    |                                                               |
//    +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
// sizeof(IPV6Head) = 8, := we can control the layout same as mData
// yes, I designed it on purpose. The memory layout is very clean.
// 所有例子我都是专门设计的, 内存布局十分干净, 可以方便的直接进行IO复制.
struct IPV6Head
{
    public byte Version
    {
        get => mData.BitField<byte>(0, 4);
        set => mData.SetBitfield(value, 0, 4);
    }
    public byte TrafficClass
    {
        get => mData.BitField<byte>(5, 8);
        set => mData.SetBitField(value, 5, 8);
    }
    public int FlowLabel
    {
        get => mData.BitField<int>(12, 20);
        set => mData.SetBitField(value, 12, 20);
    }

    public int PayloadLength
    {
        get => mData.BitField<int>(32, 16);
        set => mData.SetBitField(value, 32, 16);
    }
    public byte NextHeader
    {
        get => mData.BitField<byte>(48, 8);
        set => mData.SetBitField(value, 48, 8);
    }
    public byte HopLimit
    {
        get => mData.BitField<byte>(56, 8);
        set => mData.SetBitField(value, 56, 8);
    }
    public ulong mData;
}
```
0x04 [BitFields] Attribute模拟定义一个位域struct (需要 lib version >=1.0.10 and .net >= 9.0)
```C#
    // 它的内存布局也是设计为与BaseType一致, 可以直接内存读写. 
    // like: var s = (Some)BinaryReader.ReadInt32(xx); or Use UnSafe.Read<Some>(ptr);
    // Its memory layout is also designed to be consistent with that of BaseType, 
    // allowing for direct read and write operations in memory.
    [BitFields(EBitFieldBaseType.Int64)]
    public partial struct Some
    {
        [BitOffset(0, 8)]     // 
        public partial byte Age { get; set; }

        [BitOffset(8, 1)]
        public partial bool Sex { get; set; }

        [BitOffset(16, 12)]
        internal partial int Year { get; set; }

        [BitOffset(31, 1)]
        public partial bool Sign { get; internal set; }

        //[BitOffset(31, 1)]  // 这个是无效的
        public static bool Ok { get; }
    }
```

>// then code generator will product code like this:  

```C#
    public partial struct Some
    {
        private Int64 data;
        public partial Byte Age 
        {
            get => data.BitField<Byte>(0, 8);
            set => data.SetBitField<Byte>(value, 0, 8);
        }

        public partial Boolean Sex 
        {
            get => data.BitField<Boolean>(8, 1);
            set => data.SetBitField<Boolean>(value, 8, 1);
        }

        internal partial Int32 Year 
        {
            get => data.BitField<Int32>(16, 12);
            set => data.SetBitField<Int32>(value, 16, 12);
        }

        public partial Boolean Sign 
        {
            get => data.BitField<Boolean>(31, 1);
            internal set => data.SetBitField<Boolean>(value, 31, 1);
        }

        /// <summary>
        /// 原型数据
        /// </summary>
        public Int64 Data() => data;

        /// <summary>
        /// 隐式转换为基础类型
        /// </summary>
        /// <param name="self"></param>
        public static implicit operator Int64(Some self) => self.data;

        /// <summary>
        /// 从基础类型显式转换为当前类型
        /// </summary>
        /// <param name="mData"></param>
        public static explicit operator Some(Int64 mData) => new() { data = mData };

        /// <summary>
        /// 序列化为字节数组
        /// </summary>
        /// <returns></returns>
        public byte[] Bytes() => BytesUtil.Bytes(this);
        /// <summary>
        /// 序列化为网络序字节数组(大端序)
        /// </summary>
        /// <returns></returns>
        public byte[] NetBytes()=> BytesUtil.NetBytes(this);
        /// <summary>
        /// 从字节数组反序列化数据结构
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static Some CastFrom(byte[] bytes) => bytes.To<Some>();
    }

```
---
At last(写在最后):   
Personally, I think this code is ready to use, but anyone using it needs to test it carefully and at their own risk.  
个人认为此代码已经可以使用, 但任何人使用它都需要自己进行谨慎测试并承担其风险.
---
  




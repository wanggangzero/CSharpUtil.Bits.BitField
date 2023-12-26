using System.Numerics;
namespace wanggangzero.CSharpUtil.Bits.BitFields
{
    using Bits.Dancing;
    /// <summary>
    /// 对常见数据类型的Bitfield扩展
    /// </summary>
    public static class BitFieldExtension
    {
        public static T BitField<T>(in this byte value, int start, int len) where T : unmanaged => value.BitField<byte, T>(start, len);
        public static T BitField<T>(in this sbyte value, int start, int len) where T : unmanaged => value.BitField<sbyte, T>(start, len);
        public static T BitField<T>(in this short value, int start, int len) where T : unmanaged => value.BitField<short, T>(start, len);
        public static T BitField<T>(in this ushort value, int start, int len) where T : unmanaged => value.BitField<ushort, T>(start, len);
        public static T BitField<T>(in this char value, int start, int len) where T : unmanaged => value.BitField<char, T>(start, len);
        public static T BitField<T>(in this int value, int start, int len) where T : unmanaged => value.BitField<int, T>(start, len);
        public static T BitField<T>(in this uint value, int start, int len) where T : unmanaged => value.BitField<uint, T>(start, len);
        public static T BitField<T>(in this long value, int start, int len) where T : unmanaged => value.BitField<long, T>(start, len);
        public static T BitField<T>(in this ulong value, int start, int len) where T : unmanaged => value.BitField<ulong, T>(start, len);
        public static T BitField<T>(in this Int128 value, int start, int len) where T : unmanaged => value.BitField<Int128, T>(start, len);
        public static T BitField<T>(in this UInt128 value, int start, int len) where T : unmanaged => value.BitField<UInt128, T>(start, len);

        public static byte Set2Bitfield<T>(ref this byte value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static sbyte Set2Bitfield<T>(ref this sbyte value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static short Set2Bitfield<T>(ref this short value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static ushort Set2Bitfield<T>(ref this ushort value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static char Set2Bitfield<T>(ref this char value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static int Set2Bitfield<T>(ref this int value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static uint Set2Bitfield<T>(ref this uint value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static long Set2Bitfield<T>(ref this long value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static ulong Set2Bitfield<T>(ref this ulong value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static Int128 Set2Bitfield<T>(ref this Int128 value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static UInt128 Set2Bitfield<T>(ref this UInt128 value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);

    }

    /// <summary>
    /// 模拟位域，支持利用符合IBinaryInteger<>接口的data, 将其拆分为多个位段充分利用。
    /// </summary>
    /// <typeparamref name="Tself">实现此接口的具体类型</typeparamref>
    /// <typeparamref name="TData">int8~int128类型数据</typeparamref>
    public interface IBitFieldable<Tself, TData> where Tself : unmanaged, IBitFieldable<Tself, TData> where TData : unmanaged, IBinaryInteger<TData>
    {
        /// <summary>
        /// 访问内部数据的方法
        /// </summary>
        /// <returns></returns>
        TData Data();
        /// <summary>
        /// 与内部interge数据类型的隐式转换(=>self.Data())
        /// </summary>
        /// <param name="self"></param>
        abstract static implicit operator TData(Tself self);
        /// <summary>
        /// integer类型显式转换为目标类型
        /// </summary>
        /// <param name="data"></param>
        abstract static explicit operator Tself(TData data);
    }
}
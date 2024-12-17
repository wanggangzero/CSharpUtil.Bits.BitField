
namespace wanggangzero.CSharpUtil.Bits.BitField
{
#if NET7_0_OR_GREATER
    using System;
    using System.Numerics;
#endif
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
#if NET7_0_OR_GREATER
        
        public static T BitField<T>(in this Int128 value, int start, int len) where T : unmanaged => value.BitField<Int128, T>(start, len);
        public static T BitField<T>(in this UInt128 value, int start, int len) where T : unmanaged => value.BitField<UInt128, T>(start, len);
#endif
        public static byte SetBitField<T>(ref this byte value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static sbyte SetBitField<T>(ref this sbyte value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static short SetBitField<T>(ref this short value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static ushort SetBitField<T>(ref this ushort value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static char SetBitField<T>(ref this char value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static int SetBitField<T>(ref this int value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static uint SetBitField<T>(ref this uint value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static long SetBitField<T>(ref this long value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static ulong SetBitField<T>(ref this ulong value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
#if NET7_0_OR_GREATER
        public static Int128 SetBitField<T>(ref this Int128 value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        public static UInt128 SetBitField<T>(ref this UInt128 value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
#endif

    } 
}
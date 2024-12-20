
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
        /// <summary>
        /// 位域: 提取 offset 开始的 len 个bit作为T类型数据返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static T BitField<T>(in this byte value, int offset, int len) where T : unmanaged => value.BitField<byte, T>(offset, len);
        /// <summary>
        /// 位域: 提取 offset 开始的 len 个bit作为T类型数据返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static T BitField<T>(in this sbyte value, int offset, int len) where T : unmanaged => value.BitField<sbyte, T>(offset, len);
        /// <summary>
        /// 位域: 提取 offset 开始的 len 个bit作为T类型数据返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static T BitField<T>(in this short value, int offset, int len) where T : unmanaged => value.BitField<short, T>(offset, len);
        /// <summary>
        /// 位域: 提取 offset 开始的 len 个bit作为T类型数据返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static T BitField<T>(in this ushort value, int offset, int len) where T : unmanaged => value.BitField<ushort, T>(offset, len);
        /// <summary>
        /// 位域: 提取 offset 开始的 len 个bit作为T类型数据返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static T BitField<T>(in this char value, int offset, int len) where T : unmanaged => value.BitField<char, T>(offset, len);
        /// <summary>
        /// 位域: 提取 offset 开始的 len 个bit作为T类型数据返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static T BitField<T>(in this int value, int offset, int len) where T : unmanaged => value.BitField<int, T>(offset, len);
        /// <summary>
        /// 位域: 提取 offset 开始的 len 个bit作为T类型数据返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static T BitField<T>(in this uint value, int offset, int len) where T : unmanaged => value.BitField<uint, T>(offset, len);
        /// <summary>
        /// 位域: 提取 offset 开始的 len 个bit作为T类型数据返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static T BitField<T>(in this long value, int offset, int len) where T : unmanaged => value.BitField<long, T>(offset, len);
        /// <summary>
        /// 位域: 提取 offset 开始的 len 个bit作为T类型数据返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static T BitField<T>(in this ulong value, int offset, int len) where T : unmanaged => value.BitField<ulong, T>(offset, len);
#if NET7_0_OR_GREATER
        /// <summary>
        /// 位域: 提取 offset 开始的 len 个bit作为T类型数据返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static T BitField<T>(in this Int128 value, int offset, int len) where T : unmanaged => value.BitField<Int128, T>(offset, len);
        /// <summary>
        /// 位域: 提取 offset 开始的 len 个bit作为T类型数据返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static T BitField<T>(in this UInt128 value, int offset, int len) where T : unmanaged => value.BitField<UInt128, T>(offset, len);
#endif
        /// <summary>
        /// 位域: 把 v 的值设置到 offset开始的 len个bit内(超出的bit忽略掉)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="v"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static byte SetBitField<T>(ref this byte value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        /// <summary>
        /// 位域: 把 v 的值设置到 offset开始的 len个bit内(超出的bit忽略掉)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="v"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static sbyte SetBitField<T>(ref this sbyte value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        /// <summary>
        /// 位域: 把 v 的值设置到 offset开始的 len个bit内(超出的bit忽略掉)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="v"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static short SetBitField<T>(ref this short value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        /// <summary>
        /// 位域: 把 v 的值设置到 offset开始的 len个bit内(超出的bit忽略掉)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="v"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static ushort SetBitField<T>(ref this ushort value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        /// <summary>
        /// 位域: 把 v 的值设置到 offset开始的 len个bit内(超出的bit忽略掉)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="v"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static char SetBitField<T>(ref this char value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        /// <summary>
        /// 位域: 把 v 的值设置到 offset开始的 len个bit内(超出的bit忽略掉)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="v"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static int SetBitField<T>(ref this int value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        /// <summary>
        /// 位域: 把 v 的值设置到 offset开始的 len个bit内(超出的bit忽略掉)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="v"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static uint SetBitField<T>(ref this uint value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        /// <summary>
        /// 位域: 把 v 的值设置到 offset开始的 len个bit内(超出的bit忽略掉)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="v"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static long SetBitField<T>(ref this long value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        /// <summary>
        /// 位域: 把 v 的值设置到 offset开始的 len个bit内(超出的bit忽略掉)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="v"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static ulong SetBitField<T>(ref this ulong value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        /// <summary>
        /// 位域: 把 v 的值设置到 offset开始的 len个bit内(超出的bit忽略掉)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="v"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
#if NET7_0_OR_GREATER
        /// <summary>
        /// 位域: 把 v 的值设置到 offset开始的 len个bit内(超出的bit忽略掉)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="v"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static Int128 SetBitField<T>(ref this Int128 value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
        /// <summary>
        /// 位域: 把 v 的值设置到 offset开始的 len个bit内(超出的bit忽略掉)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="v"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static UInt128 SetBitField<T>(ref this UInt128 value, T v, int offset, int len) where T : unmanaged => value.SetBits(v.Bits(), offset, 0, len);
#endif

    }
}
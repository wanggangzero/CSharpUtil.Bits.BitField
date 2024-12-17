using System;

namespace wanggangzero.CSharpUtil.Bits.BitField
{
#if NETSTANDARD2_0_OR_GREATER || NET9_0_OR_GREATER
    /// <summary>
    /// 位域结构体的基础类型(限1~8字节Integer)
    /// </summary>
    public enum EBitFieldBaseType
    {
        Byte,
        SByte,
        Short,
        Ushort,
        Int16,
        UInt16,
        Int32,
        UInt32,
        Int64,
        UInt64
    }

    /// <summary>
    /// BitFields标记(generator将会识别并做处理)
    /// </summary>
    /// <param name="baseType">default: int32</param>
    [AttributeUsage(AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
        public class BitFieldsAttribute(EBitFieldBaseType baseType = EBitFieldBaseType.Int32) : Attribute
    {
        public EBitFieldBaseType BaseType { get; } = baseType;
    }

    /// <summary>
    /// 注意: 不同的field可以重叠的风险!(attention: bitfield can overlaps!)
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class BitOffsetAttribute(byte offset, byte length) : Attribute
    {
        public byte Offset { get; } = offset;
        public byte Length { get; } = length;
    }
#endif
}

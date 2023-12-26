using wanggangzero.CSharpUtil.Bits.Dancing;
using wanggangzero.CSharpUtil.Bits.BitFields;
using System.Net;
namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestGetBit()
        {
            Assert.True(byte.MaxValue.GetBit(0) == true);                       // 0b_11111111
            Assert.True(byte.MaxValue.GetBit(7) == true);                       // 0b_11111111 
            Assert.True(byte.MinValue.GetBit(7) == false);                      // 0b_00000000
            Assert.True(sbyte.MaxValue.GetBit(0) == true);                      // 0b_01111111
            Assert.True(sbyte.MaxValue.GetBit(7) == false);                     // 0b_01111111
            Assert.True(sbyte.MinValue.GetBit(0) == false);                     // 0b_10000000
            Assert.True(sbyte.MinValue.GetBit(7) == true);                      // 0b_10000000
            Assert.True(UInt128.MaxValue.GetBit(127) == true);                  // 
            Assert.True(Int128.MaxValue.GetBit(127) == false);
            Assert.True(Int128.MinValue.GetBit(127) == true);
        }

        [Fact]
        public void TestSetBit()
        {
            var x = byte.MaxValue;
            Assert.True(x.SetBit(7, false) == 127);
            Assert.True(x.SetBit(0, false) == 126);
        }

        [Fact]
        public void TestGetBits()
        {

            Assert.True(byte.MaxValue.Bits().Count(true) == 8);
            Assert.True(((sbyte)-1).Bits().Count(true) == 8);
            Assert.True(Int128.MaxValue.Bits().Count(true) == 127);
            Assert.True((Int128.Zero - 1).Bits().Count(true) == 128);
        }

        [Fact]
        public void TestGetBytes()
        {
            uint i = 0xff007711;
            Assert.True(i.GetBytes().Count() == 4);
            Assert.True(i.GetBytes()[0] == 0x11);
            Assert.True(i.GetBytes()[1] == 0x77);
            Assert.True(i.GetBytes()[2] == 0x00);
            Assert.True(i.GetBytes()[3] == 0xff);
            UInt128 ii = 0x55ff000011111111;
            Assert.True(ii.GetBytes()[0] == 0x11);
            Assert.True(ii.GetBytes()[7] == 0x55);
        }

        [Fact]
        public void TestBitfield()
        {

            ABT bT = new ABT() { EA = A.Eghit | A.Two, EB = B.Three, IsBitFields = true };

            Assert.True(bT.IsBitFields);
            Assert.True((bT.EA & A.Eghit) == A.Eghit);
            Assert.True((bT.EA & A.Two) == A.Two);
            Assert.False((bT.EA & A.Four) == A.Four);
            Assert.True(bT.EB == B.Three);

            int i = int.MaxValue;             // 0b_01111111_11111111_11111111_11111111
            Assert.True(i.BitField<byte>(0, 8) == byte.MaxValue);             // 0b_11111111
            Assert.True(i.BitField<A>(8, 4) == (A.One | A.Two | A.Four | A.Eghit));
            Assert.True(i.BitField<char>(12, 6) == '?');                      // 63 == '?'

        }

        public void SetBits()
        {
            int i = 0;
            Assert.True(i.SetBits((0b_111).Bits(0, 3)) == 7);
            Assert.True(i.SetBit(31, true) == -7);
        }

    }

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
}
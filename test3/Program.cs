﻿namespace test3
{
    using System.Runtime.InteropServices;
    using wanggangzero.CSharpUtil.Bits.BitField;

    internal class Program
    {
        static void Main(string[] args)
        {
            var s = new Some();
            s.Age = 13;
            s.Sex = true;
            s.Year = 2024;
            s.Sign = false;
            //var options = new JsonSerializerOptions
            //{
            //    // 设置TypeInfoResolver为默认的解析器，这将启用反射
            //    TypeInfoResolver = new DefaultJsonTypeInfoResolver()
            //};


            //Console.WriteLine(JsonSerializer.Serialize(s, options));
            Console.WriteLine($"age:{s.Age}, sex:{s.Sex}, sign:{s.Sign}");

            Console.WriteLine("Hello, World!");
        }

    }



    [BitFields(EBitFieldBaseType.Int32)]
    public partial struct Some
    {
        /// <summary>
        /// 基础数据
        /// </summary>
        public int Data() => data;
        /// <summary>
        /// 隐式转换为基础类型
        /// </summary>
        /// <param name="self"></param>
        public static implicit operator int(Some self) => self.data;
        /// <summary>
        /// 从基础类型显式转换为当前类型
        /// </summary>
        /// <param name="mData"></param>
        public static explicit operator Some(int mData) => new() { data = mData };

        [BitOffset(0, 8)]     // 1st 3 bits (in 1st byte) are b1
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
}

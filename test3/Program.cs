namespace test3
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

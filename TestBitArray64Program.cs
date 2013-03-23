using System;

namespace BitArray64
{
    class TestBitArray64Program
    {
        static void Main()
        {
            //Initialize some numbers
            BitArray64 num1 = new BitArray64(24242423424234);
            BitArray64 num2 = new BitArray64(42442434234);

            Console.WriteLine("Number {0} in binary is:", num1);
            foreach (var bit in num1)
            {
                Console.Write(bit);
            }
            Console.WriteLine();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace BitArray64
{
    class BitArray64 : IEnumerable<int>
    {
        //Field
        private ulong number;

        //Property
        public ulong Number
        {
            get { return number; }
            set { number = value; }
        }

        //Constructor
        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        //IEnumerable interface implementation
        public IEnumerator<int> GetEnumerator()
        {
            int[] bitsArray = this.GetBits();

            for (int i = 0; i < bitsArray.Length; i++)
            {
                yield return bitsArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //Method to get the bits of the number and put them in an array
        private int[] GetBits()
        {
            ulong num = this.Number;
            int[] bitsArray = new int[64];
            string numAsstring = Convert.ToString((long)num, 2).PadLeft(64,'0');
            for (int i = 0; i < bitsArray.Length; i++)
            {
                bitsArray[i] = (int)(numAsstring[i] -'0');
            }
            return bitsArray;
        }

        //Equals
        public bool Equals(BitArray64 value)
        {
            if (ReferenceEquals(null, value))
            {
                return false;
            }
            if (ReferenceEquals(this, value))
            {
                return true;
            }

            return this.number == value.number;
        }

        public override bool Equals(object obj)
        {
            BitArray64 temp = obj as BitArray64;
            if (temp == null)
                return false;

            return this.Equals(temp);
        }

        //GetHashCode
        public override int GetHashCode()
        {
            return this.number.GetHashCode();
        }
        //Indexer
        public bool GetIndex(int index)
        {
                if (index > 63 || index < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        //Index check for the bit at certain position
        public int this[int index]
        {
            get
            {
                if (GetIndex(index))
                {
                    throw new IndexOutOfRangeException("The index should be in the interval [0, 63]");
                }
                else
                {
                    int[] bitsArray = this.GetBits();
                    return bitsArray[index];
                }
            }
        }

        //Operator ==
        public static bool operator ==(BitArray64 num1, BitArray64 num2)
        {
            return BitArray64.Equals(num1, num2);
        }

        //Operator !=
        public static bool operator !=(BitArray64 num1, BitArray64 num2)
        {
            return !BitArray64.Equals(num1, num2);
        }

        public override string ToString()
        {
            return this.Number.ToString();
        }
    }
}

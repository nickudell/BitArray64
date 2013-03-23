using System;
using System.Collections;
using System.Collections.Generic;

namespace BitArray64
{
    class BitArray64 : IEnumerable<bool>
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
        public IEnumerator<bool> GetEnumerator()
        {
            bool[] bitsArray = this.GetBits();

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
        private bool[] GetBits()
        {
            ulong num = this.Number;
            bool[] bitsArray =new bool[64];
            ulong remainder = num;
            for(int i = 63;i>=0;i--)
            {
                bitPart = 2^i; //The base two value referenced by the bit. Ideally replace this using the >> operator
                if(remainder > bitPart)
                {
                    remainder-=bitPart;
                    bitsArray[63-i] = true; //little endian
                }
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
        public bool IsOutOfIndexBoundsBounds(int index)
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
        public bool this[int index]
        {
            get
            {
                if (IsOutOfIndexBoundsBounds(index))
                {
                    throw new IndexOutOfRangeException("The index should be in the interval [0, 63]");
                }
                else
                {
                    bool[] bitsArray = this.GetBits();
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

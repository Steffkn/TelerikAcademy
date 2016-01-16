using System.Collections.Generic;
namespace _05.BitArray64
{
    // NOT DONE sry
    public class BitArray64 : IEnumerable<int>
    {

        public ulong Number { get; set; }

        /// this[]

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            BitArray64 bitArray = obj as BitArray64;
            if (bitArray == null)
            {
                return false;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            foreach (var VARIABLE in ToString())
            {
                
            }
            return base.GetHashCode();
        }

        public static bool operator ==(BitArray64 arrayA, BitArray64 arrayB)
        {
            return arrayA.Number == arrayB.Number;
        }

        public static bool operator !=(BitArray64 arrayA, BitArray64 arrayB)
        {
            return !(arrayA == arrayB);
        }

        public IEnumerator<int> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}

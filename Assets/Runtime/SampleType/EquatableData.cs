using System;

namespace SampleType
{
    public struct EquatableData : IEquatable<EquatableData>
    {
        public int value;

        public bool Equals(EquatableData other)
        {
            return this.value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is not EquatableData other)
            {
                return false;
            }

            return this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.value;
        }
    }
}

using System.Collections.Generic;

namespace SampleType
{
    public class EquatableDataComparer : IEqualityComparer<EquatableData>
    {
        public bool Equals(EquatableData x, EquatableData y)
        {
            return x.value == y.value;
        }

        public int GetHashCode(EquatableData obj)
        {
            return obj.value;
        }
    }
}

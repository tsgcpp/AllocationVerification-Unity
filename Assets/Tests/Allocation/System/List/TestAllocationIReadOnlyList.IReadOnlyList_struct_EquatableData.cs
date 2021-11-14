using System.Collections.Generic;
using SampleType;

namespace AllocationTests.System
{
    public sealed partial class TestAllocationIReadOnlyList
    {
        public class IReadOnlyList_struct_EquatableData : TestBase<EquatableData>
        {
            private readonly EquatableData _targetValue = new EquatableData { value = 3333 };
            protected override EquatableData TargetValue => _targetValue;

            protected override IReadOnlyList<EquatableData> CreateList() => new List<EquatableData>
            {
                new EquatableData { value = 1111 },
                new EquatableData { value = 2222 },
                _targetValue,
            };
        }
    }
}

using System.Collections.Generic;
using SampleType;

namespace AllocationTests.System
{
    public sealed partial class TestAllocationIReadOnlyList
    {
        public class IReadOnlyList_struct_SimpleData : TestBase<SimpleData>
        {
            private readonly SimpleData _targetValue = new SimpleData { value = 3333 };
            protected override SimpleData TargetValue => _targetValue;

            protected override IReadOnlyList<SimpleData> CreateList() => new List<SimpleData>
            {
                new SimpleData { value = 1111 },
                new SimpleData { value = 2222 },
                _targetValue,
            };
        }

    }
}

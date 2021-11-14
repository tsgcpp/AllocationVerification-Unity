using System.Collections.Generic;

namespace AllocationTests.System
{
    public sealed partial class TestAllocationIReadOnlyList
    {
        public class IReadOnlyList_object : TestBase<object>
        {
            private readonly object _targetValue = "abcd";
            protected override object TargetValue => _targetValue;  // Create another instance per call

            protected override IReadOnlyList<object> CreateList() => new List<object>
            {
                1234,
                true,
                _targetValue,
            };
        }
    }
}

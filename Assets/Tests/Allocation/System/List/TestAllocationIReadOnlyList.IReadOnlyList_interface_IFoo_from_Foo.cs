using System.Collections.Generic;
using SampleType;

namespace AllocationTests.System
{
    public sealed partial class TestAllocationIReadOnlyList
    {
        public class IReadOnlyList_interface_IFoo_from_Foo : TestBase<IFoo>
        {
            private readonly Foo _targetValue = new Foo();
            protected override IFoo TargetValue => _targetValue;

            protected override IReadOnlyList<IFoo> CreateList() => new List<Foo>
            {
                new Foo(),
                new Foo(),
                _targetValue,
            };
        }
    }
}

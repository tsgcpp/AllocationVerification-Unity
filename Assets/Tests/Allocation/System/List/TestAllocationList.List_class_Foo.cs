using System.Collections.Generic;
using SampleType;

namespace AllocationTests.System
{
    public sealed partial class TestAllocationList
    {
        public class List_class_Foo : TestBase<Foo>
        {
            private readonly Foo _targetValue = new Foo();
            protected override Foo TargetValue => _targetValue;

            protected override List<Foo> CreateList() => new List<Foo>
            {
                new Foo(),
                new Foo(),
                _targetValue,
            };
        }
    }
}

using SampleType;

namespace AllocationTests.SampleType
{
    public class TestAllocationSimpleData : TestAllocationBase<SimpleData>
    {
        protected override SimpleData Value => new SimpleData { value = 123 };
    }
}

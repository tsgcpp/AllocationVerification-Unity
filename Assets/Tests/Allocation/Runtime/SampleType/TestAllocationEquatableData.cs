using UnityEngine.TestTools;
using UnityEngine.TestTools.Constraints;
using NUnit.Framework;
using SampleType;

using Is = UnityEngine.TestTools.Constraints.Is;

namespace AllocationTests.SampleType
{
    public class TestAllocationEquatableData : TestAllocationBase<EquatableData>
    {
        protected override EquatableData Value => new EquatableData { value = 123 };

        [Test]
        public void Equals_1st()
        {
            Assert.That(() =>
            {
                Value.Equals(Value);
            }, Is.Not.AllocatingGCMemory());
        }

        [Test]
        public void Equals_2nd()
        {
            Value.Equals(Value);
            Assert.That(() =>
            {
                Value.Equals(Value);
            }, Is.Not.AllocatingGCMemory());
        }
    }
}

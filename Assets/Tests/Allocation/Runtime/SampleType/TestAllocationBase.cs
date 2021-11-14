using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Constraints;

using Is = UnityEngine.TestTools.Constraints.Is;

namespace AllocationTests.SampleType
{
    public abstract class TestAllocationBase<T> where T : struct
    {
        protected abstract T Value { get; }

        [Test]
        public void Equals_WithBoxing_1st()
        {
            Assert.That(() =>
            {
                Value.Equals(Value);
            }, Is.Not.AllocatingGCMemory());
        }

        [Test]
        public void Equals_WithBoxing_2nd()
        {
            Value.Equals(Value);
            Assert.That(() =>
            {
                Value.Equals(Value);
            }, Is.Not.AllocatingGCMemory());
        }

        [Test]
        public void Equals_WithUnboxing_1st()
        {
            object objValue = Value;
            Assert.That(() =>
            {
                Value.Equals(objValue);
            }, Is.Not.AllocatingGCMemory());
        }

        [Test]
        public void Equals_WithUnboxing_2nd()
        {
            object objValue = Value;
            Value.Equals(objValue);
            Assert.That(() =>
            {
                Value.Equals(objValue);
            }, Is.Not.AllocatingGCMemory());
        }
    }
}

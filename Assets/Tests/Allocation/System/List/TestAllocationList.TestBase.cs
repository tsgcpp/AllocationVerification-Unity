using System;
using System.Collections.Generic;
using UnityEngine.TestTools.Constraints;
using NUnit.Framework;

using Is = UnityEngine.TestTools.Constraints.Is;

namespace AllocationTests.System
{
    public sealed partial class TestAllocationList
    {
        public abstract class TestBase<T>
        {
            List<T> _target;

            protected abstract T TargetValue { get; }
            protected abstract List<T> CreateList();

            [SetUp]
            public void SetUp()
            {
                // Call to avoid the first call allocation not in the instance but in the class
                CreateList().Contains(TargetValue);
                foreach (T item in CreateList()) { }

                _target = CreateList();
            }

            [Test]
            public void Check_Precondition()
            {
                Assert.AreEqual(TargetValue, CreateList()[2]);
            }

            [Test]
            public void Verify_for_WithIndex_1st()
            {
                Assert.That(() =>
                {
                    for (int i = 0; i < _target.Count; ++i) { T item = _target[i]; }
                }, Is.Not.AllocatingGCMemory());
            }

            [Test]
            public void Verify_for_WithIndex_2nd()
            {
                for (int i = 0; i < _target.Count; ++i) { T item = _target[i]; }
                Assert.That(() =>
                {
                    for (int i = 0; i < _target.Count; ++i) { T item = _target[i]; }
                }, Is.Not.AllocatingGCMemory());
            }

            [Test]
            public void Verify_foreach_1st()
            {
                Assert.That(() =>
                {
                    foreach (T item in _target) { }
                }, Is.Not.AllocatingGCMemory());
            }

            [Test]
            public void Verify_foreach_2nd()
            {
                foreach (T item in _target) { }
                Assert.That(() =>
                {
                    foreach (T item in _target) { }
                }, Is.Not.AllocatingGCMemory());
            }

            [Test]
            public void Verify_Contains_FromLinq_1st()
            {
                T value = TargetValue;

                Assert.That(() =>
                {
                    _target.Contains(value);
                }, Is.Not.AllocatingGCMemory());
            }

            [Test]
            public void Verify_Contains_FromLinq_2nd()
            {
                T value = TargetValue;

                _target.Contains(value);
                Assert.That(() =>
                {
                    _target.Contains(value);
                }, Is.Not.AllocatingGCMemory());
            }
        }
    }
}

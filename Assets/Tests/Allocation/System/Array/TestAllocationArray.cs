using System;
using System.Collections.Generic;
using UnityEngine.TestTools.Constraints;
using NUnit.Framework;

using Is = UnityEngine.TestTools.Constraints.Is;

namespace AllocationTests.System
{
    public class TestArrayAllocation
    {
        int[] _target;

        [SetUp]
        public void SetUp()
        {
            _target = new int[] { 1, 2, 3 };
        }

        [Test]
        public void AsReadOnly_1st()
        {
            IReadOnlyList<int> readonlyList;
            Assert.That(() =>
            {
                readonlyList = _target;
            }, Is.Not.AllocatingGCMemory());

            readonlyList = _target;
            Assert.AreEqual(2, readonlyList[1]);
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine.TestTools.Constraints;
using NUnit.Framework;

using Is = UnityEngine.TestTools.Constraints.Is;

namespace AllocationTests.System
{
    public class TestAllocationEqualityComparer
    {
        [Test]
        public void Default_whole_1st()
        {
            // FYI: https://referencesource.microsoft.com/#mscorlib/system/collections/generic/equalitycomparer.cs,26

            EqualityComparer<PrivateFoo> target;
            Assert.That(() =>
            {
                target = EqualityComparer<PrivateFoo>.Default;
            }, Is.Not.AllocatingGCMemory());
        }

        [Test]
        public void Default_whole_2nd()
        {
            EqualityComparer<PrivateFoo> target;
            Assert.That(() =>
            {
                target = EqualityComparer<PrivateFoo>.Default;
            }, Is.Not.AllocatingGCMemory());
        }

        private class PrivateFoo
        {
        }
    }
}

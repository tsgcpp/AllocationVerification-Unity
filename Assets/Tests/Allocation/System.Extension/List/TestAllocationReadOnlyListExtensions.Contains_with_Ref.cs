using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.TestTools.Constraints;
using SampleType;
using System.Extension;

using Is = UnityEngine.TestTools.Constraints.Is;

namespace AllocationTests.System.Extension
{
    public sealed partial class TestAllocationReadOnlyListExtensions
    {
        public sealed class Contains_with_Ref
        {
            IReadOnlyList<EquatableFoo> _target;
            IReadOnlyList<EquatableFoo> _targetWithNull;
            IReadOnlyList<EquatableFoo> _targetEmpty;

            EquatableFoo _foundItem;

            [SetUp]
            public void SetUp()
            {
                // Call to avoid the first call allocation not in the instance but in the class
                EqualityComparer<EquatableFoo> c = EqualityComparer<EquatableFoo>.Default;
                int count = new List<EquatableFoo>().Count;
                ReadOnlyListExtensions.Contains(new List<EquatableFoo>(), null);

                _foundItem = new EquatableFoo();

                _target = new List<EquatableFoo>
                {
                    new EquatableFoo(),
                    _foundItem,
                    new EquatableFoo(),
                };

                _targetWithNull = new List<EquatableFoo>
                {
                    new EquatableFoo(),
                    null,
                    new EquatableFoo(),
                };

                _targetEmpty = new List<EquatableFoo>();
            }

            [Test]
            public void ItemIsNull_ListWithoutNull()
            {
                Assert.That(() =>
                {
                    _target.Contains(null);
                }, Is.Not.AllocatingGCMemory());
            }

            [Test]
            public void ItemIsNull_ListWithNull()
            {
                Assert.That(() =>
                {
                    _targetWithNull.Contains(null);
                }, Is.Not.AllocatingGCMemory());
            }

            [Test]
            public void ItemIsNull_EmptyList()
            {
                Assert.That(() =>
                {
                    _targetEmpty.Contains(null);
                }, Is.Not.AllocatingGCMemory());
            }

            [Test]
            public void ItemIsNotNull_ListWithTarget()
            {
                Assert.That(() =>
                {
                    _target.Contains(_foundItem);
                }, Is.Not.AllocatingGCMemory());
            }

            [Test]
            public void ItemIsNotNull_ListWithoutTarget()
            {
                Assert.That(() =>
                {
                    _targetWithNull.Contains(_foundItem);
                }, Is.Not.AllocatingGCMemory());
            }

            [Test]
            public void ItemIsNotNull_EmptyList()
            {
                Assert.That(() =>
                {
                    _targetEmpty.Contains(_foundItem);
                }, Is.Not.AllocatingGCMemory());
            }
        }
    }
}

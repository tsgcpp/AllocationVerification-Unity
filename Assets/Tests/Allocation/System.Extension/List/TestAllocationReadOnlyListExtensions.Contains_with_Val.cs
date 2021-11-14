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
        public sealed class Contains_with_Val
        {
            IReadOnlyList<EquatableData> _target;
            IReadOnlyList<EquatableData> _targetWithoutFoundItem;
            IReadOnlyList<EquatableData> _targetEmpty;

            EquatableData _foundItem;

            [SetUp]
            public void SetUp()
            {
                // Call to avoid the first call allocation not in the instance but in the class
                EqualityComparer<EquatableData> c = EqualityComparer<EquatableData>.Default;
                int count = new List<EquatableData>().Count;
                ReadOnlyListExtensions.Contains(new List<EquatableData>(), default(EquatableData));

                _foundItem = new EquatableData { value = 222 };

                _target = new List<EquatableData>
                {
                    new EquatableData { value = 111 },
                    _foundItem,
                    new EquatableData { value = 333 },
                };

                _targetWithoutFoundItem = new List<EquatableData>
                {
                    new EquatableData { value = 111 },
                    new EquatableData { value = 123 },
                    new EquatableData { value = 333 },
                };

                _targetEmpty = new List<EquatableData>();
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
                    _targetWithoutFoundItem.Contains(_foundItem);
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

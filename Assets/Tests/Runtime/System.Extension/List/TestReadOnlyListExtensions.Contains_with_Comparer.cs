using System.Collections.Generic;
using NUnit.Framework;
using SampleType;
using System.Extension;

namespace Tests.System.Extension
{
    public sealed partial class TestReadOnlyListExtensions
    {
        public sealed class Contains_with_Comparer
        {
            IReadOnlyList<EquatableData> _target;
            IReadOnlyList<EquatableData> _targetWithoutFoundItem;
            IReadOnlyList<EquatableData> _targetEmpty;

            EquatableData _foundItem;

            IEqualityComparer<EquatableData> _comparer;

            [SetUp]
            public void SetUp()
            {
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

                _comparer = new EquatableDataComparer();
            }

            [Test]
            public void ReturnsTrueIfListHasFoundItem()
            {
                Assert.True(_target.Contains(_foundItem, comparer: _comparer));
            }

            [Test]
            public void ReturnsFalseIfListDoesNotHaveFoundItem()
            {
                Assert.False(_targetWithoutFoundItem.Contains(_foundItem, comparer: _comparer));
            }

            [Test]
            public void ReturnsFalseIfListIsEmpty()
            {
                Assert.False(_targetEmpty.Contains(_foundItem, comparer: _comparer));
            }
        }
    }
}

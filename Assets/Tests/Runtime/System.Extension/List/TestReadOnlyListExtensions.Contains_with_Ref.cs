using System.Collections.Generic;
using NUnit.Framework;
using SampleType;
using System.Extension;

namespace Tests.System.Extension
{
    public sealed partial class TestReadOnlyListExtensions
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
            public void ItemIsNull_ListWithoutNull_ReturnsFalse()
            {
                Assert.False(_target.Contains(null));
            }

            [Test]
            public void ItemIsNull_ListWithNull_ReturnsTrue()
            {
                Assert.True(_targetWithNull.Contains(null));
            }

            [Test]
            public void ItemIsNull_EmptyList_ReturnsFalse()
            {
                Assert.False(_targetEmpty.Contains(null));
            }

            [Test]
            public void ItemIsNotNull_ListWithTarget_ReturnsTrue()
            {
                Assert.True(_target.Contains(_foundItem));
            }

            [Test]
            public void ItemIsNotNull_ListWithoutTarget_ReturnsFalse()
            {
                Assert.False(_targetWithNull.Contains(_foundItem));
            }

            [Test]
            public void ItemIsNotNull_EmptyList_ReturnsFalse()
            {
                Assert.False(_targetEmpty.Contains(_foundItem));
            }
        }
    }
}
